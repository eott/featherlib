using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Server
    {
        public DbConnection db { get; set; }

        public Server(DbConnection db)
        {
            this.db = db;
        }

        public MySqlDataReader getDataReaderFor(ObjectIdentifier ident, Dictionary<string, string> parameters)
        {
            string sql = "";
            Dictionary<string, string> pars = new Dictionary<string, string>();

            switch (ident)
            {
                case ObjectIdentifier.Library:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = Library.getSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = Library.getSelectQuery(false);
                    }
                    break;

                case ObjectIdentifier.LibraryItem:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = LibraryItem.getSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = LibraryItem.getSelectQuery(false);
                    }
                    break;

                case ObjectIdentifier.User:
                    if (parameters.ContainsKey("id"))
                    {
                        sql = User.getSelectQuery(true);
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = User.getSelectQuery(false);
                    }
                    break;

                default:
                    throw new NotSupportedException("Given ObjectIdentifier is not supported.");
            }

            return this.db.query(sql, pars);
        }
    }
}
