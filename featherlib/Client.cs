using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Client
    {
        public Server server { get; set; }

        public Client(Server serv)
        {
            this.server = serv;
        }

        public List<Library> getLibraries()
        {
            List<Library> list = new List<Library>();
            return list;
        }
    }
}
