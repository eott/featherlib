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
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public User(int id, string email, string name)
        {
            this.UserId = id;
            this.Email = email;
            this.Name = name;
        }
        public static User FromResultSet(ResultSet data)
        {
            return new User(
                data.GetInt32(0),
                data.GetString(1),
                data.GetString(2)
            );
        }

        public static string GetSelectQuery(bool singular)
        {
            string sql = @"
                SELECT user_id, email, user_name
                FROM user u
            ";

            if (singular)
            {
                sql += "WHERE user_id = :id";
            }

            return sql;
        }
    }
}
