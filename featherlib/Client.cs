using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Client
    {
        protected Server server;

        public Client(Server serv)
        {
            this.server = serv;
        }
    }
}
