using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Server
    {
        protected DbConnection db;

        public Server(DbConnection db)
        {
            this.db = db;
        }
    }
}
