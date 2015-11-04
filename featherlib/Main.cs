using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace featherlib
{
    public partial class main : Form
    {
        protected Client client;

        public main(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_Load(object sender, EventArgs e)
        {
            foreach (Library lib in this.client.getLibraries())
            {
                nav_tree.Nodes.Add(new TreeNode(lib.ToString()));
            }
        }
    }
}
