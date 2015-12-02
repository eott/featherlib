using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace featherlib
{
    /// <summary>
    /// Offers functionality for queries against a given database. The connection
    /// has a status attribute to signal if the connection is open or, if not, what's
    /// wrong.
    /// </summary>
    public class DbConnection
    {
        /// <summary>
        /// The connection string with host, port, database name and credentials
        /// used in the MySql library.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The MySql database connection handling the actual database stuff.
        /// </summary>
        public MySqlConnection Db { get; set; }

        /// <summary>
        /// The current status of the connection.
        /// </summary>
        public DbConnectionStatus ConnectionStatus { get; set; }

        /// <summary>
        /// If the last connect try threw an error, contains the error message.
        /// NOTE: This does NOT contain the last error message resulting from
        /// queries against a connected database. This may change in the future.
        /// </summary>
        public string LastErrMsg { get; set; }

        /// <summary>
        /// Constructor. Begins with status UNINITIALIZED, then tries to connect
        /// the given server. Depending on success, then either has the status
        /// UNAUTHORIZED or CONNECTED.
        /// </summary>
        /// <param name="host">The hostname where the database is located</param>
        /// <param name="port">The port to connect to</param>
        /// <param name="database">The database name</param>
        /// <param name="user">The username</param>
        /// <param name="password">The user's password</param>
        public DbConnection(string host, string port, string database, string user, string password)
        {
            this.ConnectionStatus = DbConnectionStatus.UNINITIALIZED;

            this.ConnectionString = "server=" + host + ";port=" + port + ";userid="
                + user + ";password=" + password + ";database=" + database;
            this.Db = new MySql.Data.MySqlClient.MySqlConnection(this.ConnectionString);

            try
            {
                this.Db.Open();
                this.ConnectionStatus = DbConnectionStatus.CONNECTED;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Authentication"))
                {
                    this.ConnectionStatus = DbConnectionStatus.UNAUTHORIZED;
                }
                else
                {
                    this.ConnectionStatus = DbConnectionStatus.UNCONNECTED;
                }
                this.LastErrMsg = ex.Message;
            }
        }

        /// <summary>
        /// Constructs a DbConnection from the given config. The following keys
        /// are expected: db_host, db_port, db_database, db_user, db_password.
        /// </summary>
        /// <param name="conf">The config with the connection data</param>
        /// <returns>A DbConnection created from the given config</returns>
        public static DbConnection FromConfig(KeyValueConfigurationCollection conf)
        {
            return new DbConnection(
                conf["db_host"].Value,
                conf["db_port"].Value,
                conf["db_database"].Value,
                conf["db_user"].Value,
                conf["db_password"].Value
            );
        }

        /// <summary>
        /// Executes the given query with the given parameters and returns the
        /// result wrapped in a MySqlDataReader.
        /// NOTE: Errors in the query syntax (or other errors during execution)
        /// are not handled by the method, but are expected to be caught by the
        /// calling function.
        /// </summary>
        /// <param name="sql">The query</param>
        /// <param name="parameters">The parameters for the query. The keys must
        /// fit the placeholders in the query, otherwise it won't work. The syntax
        /// for parameters is the same as in the MySql library.</param>
        /// <returns>The query's result</returns>
        public MySqlDataReader Query(string sql, Dictionary<string, string> parameters)
        {
            MySqlCommand query = new MySqlCommand();
            query.Connection = Db;
            query.CommandText = sql;
            query.Prepare();

            foreach (KeyValuePair<string, string> p in parameters)
            {
                query.Parameters.AddWithValue(p.Key, p.Value);
            }

            return query.ExecuteReader();
        }
    }
}
