using Loader;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace KeyAuth
{
    public partial class Login : Form
    {

        /*
        * 
        * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=RfDTdiBq4_o
        * 
		 * READ HERE TO LEARN ABOUT KEYAUTH FUNCTIONS https://github.com/KeyAuth/KeyAuth-CSHARP-Example#keyauthapp-instance-definition
		 *
        */

        public static api KeyAuthApp = new api(
             name: "", // App name
             ownerid: "", // Account ID
             version: "1" // Application version. Used for automatic downloads see video here https://www.youtube.com/watch?v=kW195PLCBKs
                            //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
         );

        public Login()
        {
            InitializeComponent();
            Drag.MakeDraggable(this);
        }

        #region Misc References
        public static bool SubExist(string name)
        {
            if(KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == name))
                return true;
            return false;
        }

        static string random_string()
        {
            string str = null;

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                str += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
            }
            return str;

        }
        #endregion

        private async void Login_Load(object sender, EventArgs e)
        {
            await KeyAuthApp.init();

            #region Auto Update
            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            Environment.Exit(0);
                            break;
                        case DialogResult.No:
                            WebClient webClient = new WebClient();
                            string destFile = Application.ExecutablePath;

                            string rand = random_string();

                            destFile = destFile.Replace(".exe", $"-{rand}.exe");
                            webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                            Process.Start(destFile);
                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });
                            Environment.Exit(0);

                            break;
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Environment.Exit(0);
            }
            #endregion

	     if (!KeyAuthApp.response.success)
	     {
	        MessageBox.Show(KeyAuthApp.response.message);
	        Environment.Exit(0);
	     }
        }
        
        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await KeyAuthApp.forgot(usernameField.Text, emailField.Text);
            MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private async void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await KeyAuthApp.upgrade(usernameField.Text, keyField.Text); // success is set to false so people can't press upgrade then press login and skip logging in. it doesn't matter, since you shouldn't take any action on succesfull upgrade anyways. the only thing that needs to be done is the user needs to see the message from upgrade function
            MessageBox.Show("Status: " + KeyAuthApp.response.message);
            // don't login, because they haven't authenticated. this is just to extend expiry of user with new key.
        }

        private async void loginBtn_Click_1(object sender, EventArgs e)
        {
            await KeyAuthApp.login(usernameField.Text, passwordField.Text, tfaField.Text);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            string email = this.emailField.Text;
            if (email == "Email (leave blank if none)")
            { // default value
                email = null;
            }

            await KeyAuthApp.register(usernameField.Text, passwordField.Text, keyField.Text, email);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private async void licenseBtn_Click(object sender, EventArgs e)
        {
            await KeyAuthApp.license(keyField.Text, tfaField.Text);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
               MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
