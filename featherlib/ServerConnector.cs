using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class ServerConnector
    {
        public Server server { get; set; }

        public ServerConnector(Server server)
        {
            this.server = server;
        }

        public ResultSet getResultSetFor(ObjectIdentifier ident, Dictionary<string, string> parameters)
        {
            if (this.server != null)
            {
                return new ResultSet(this.server.getDataReaderFor(ident, parameters));
            } else
            {
                throw new NoServerConnectionException("Could not fetch result set because no server was set.");
            }
        }
    }
}
