using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class Client
    {
        public ServerConnector connector { get; set; }

        public Client(ServerConnector conn)
        {
            this.connector = conn;
        }

        public List<Library> getLibraries()
        {
            List<Library> list = new List<Library>();
            ResultSet result = this.connector.getResultSetFor(ObjectIdentifier.Library, new Dictionary<string, string>());
            while (result.read())
            {
                Library lib = Library.fromResultSet(result);
                list.Add(lib);
            }
            return list;
        }
    }
}
