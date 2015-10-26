using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    class User
    {
        protected DbConnection db;

        protected int userId;

        protected string email;

        protected string name = "";

        public User(DbConnection db, int id, string email, string name)
        {
            this.db = db;
            this.userId = id;
            this.email = email;
            this.name = name;
        }

        public static User fromDatabase(DbConnection db, string email)
        {
            string sql = @"
                SELECT u.user_id, u.email, u.user_name
                FROM user u
                WHERE u.email = :email
                LIMIT 1
            ";

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {":email", email}
            };

            MySqlDataReader reader = db.query(sql, parameters);

            if (reader.Read())
            {
                int userId = reader.GetInt32(0);
                string name = reader.GetString(2);
                return new User(db, userId, email, name);
            }
            else
            {
                throw new Exception("User with email \"" + email + "\" not found.");
            }
        }
    }
}
