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
                        sql = @"
                            SELECT owner_id, created, name
                            FROM library l
                            WHERE l.library_id = :id
                        ";
                        pars["id"] = parameters["id"];
                    }
                    else
                    {
                        sql = @"
                            SELECT owner_id, created, name
                            FROM library l
                        ";
                    }
                    break;

                default:
                    throw new NotSupportedException("Given ObjectIdentifier is not supported.");
            }

            return this.db.query(sql, pars);
        }
    }
}
