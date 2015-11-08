using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class LibraryItem
    {
        public int libraryItemId { get; set; }

        public int libraryId { get; set; }

        public string name { get; set; }

        public LibraryItem(int id, int libraryId, string name)
        {
            this.libraryItemId = id;
            this.libraryId = libraryId;
            this.name = name;
        }

        public static LibraryItem fromResultSet(ResultSet data)
        {
            return new LibraryItem(
                data.getInt32(0),
                data.getInt32(1),
                data.getString(2)
            );
        }

        public static string getSelectQuery(bool singular)
        {
            string sql = @"
                SELECT library_item_id, library_id, name
                FROM library_item li
            ";

            if (!singular)
            {
                sql += "WHERE library_item_id = :id";
            }

            return sql;
        }
    }
}
