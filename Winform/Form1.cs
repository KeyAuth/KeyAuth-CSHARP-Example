using KeyAuth;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformLoader
{
    public partial class Form1 : Form
    {
        string name = ""; // place your Application Name within the Quotes.
        string ownerid = ""; // place your OwnerID within the Quotes.
        string secret = ""; // place your Application Secret within the Quotes.

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            api.init(name, secret, ownerid);

            
            if (File.Exists("C:\\ProgramData\\keyauthkeysave.txt"))
            {
                string key = File.ReadAllText("C:\\ProgramData\\keyauthkeysave.txt");
                if (api.login(key, name, secret, ownerid))
                {
                    button1.Visible = false;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    button2.Visible = true;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(api.login(textBox1.Text, name, secret, ownerid))
            {
                button1.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
