using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public enum ObjectIdentifier
    {
        Library,
        LibraryItem,
        User
    }

    public class ServerConnector
    {
        public Server server { get; set; }

        public ServerConnector(Server server)
        {
            this.server = server;
        }
    }
}
