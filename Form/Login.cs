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
            name: "", // Application Name
            ownerid: "", // Owner ID
            secret: "", // Application Secret
            version: "" // Application Version /*
                           //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
        );

        //This will display how long it took to make a request in ms. The param "type" is for "login", "register", "init", etc... but that is optional, as well as this function. Ideally you can just put a label or MessageBox.Show($"Request took {api.responseTime}"), but either works. 
        // if you would like to use this method, simply put it in any function and pass the param ... ShowResponse("TypeHere");
        private void ShowResponse(string type)
        {
            //responseTimeLbl.Text = $"It took {api.responseTime} ms to {type}"; // you need to create a label called responseTimeLbl to display to a label.
            MessageBox.Show($"It took {api.responseTime} msg to {type}");
        }

        public Login()
        {
            InitializeComponent();
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

        private void Login_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();

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
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeyAuthApp.forgot(usernameField.Text, emailField.Text);
            MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeyAuthApp.upgrade(usernameField.Text, keyField.Text); // success is set to false so people can't press upgrade then press login and skip logging in. it doesn't matter, since you shouldn't take any action on succesfull upgrade anyways. the only thing that needs to be done is the user needs to see the message from upgrade function
            MessageBox.Show("Status: " + KeyAuthApp.response.message);
            // don't login, because they haven't authenticated. this is just to extend expiry of user with new key.
        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            KeyAuthApp.login(usernameField.Text, passwordField.Text);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string email = this.emailField.Text;
            if (email == "Email (leave blank if none)")
            { // default value
                email = null;
            }

            KeyAuthApp.register(usernameField.Text, passwordField.Text, keyField.Text, email);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Status: " + KeyAuthApp.response.message);
        }

        private void licenseBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.license(keyField.Text);
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
