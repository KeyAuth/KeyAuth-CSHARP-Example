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
        * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=RfDTdiBq4_o
        * 
        * READ HERE TO LEARN ABOUT KEYAUTH FUNCTIONS https://github.com/KeyAuth/KeyAuth-CSHARP-Example#keyauthapp-instance-definition
        *
        */

        public static api KeyAuthApp = new api(
            name: "",
            ownerid: "",
            secret: "",
            version: "1.0"/*,
	    path: @"PathToCheckToken" NOTE: THE "@" IS IF THE TOKEN.TXT FILE IS IN THE SAME DIRECTORY AS THE .EXE*/
        );

        // This will display how long it took to make a request in ms. The param "type" is for "login", "register", "init", etc... but that is optional, as well as this function. Ideally you can just put Console.WriteLine($"Request took {api.responseTime}"), but either works. 
        // if you would like to use this method, simply put it in any function and pass the param ... ShowResponse("TypeHere");
        private void ShowResponse(string type)
        {
            Console.WriteLine($"It took {api.responseTime} ms to {type}");
        }

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

            Console.Write("\n [1] Login\n [2] Register\n [3] Upgrade\n [4] License key only\n [5] Forgot password\n\n Choose option: ");

            string username, password, key, email;

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.Write("\n\n Enter password: ");
                    password = Console.ReadLine();
                    KeyAuthApp.login(username, password);
                    break;
                case 2:
                    Console.Write("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.Write("\n\n Enter password: ");
                    password = Console.ReadLine();
                    Console.Write("\n\n Enter license: ");
                    key = Console.ReadLine();
                    Console.Write("\n\n Enter email (just press enter if none): ");
                    email = Console.ReadLine();
                    KeyAuthApp.register(username, password, key, email);
                    break;
                case 3:
                    Console.Write("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.Write("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.upgrade(username, key);
                    // don't proceed to app, user hasn't authenticated yet.
                    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.Write("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.license(key);
                    break;
                case 5:
                    Console.Write("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.Write("\n\n Enter email: ");
                    email = Console.ReadLine();
                    KeyAuthApp.forgot(username, email);
                    // don't proceed to app, user hasn't authenticated yet.
                    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\n Invalid Selection");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                    break; // no point in this other than to not get error from IDE
            }

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(2500);
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

            Console.WriteLine("\n Closing in five seconds...");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        public static bool SubExist(string name)
        {
            if(KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == name))
                return true;
            return false;
        }
		
        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
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
