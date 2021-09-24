using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
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

        static string name = ""; // application name. right above the blurred text aka the secret on the licenses tab among other tabs
        static string ownerid = ""; // ownerid, found in account settings. click your profile picture on top right of dashboard and then account settings.
        static string secret = ""; // app secret, the blurred text on licenses tab and other tabs
        static string version = "1.0"; // leave alone unless you've changed version on website

        /*
        Optional Functions:
        
        KeyAuthApp.webhook("lfvbBrbFhIr", "?sellerkey=CUqDqlCIgl&type=resethash");
        // send secure request to webhook which is impossible to crack into. the base link set on the website is https://keyauth.com/api/seller/, which nobody except you can see, so the final request is https://keyauth.com/api/seller/?sellerkey=CUqDqlCIgl&type=resethash
        
        // byte[] result = KeyAuthApp.download("902901"); // downloads application file
        // File.WriteAllBytes("C:\\Users\\mak\\Downloads\\KeyAuth-CSHARP-Example-main (5)\\KeyAuth-CSHARP-Example-main\\ConsoleExample\\bin\\Debug\\countkeys.txt", result);
        
        MessageBox.Show(KeyAuthApp.var("123456")); // retrieve application variable
        */

        // KeyAuthApp.register("username", "password", "key");
        //KeyAuthApp.login("username", "password"); 

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        public Login()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
        }

        private void UpgradeBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.upgrade(username.Text, key.Text);
            // don't login, because they haven't authenticated. this is just to extend expiry with new key.
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (KeyAuthApp.login(username.Text,password.Text))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        private void RgstrBtn_Click(object sender, EventArgs e)
        {
            if (KeyAuthApp.register(username.Text, password.Text, key.Text))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        private void LicBtn_Click(object sender, EventArgs e)
        {
            if (KeyAuthApp.license(key.Text))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }
    }
}
