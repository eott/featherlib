using MySql.Data.MySqlClient;
using MySql.Data.Types;
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

        protected int id;

        protected User owner;

        protected MySqlDateTime created;

        public Library(DbConnection db, int id, User owner, MySqlDateTime created)
        {
            this.db = db;
        }

        public static Library fromDatabase(DbConnection db, string name)
        {
            string sql = @"
                SELECT library_id, owner_id, created
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
                int libId = reader.GetInt32(0);
                int userId = reader.GetInt32(1);
                MySqlDateTime created = reader.GetMySqlDateTime(2);
                User owner = User.fromDatabase(db, userId);

                return new Library(db, libId, owner, created);
            }
            else
            {
                throw new Exception("Library with name \"" + name + "\" not found.");
            }
        }
    }
}
