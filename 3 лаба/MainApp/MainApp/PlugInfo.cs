using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp
{
    public partial class InfoForm : Form
    {
        public InfoForm(List<string> plugInfo)
        {
            InitializeComponent();
            PrintPlugins(plugInfo);
        }

        private void PrintPlugins(List<string> plugInfo)
        {
            foreach (var p in plugInfo)
            {
                pluginListBox.Items.Add(p);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
