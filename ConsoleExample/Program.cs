using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
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

            Console.Title = "KeyAuth API Example";
            Console.WriteLine("\n\n  Connecting..");
            KeyAuthApp.init();

            Console.WriteLine("\n\n [1] Login\n [2] Register\n [3] Upgrade\n [4] License key only\n\n Choose option: ");

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
                    Thread.Sleep(3500);
                    Environment.Exit(0);
                    break; // no point in this other than to not get error from IDE
            }

            Console.WriteLine("\n\n  Logged In!"); // at this point, the client has been authenticated


            // KeyAuthApp.setvar("discord", "test#0001"); // set the variable 'discord' to 'test#0001'
            // Console.WriteLine(KeyAuthApp.getvar("discord")); // display the user variable 'discord'

            // user data
            Console.WriteLine("\n\n  User data:");
            Console.WriteLine("\n  Username: " + KeyAuthApp.user_data.username);
            Console.WriteLine("\n  IP address: " + KeyAuthApp.user_data.ip);
            Console.WriteLine("\n  Hardware-Id: " + KeyAuthApp.user_data.hwid);
			if (!String.IsNullOrEmpty(KeyAuthApp.user_data.createdate))
            Console.WriteLine("\n  Created at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.createdate)));
            if (!String.IsNullOrEmpty(KeyAuthApp.user_data.lastlogin)) // don't show last login on register since there is no last login at that point
                Console.WriteLine("\n  Last login at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.lastlogin)));
            Console.WriteLine("\n  First subscription (out of " + KeyAuthApp.user_data.subscriptions.Count + " total subscription(s)) expires at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.subscriptions[0].expiry)));
            Console.WriteLine("\n  First subscription (out of " + KeyAuthApp.user_data.subscriptions.Count + " total subscription(s)) time left in seconds: " + KeyAuthApp.user_data.subscriptions[0].timeleft);

            // KeyAuthApp.log("user logged in"); // log text to website and discord webhook (if set)

            // let's say you want to send request to https://keyauth.com/api/seller/?sellerkey=f43795eb89d6060b74cdfc56978155ef&type=black&ip=1.1.1.1&hwid=abc
            // but doing that from inside the loader is a bad idea as the link could get leaked.
            // Instead, you should create a webhook with the https://keyauth.com/api/seller/?sellerkey=f43795eb89d6060b74cdfc56978155ef part as the URL
            // then in your loader, put the rest of the link (the other paramaters) in your loader. And then it will send request from KeyAuth server and return response in string resp
            // string resp = KeyAuthApp.webhook("XESXjhZuwN", "&type=black&ip=1.1.1.1&hwid=abc");
            // Console.WriteLine("\n  Response recieved from webhook request: " + resp);

            // byte[] result = KeyAuthApp.download("201881"); // downloads application file
            // File.WriteAllBytes("C:\\Users\\mak\\Downloads\\KeyAuth-CSHARP-Example-main (5)\\KeyAuth-CSHARP-Example-main\\ConsoleExample\\bin\\Debug\\countkeys.txt", result);

            // Console.WriteLine(KeyAuthApp.var("testvar"));

            // KeyAuthApp.ban(); // ban the current user, must be logged in

            Console.WriteLine("\n\n  Closing in ten seconds...");
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
