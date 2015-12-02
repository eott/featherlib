using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Represents an overarching pool of items, from which collections
    /// can be created.
    /// </summary>
    public class Library
    {
        /// <summary>
        /// The ID field.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The library's owner user ID.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// A timestamp when the library was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// A name for the library. This does not have to be a unique name and
        /// therefore should not be used as an identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The ID</param>
        /// <param name="userId">The owner's user ID</param>
        /// <param name="created">The timestamp when the library was created</param>
        /// <param name="name">The library's name</param>
        public Library(int id, int userId, DateTime created, string name)
        {
            this.Id = id;
            this.OwnerId = userId;
            this.Created = created;
            this.Name = name;
        }

        /// <summary>
        /// Creates a library from the given result set.
        /// </summary>
        /// <param name="data">The result set holding the data</param>
        /// <returns>A library with the result set's data</returns>
        public static Library FromResultSet(ResultSet data)
        {
            return new Library(
                data.GetInt32(0),
                data.GetInt32(1),
                data.GetDateTime(2),
                data.GetString(3)
            );
        }

        /// <summary>
        /// Returns the SQL query that selects libraries from the DB. If the
        /// singular parameter is true, returns a query that only
        /// selects a single library, identified by the parameter ':id'.
        /// </summary>
        /// <param name="singular">If true, returns a query to only select
        /// one library.</param>
        /// <returns>A SQL query to select libraries from the DB.</returns>
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
