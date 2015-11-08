using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Library
    {
        public int id { get; set; }

        public int ownerId { get; set; }

        public DateTime created { get; set; }

        public string name { get; set; }

        public Library(int id, int userId, DateTime created, string name)
        {
            this.id = id;
            this.ownerId = userId;
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
                DateTime created = reader.GetDateTime(1);
                string name = reader.GetString(2);

                return new Library(id, userId, created, name);
            }
            else
            {
                throw new Exception("Library with name " + id.ToString() + " not found.");
            }
        }
    }
}
