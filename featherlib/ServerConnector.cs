using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class ServerConnector
    {
        public Server Server { get; set; }

        public ServerConnector(Server server)
        {
            this.Server = server;
        }

        public ResultSet GetResultSetFor(ObjectIdentifier ident, Dictionary<string, string> parameters)
        {
            if (this.Server != null)
            {
                return new ResultSet(this.Server.GetDataReaderFor(ident, parameters));
            } else
            {
                throw new NoServerConnectionException("Could not fetch result set because no server was set.");
            }
        }
    }
}
