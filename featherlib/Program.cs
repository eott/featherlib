using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace featherlib
{
    /// <summary>
    /// The program's main class, containing the main() entry point. The code in
    /// this class binds all components together and bootstraps all required
    /// elements on startup.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;

            DbConnection connection = DbConnection.FromConfig(settings);
            Server server = new Server(connection);
            ServerConnector connector = new ServerConnector(server);
            Client client = new Client(connector);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main(client));
        }
    }
}
