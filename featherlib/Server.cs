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
    }
}
