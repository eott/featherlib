using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace featherlib
{
    public enum DbConnectionStatus
    {
        CONNECTED,
        UNAUTHORIZED,
        UNINITIALIZED,
        UNCONNECTED
    }

    public class DbConnection
    {
        public string connectionString { get; set; }

        public MySqlConnection db { get; set; }

        public DbConnectionStatus connectionStatus { get; set; }

        public string lastErrMsg { get; set; }

        public DbConnection(string host, string port, string database, string user, string password)
        {
            this.connectionStatus = DbConnectionStatus.UNINITIALIZED;

            this.connectionString = "server=" + host + ";port=" + port + ";userid="
                + user + ";password=" + password + "dad;database=" + database;
            this.db = new MySql.Data.MySqlClient.MySqlConnection(this.connectionString);

            try
            {
                this.db.Open();
                this.connectionStatus = DbConnectionStatus.CONNECTED;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Authentication"))
                {
                    this.connectionStatus = DbConnectionStatus.UNAUTHORIZED;
                }
                else
                {
                    this.connectionStatus = DbConnectionStatus.UNCONNECTED;
                }
                this.lastErrMsg = ex.Message;
            }
        }

        public static DbConnection fromConfig(KeyValueConfigurationCollection conf)
        {
            return new DbConnection(
                conf["db_host"].Value,
                conf["db_port"].Value,
                conf["db_database"].Value,
                conf["db_user"].Value,
                conf["db_password"].Value
            );
        }

        public MySqlDataReader query(string sql, Dictionary<string, string> parameters)
        {
            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
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
