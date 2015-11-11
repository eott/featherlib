using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace featherlib
{
    public class DbConnection
    {
        public string ConnectionString { get; set; }

        public MySqlConnection Db { get; set; }

        public DbConnectionStatus ConnectionStatus { get; set; }

        public string LastErrMsg { get; set; }

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
