using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Handles all requests to and from the data storage. The server should be
    /// the only interface towards the data storage so it becomes easy to switch
    /// from one technology (e.g. a remote MySql database) to another (e.g. a
    /// local Sqlite database) without impacting other components of the system.
    /// This is somewhat muddied by the fact that vastly different storage
    /// technologies might require a different query syntax or other conditions
    /// than SQL variants. However the most important support is for both remote
    /// and local SQL databases as the whole system must be runnable either as
    /// a client, a server and a client or just a server.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// The database connection from/to which we transfer the data.
        /// </summary>
        public DbConnection Db { get; set; }

        /// <summary>
        /// Constructor. Creates a Server instance working with the given
        /// database connection.
        /// </summary>
        /// <param name="db">The connection to the database</param>
        public Server(DbConnection db)
        {
            this.Db = db;
        }

        /// <summary>
        /// Returns a MySqlDataReader containing the data for the given
        /// identifier and parameters. For example a call for identifier
        /// Library and with a parameter called 'id' would return a
        /// MySqlDataReader with one row containing the data for the
        /// queried library.
        /// 
        /// You can find the necessary parameters for a query in the class
        /// corresponding to the identifier, as these classes are responsible
        /// to have the queries ready, that selects them from the database.
        /// </summary>
        /// <param name="ident">The identifier for the object class</param>
        /// <param name="parameters">The parameters for the query</param>
        /// <returns>A MySqlDataReader with the requested data</returns>
        public MySqlDataReader GetDataReaderFor(ObjectIdentifier ident, Dictionary<string, string> parameters)
        {
            string sql = "";
            Dictionary<string, string> pars = new Dictionary<string, string>();

            switch (ident)
            {
                case ObjectIdentifier.Library:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = Library.GetSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = Library.GetSelectQuery(false);
                    }
                    break;

                case ObjectIdentifier.LibraryItem:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = LibraryItem.GetSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = LibraryItem.GetSelectQuery(false);
                    }
                    break;

                case ObjectIdentifier.User:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = User.GetSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = User.GetSelectQuery(false);
                    }
                    break;

                default:
                    throw new NotSupportedException("Given ObjectIdentifier is not supported.");
            }

            return this.Db.Query(sql, pars);
        }
    }
}
