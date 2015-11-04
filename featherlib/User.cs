using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class User
    {
        protected int userId;

        protected string email;

        protected string name = "";

        public User(int id, string email, string name)
        {
            this.userId = id;
            this.email = email;
            this.name = name;
        }

        protected static User fromDatabase(DbConnection db, int id, string email)
        {
            // @TODO: Replace this with a constructed query as they differ only in the
            // where clause and parameters
            string sql = "";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (id == 0)
            {
                sql = @"
                SELECT u.user_id, u.email, u.user_name
                FROM user u
                WHERE u.email = :email
                LIMIT 1
                ";
                parameters[":id"] = id.ToString();
            }
            else
            {
                sql = @"
                SELECT u.user_id, u.email, u.user_name
                FROM user u
                WHERE u.email = :email
                LIMIT 1
                ";
                parameters[":email"] = email;
            }

            MySqlDataReader reader = db.query(sql, parameters);

            if (reader.Read())
            {
                int userId = reader.GetInt32(0);
                string name = reader.GetString(2);
                return new User(userId, email, name);
            }
            else
            {
                throw new Exception("User with email \"" + email + "\" not found.");
            }
        }

        public static User fromDatabase(DbConnection db, int id)
        {
            return User.fromDatabase(db, id, "");
        }

        public static User fromDatabase(DbConnection db, string email)
        {
            return User.fromDatabase(db, 0, email);
        }
    }
}
