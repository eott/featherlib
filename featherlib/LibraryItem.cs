using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class LibraryItem
    {
        public int LibraryItemId { get; set; }

        public int LibraryId { get; set; }

        public string Name { get; set; }

        public LibraryItem(int id, int libraryId, string name)
        {
            this.LibraryItemId = id;
            this.LibraryId = libraryId;
            this.Name = name;
        }

        public static LibraryItem FromResultSet(ResultSet data)
        {
            return new LibraryItem(
                data.GetInt32(0),
                data.GetInt32(1),
                data.GetString(2)
            );
        }

        public static string GetSelectQuery(bool singular)
        {
            string sql = @"
                SELECT library_item_id, library_id, name
                FROM library_item li
            ";

            if (singular)
            {
                sql += "WHERE library_item_id = :id";
            }

            return sql;
        }
    }
}
