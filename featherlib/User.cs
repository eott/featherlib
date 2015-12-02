using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Represents a user of the featherlib system, that can own libraries.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The ID field.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user's email address. These technically don't need to be unique,
        /// but it is a good idea to only allow one user per email anyway.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The username. These should not be used to identify a user, as the
        /// name is likely to change and not be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The user's ID.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="name">The username</param>
        public User(int id, string email, string name)
        {
            this.UserId = id;
            this.Email = email;
            this.Name = name;
        }

        /// <summary>
        /// Creates a user from the given result set.
        /// </summary>
        /// <param name="data">The result set holding the data</param>
        /// <returns>A user with the result set's data</returns>
        public static User FromResultSet(ResultSet data)
        {
            return new User(
                data.GetInt32(0),
                data.GetString(1),
                data.GetString(2)
            );
        }

        /// <summary>
        /// Returns the SQL query that selects users from the DB. If the
        /// singular parameter is true, returns a query that only
        /// selects a single user, identified by the parameter ':id'.
        /// </summary>
        /// <param name="singular">If true, returns a query to only select
        /// one user.</param>
        /// <returns>A SQL query to select users from the DB.</returns>
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
