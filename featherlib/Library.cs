using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    class Library
    {
        protected DbConnection db;

        public Library(DbConnection db)
        {
            this.db = db;
        }

        public static Library fromDatabase(DbConnection db, string name)
        {
            // Test functionality
            string sql = @"
                SELECT *
                FROM library l
                WHERE l.name = :name
                LIMIT 1
            ";

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {":name", name}
            };

            MySqlDataReader reader = db.query(sql, parameters);

            if (reader.Read())
            {
                return new Library(db);
            } else
            {
                throw new Exception("Library with name \"" + name + "\" not found.");
            }
        }
    }
}
