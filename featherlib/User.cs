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
        public int userId { get; set; }

        public string email { get; set; }

        public string name { get; set; }

        public User(int id, string email, string name)
        {
            this.userId = id;
            this.email = email;
            this.name = name;
        }
        public static User fromResultSet(ResultSet data)
        {
            return new User(
                data.getInt32(0),
                data.getString(1),
                data.getString(2)
            );
        }

        public static string getSelectQuery(bool singular)
        {
            string sql = @"
                SELECT user_id, email, user_name
                FROM user u
            ";

            if (!singular)
            {
                sql += "WHERE user_id = :id";
            }

            return sql;
        }
    }
}
