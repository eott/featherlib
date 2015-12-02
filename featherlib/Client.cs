using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Handles the data transfer between components on the client side and their
    /// persistence on the server side. This allows that both the server implementation
    /// and the connection interface to the server are hidden from the components.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The server connector for communication between the client
        /// and the server.
        /// </summary>
        public ServerConnector Connector { get; set; }

        /// <summary>
        /// Constructor for Client.
        /// </summary>
        /// <param name="conn">The server connector the client should be
        /// using.</param>
        public Client(ServerConnector conn)
        {
            this.Connector = conn;
        }

        /// <summary>
        /// Fetches a list of all libraries from the ServerConnector interface.
        /// </summary>
        /// <returns>A list of all libraries.</returns>
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
