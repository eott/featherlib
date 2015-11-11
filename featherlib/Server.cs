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
        public DbConnection Db { get; set; }

        public Server(DbConnection db)
        {
            this.Db = db;
        }

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
