using System;
using System.Threading;

namespace KeyAuth
{
    class Program
    {

        /*
         * 
         * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=UXRkNEvgxJU
         * 
         */

        static string name = ""; // application name. right above the blurred text aka the secret on the licenses tab among other tabs
        static string ownerid = ""; // ownerid, found in account settings. click your profile picture on top right of dashboard and then account settings.
        static string secret = ""; // app secret, the blurred text on licenses tab and other tabs
        static string version = "1.0"; // leave alone unless you've changed version on website

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        static void Main(string[] args)
        {
            string username;
            string password;
            string key;

            username = Loader.Properties.Settings.Default.userName;
            password = Loader.Properties.Settings.Default.userPassword;
            key = Loader.Properties.Settings.Default.userKey;
            Console.Title = "Loader";
            Console.WriteLine("\n\n Connecting..");
            KeyAuthApp.init();

            //if (!KeyAuthApp.response.success)
            //{
            //    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
            //    Thread.Sleep(1500);
            //    Environment.Exit(0);
            //}

            // app data
            Console.WriteLine("\n App data:");
            Console.WriteLine(" Number of users: " + KeyAuthApp.app_data.numUsers);
            Console.WriteLine(" Number of online users: " + KeyAuthApp.app_data.numOnlineUsers);
            Console.WriteLine(" Number of keys: " + KeyAuthApp.app_data.numKeys);
            Console.WriteLine(" Application Version: " + KeyAuthApp.app_data.version);
            Console.WriteLine(" Customer panel link: " + KeyAuthApp.app_data.customerPanelLink);

            Console.WriteLine("\n [1] Login\n [2] Register\n [3] Upgrade\n [4] License key only\n\n Choose option: ");


            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    if (Loader.Properties.Settings.Default.userKey != null)
                    {
                        Console.WriteLine("\n\n Previous UserName , Password Is Added ");
                        username = Loader.Properties.Settings.Default.userName;
                        password = Loader.Properties.Settings.Default.userPassword;
                        KeyAuthApp.login(username, password);
                    }
                    if(!KeyAuthApp.response.success)
                    {
                        Console.WriteLine("\n\n (Previous UserName and Password Cant be Found) Please Enter Your UserName and Password: ");
                        Console.WriteLine("\n\n Enter username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("\n\n Enter password: ");
                        password = Console.ReadLine();
                        KeyAuthApp.login(username, password);
                    }
                    if (KeyAuthApp.response.success)
                    {
                        Loader.Properties.Settings.Default.userName = username;
                        Loader.Properties.Settings.Default.userPassword = password;
                        Loader.Properties.Settings.Default.Save();
                    }
                    break;

                case 2:
                    Console.WriteLine("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\n\n Enter password: ");
                    password = Console.ReadLine();
                    Console.WriteLine("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.register(username, password, key);
                    if (KeyAuthApp.response.success)
                    {
                        Loader.Properties.Settings.Default.userName = username;
                        Loader.Properties.Settings.Default.userPassword = password;
                        Loader.Properties.Settings.Default.userKey = key;
                        Loader.Properties.Settings.Default.Save();
                    }

                    break;
                case 3:
                    Console.WriteLine("\n\n Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\n\n Enter license: ");
                    key = Console.ReadLine();
                    KeyAuthApp.upgrade(username, key);
                    break;
                case 4:       
                    if (Loader.Properties.Settings.Default.userKey != null)
                    {
                        Console.WriteLine("\n\n Previous Key : ");
                        Console.Write(Loader.Properties.Settings.Default.userKey);
                        key = Loader.Properties.Settings.Default.userKey;
                        KeyAuthApp.license(key);
                    }
                    if(!KeyAuthApp.response.success)
                    {
                        Console.WriteLine("\n\n (Previous license is not working) Enter New license: ");
                        key = Console.ReadLine();
                        KeyAuthApp.license(key);
                    }
                    if (KeyAuthApp.response.success)
                    {
                        Loader.Properties.Settings.Default.userKey = key;
                        Loader.Properties.Settings.Default.Save();
                    }
                    break;
                default:
                    Console.WriteLine("\n\n Invalid Selection");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                    break; // no point in this other than to not get error from IDE
            }

            if(!KeyAuthApp.response.success)
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
            // let's say you want to send request to https://keyauth.com/api/seller/?sellerkey=f43795eb89d6060b74cdfc56978155ef&type=black&ip=1.1.1.1&hwid=abc
            // but doing that from inside the loader is a bad idea as the link could get leaked.
            // Instead, you should create a webhook with the https://keyauth.com/api/seller/?sellerkey=f43795eb89d6060b74cdfc56978155ef part as the URL
            // then in your loader, put the rest of the link (the other paramaters) in your loader. And then it will send request from KeyAuth server and return response in string resp

            // example to send normal request with no POST data
            string resp = KeyAuthApp.webhook("7kR0UedlVI", "&type=black&ip=1.1.1.1&hwid=abc");

            // example to send form data
            resp = KeyAuthApp.webhook("7kR0UedlVI", "", "type=init&name=test&ownerid=j9Gj0FTemM", "application/x-www-form-urlencoded");

            // example to send JSON
            resp = KeyAuthApp.webhook("aM0MA1Ipqz", "", "{\"content\": \"webhook message here\",\"embeds\": null}", "application/json"); // if Discord webhook message successful, response will be empty

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

            Console.WriteLine("\n Closing in ten seconds...");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }

        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }

}
