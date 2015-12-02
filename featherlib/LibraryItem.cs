using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Represents an item in a library. Library items carry the base information
    /// of items independent of the collections they are in.
    /// </summary>
    public class LibraryItem
    {
        /// <summary>
        /// The ID of the library item.
        /// </summary>
        public int LibraryItemId { get; set; }

        /// <summary>
        /// The ID of the library the item belongs to.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// A name for the library item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The library item's ID</param>
        /// <param name="libraryId">The library's ID</param>
        /// <param name="name">The name of the library item</param>
        public LibraryItem(int id, int libraryId, string name)
        {
            this.LibraryItemId = id;
            this.LibraryId = libraryId;
            this.Name = name;
        }

        /// <summary>
        /// Constructs a library item from the given result set's data.
        /// </summary>
        /// <param name="data">The result set containing the data</param>
        /// <returns>A library item with the result set's data</returns>
        public static LibraryItem FromResultSet(ResultSet data)
        {
            return new LibraryItem(
                data.GetInt32(0),
                data.GetInt32(1),
                data.GetString(2)
            );
        }

        /// <summary>
        /// Returns the SQL query that selects library items from the DB. If the
        /// singular parameter is true, returns a query that only
        /// selects a single library item, identified by the parameter ':id'.
        /// </summary>
        /// <param name="singular">If true, returns a query to only select
        /// one library item.</param>
        /// <returns>A SQL query to select library items from the DB.</returns>
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
