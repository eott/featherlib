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

        protected string name;

        public Library(DbConnection db, int id, User owner, MySqlDateTime created, string name)
        {
            this.db = db;
            this.id = id;
            this.owner = owner;
            this.created = created;
            this.name = name;
        }

        public static Library fromDatabase(DbConnection db, int id)
        {
            string sql = @"
                SELECT owner_id, created, name
                FROM library l
                WHERE l.library_id = :id
            ";

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {":id", id.ToString()}
            };

            MySqlDataReader reader = db.query(sql, parameters);

            if (reader.Read())
            {
                int userId = reader.GetInt32(0);
                MySqlDateTime created = reader.GetMySqlDateTime(1);
                string name = reader.GetString(2);
                User owner = User.fromDatabase(db, userId);

                return new Library(db, id, owner, created, name);
            }
            else
            {
                throw new Exception("Library with name " + id.ToString() + " not found.");
            }
        }
    }
}
