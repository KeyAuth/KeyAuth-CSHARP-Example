using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyAuth
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            key.Text = "Key: " + Login.KeyAuthApp.user_data.key;
            expiry.Text = "Expiry: " + Login.KeyAuthApp.user_data.expiry;
            level.Text = "Level: " + Login.KeyAuthApp.user_data.level;
        }
    }
}
