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
    public partial class Login : Form
    {

        /*
        * 
        * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=RfDTdiBq4_o
        * 
        */

        static string name = "";
        static string ownerid = "";
        static string secret = "";
        static string version = "1.0";
        
                    /*
            Optional Functions:
            
            KeyAuthApp.webhook("lfvbBrbFhIr", "?sellerkey=CUqDqlCIgl&type=resethash");
            // send secure request to webhook which is impossible to crack into. the base link set on the website is https://keyauth.com/api/seller/, which nobody except you can see, so the final request is https://keyauth.com/api/seller/?sellerkey=CUqDqlCIgl&type=resethash
            
            KeyAuthApp.download("231696", "C:\\ok.dll"); // download an application file

            MessageBox.Show(KeyAuthApp.var("123456")); // retrieve application variable
            */

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        public Login()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if(KeyAuthApp.login(key.Text))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
        }
    }
}
