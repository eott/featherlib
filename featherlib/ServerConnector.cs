using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Handles the communication between a Client and a Server instance. As the
    /// server might not necessary be part of the same process as the client, the
    /// communication is either via direct call or some form of network connection.
    /// The ServerConnector unifies the interface so the client doesn't need to know
    /// where the server is located and how to speak to it.
    /// </summary>
    public class ServerConnector
    {
        /// <summary>
        /// The Server the instance is connected to.
        /// </summary>
        public Server Server { get; set; }

        /// <summary>
        /// Constructor. Creates a ServerConnector working with a Server instance
        /// directly.
        /// </summary>
        /// <param name="server">The connected server instance to use</param>
        public ServerConnector(Server server)
        {
            this.Server = server;
        }

        /// <summary>
        /// Returns a ResultSet containing the data with for the given identifier
        /// with the given parameters. For example a call for identifier
        /// Library and with a parameter called 'id' would return a
        /// MySqlDataReader with one row containing the data for the
        /// queried library.
        /// 
        /// You can find the necessary parameters for a query in the class
        /// corresponding to the identifier, as these classes are responsible
        /// to have the queries ready, that selects them from the database.
        /// </summary>
        /// <param name="ident">The identifier for the requested object class</param>
        /// <param name="parameters">The parameters for the query</param>
        /// <returns>A ResultSet containing the requested data</returns>
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
