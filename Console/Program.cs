using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace KeyAuth
{
    class Program
    {

        /*
         * 
         * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=UXRkNEvgxJU
         * 
         */

        public static api KeyAuthApp = new api(
            name: "",
            ownerid: "",
            secret: "",
            version: "1.0"
        );

        static void Main(string[] args)
        {
            Console.Title = "Loader";
            Console.WriteLine("\n\n Connecting..");
            KeyAuthApp.init();

            autoUpdate();

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            // app data
            Console.WriteLine("\n App data:");
            Console.WriteLine(" Number of users: " + KeyAuthApp.app_data.numUsers);
            Console.WriteLine(" Number of online users: " + KeyAuthApp.app_data.numOnlineUsers);
            Console.WriteLine(" Number of keys: " + KeyAuthApp.app_data.numKeys);
            Console.WriteLine(" Application Version: " + KeyAuthApp.app_data.version);
            Console.WriteLine(" Customer panel link: " + KeyAuthApp.app_data.customerPanelLink);
            KeyAuthApp.check();
            Console.WriteLine($" Current Session Validation Status: {KeyAuthApp.response.message}"); // you can also just check the status but ill just print the message

            Console.WriteLine("\n [1] Login\n [2] Register\n [3] Upgrade\n [4] License key only\n\n Choose option: ");

            string username;
            string password;
            string key;

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\n\n Enter password: ");
                    password = Console.ReadLine();
                    KeyAuthApp.login(username, password);
                    break;
                case 2:
                    Console.WriteLine("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\n\n Enter password: ");
                    password = Console.ReadLine();
                    Console.WriteLine("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.register(username, password, key);
                    break;
                case 3:
                    Console.WriteLine("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.upgrade(username, key);
                    break;
                case 4:
                    Console.WriteLine("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.license(key);
                    break;
                default:
                    Console.WriteLine("\n\n Invalid Selection");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                    break; // no point in this other than to not get error from IDE
            }

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }

            Console.WriteLine("\n Logged In!"); // at this point, the client has been authenticated. Put the code you want to run after here

            // user data
            Console.WriteLine("\n User data:");
            Console.WriteLine(" Username: " + KeyAuthApp.user_data.username);
            Console.WriteLine(" IP address: " + KeyAuthApp.user_data.ip);
            Console.WriteLine(" Hardware-Id: " + KeyAuthApp.user_data.hwid);
            Console.WriteLine(" Created at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.createdate)));
            if (!String.IsNullOrEmpty(KeyAuthApp.user_data.lastlogin)) // don't show last login on register since there is no last login at that point
                Console.WriteLine(" Last login at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.lastlogin)));
            Console.WriteLine(" Your subscription(s):");
            for (var i = 0; i < KeyAuthApp.user_data.subscriptions.Count; i++)
            {
                Console.WriteLine(" Subscription name: " + KeyAuthApp.user_data.subscriptions[i].subscription + " - Expires at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.subscriptions[i].expiry)) + " - Time left in seconds: " + KeyAuthApp.user_data.subscriptions[i].timeleft);
            }
			var onlineUsers = KeyAuthApp.fetchOnline();
            if (onlineUsers != null)
            {
                Console.Write("\n Online users: ");
                foreach (var user in onlineUsers)
                {
                    Console.Write(user.credential + ", ");
                }
                Console.WriteLine("\n");
            }

            /*
                KeyAuthApp.web_login();

                Console.WriteLine("\n Waiting for button to be clicked");
                KeyAuthApp.button("close");
            */

            #region extras
            /*
            // set user variable 'discord' to 'test#0001' (if the user variable with name 'discord' doesn't exist, it'll be created)
            KeyAuthApp.setvar("discord", "test#0001");
            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("\n Successfully set user variable");
            */

            /*
            // See if Subscription exists with name
            if (SubExist("default", KeyAuthApp.user_data.subscriptions.Count))
            {
                Console.WriteLine(" Default Subscription Exists");
            }
            // See if another sub exists with name 
            if (SubExist("premium", KeyAuthApp.user_data.subscriptions.Count))
            {
                Console.WriteLine(" Premium Subscription Exists");
            }

            */

            /*
            // display the user variable 'discord'
            string uservar = KeyAuthApp.getvar("discord");
            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("\n User variable value: " + uservar);
            */

            // KeyAuthApp.log("user logged in"); // log text to website and discord webhook (if set)

            /*
            // let's say you want to send request to https://keyauth.win/api/seller/?sellerkey=sellerkeyhere&type=black&ip=1.1.1.1&hwid=abc
            // but doing that from inside the loader is a bad idea as the link could get leaked.
            // Instead, you should create a webhook with the https://keyauth.win/api/seller/?sellerkey=sellerkeyhere&type=black part as the URL
            // then in your loader, put the rest of the link (the other paramaters) in your loader. And then it will send request from KeyAuth server and return response in string resp

            // example to send normal request with no POST data
            string resp = KeyAuthApp.webhook("7kR0UedlVI", "&ip=1.1.1.1&hwid=abc");

            // example to send form data
            resp = KeyAuthApp.webhook("7kR0UedlVI", "", "type=init&name=test&ownerid=j9Gj0FTemM", "application/x-www-form-urlencoded");

            // example to send JSON
            resp = KeyAuthApp.webhook("7kR0UedlVI", "", "{\"content\": \"webhook message here\",\"embeds\": null}", "application/json"); // if Discord webhook message successful, response will be empty

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("\n Response recieved from webhook request: " + resp);
            */

            /*
            // downloads application file to current folder Loader is running, feel free to change to whatever.
            byte[] result = KeyAuthApp.download("385624");
            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            else
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\test.txt", result);
            */

            /*
            string appvar = KeyAuthApp.var("test");
            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("\n App variable data: " + appvar);
            */

            // KeyAuthApp.ban(); // ban the current user, must be logged in
            #endregion extras
            KeyAuthApp.check();
            Console.WriteLine($" Current Session Validation Status: {KeyAuthApp.response.message}"); // you can also just check the status but ill just print the message
            Console.WriteLine("\n Closing in ten seconds...");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }

        public static bool SubExist(string name, int len)
        {
            for (var i = 0; i < len; i++)
            {
                if (KeyAuthApp.user_data.subscriptions[i].subscription == name)
                {
                    return true;
                }
            }
            return false;
        }

        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        static void autoUpdate()
        {
            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    Console.WriteLine("\n Auto update avaliable!");
                    Console.WriteLine(" Choose how you'd like to auto update:");
                    Console.WriteLine(" [1] Open file in browser");
                    Console.WriteLine(" [2] Download file directly");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            Environment.Exit(0);
                            break;
                        case 2:
                            Console.WriteLine(" Downloading file directly..");
                            Console.WriteLine(" New file will be opened shortly..");

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
                            Console.WriteLine(" Invalid selection, terminating program..");
                            Thread.Sleep(1500);
                            Environment.Exit(0);
                            break;
                    }
                }
                Console.WriteLine("\n Status: Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer.");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }
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
    }
}
