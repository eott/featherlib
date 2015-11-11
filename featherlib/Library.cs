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
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public Library(int id, int userId, DateTime created, string name)
        {
            this.Id = id;
            this.OwnerId = userId;
            this.Created = created;
            this.Name = name;
        }

        public static Library FromResultSet(ResultSet data)
        {
            return new Library(
                data.GetInt32(0),
                data.GetInt32(1),
                data.GetDateTime(2),
                data.GetString(3)
            );
        }

        public static string GetSelectQuery(bool singular)
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
