using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace featherlib
{
    class DbConnection
    {
        protected string connectionString;

        protected MySqlConnection db;

        public DbConnection(string host, string port, string database, string user, string password)
        {
            this.connectionString = "server=" + host + ";port=" + port + ";userid="
                + user + ";password=" + password + ";database=" + database;
            this.db = new MySql.Data.MySqlClient.MySqlConnection(this.connectionString);
            this.db.Open();
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
    }
}
