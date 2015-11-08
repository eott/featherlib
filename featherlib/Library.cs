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

        public static Library fromResultSet(ResultSet data)
        {
            return new Library(
                data.getInt32(0),
                data.getInt32(1),
                data.getDateTime(2),
                data.getString(3)
            );
        }

        public static string getSelectQuery(bool singular)
        {
            string sql = @"
                SELECT library_id, owner_id, created, name
                FROM library l
            ";

            if (singular)
            {
                sql += "WHERE library_id = :id";
            }

            return sql;
        }
    }
}
