using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Client
    {
        public ServerConnector Connector { get; set; }

        public Client(ServerConnector conn)
        {
            this.Connector = conn;
        }

        public List<Library> GetLibraries()
        {
            List<Library> list = new List<Library>();
            ResultSet result = this.Connector.GetResultSetFor(ObjectIdentifier.Library, new Dictionary<string, string>());
            while (result.Read())
            {
                Library lib = Library.FromResultSet(result);
                list.Add(lib);
            }
            return list;
        }
    }
}
