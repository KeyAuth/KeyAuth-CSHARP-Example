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

        static void Main(string[] args) {

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

            // KeyAuthApp.webhook("HDb5HiwOSM", "&type=black&ip=1.1.1.1&hwid=abc");

            // Console.WriteLine(KeyAuthApp.user_data.ip); // print out user's ip
            // Console.WriteLine(KeyAuthApp.user_data.subscriptions[0].subscription); // print out subscription name (basically level)
            // Console.WriteLine(UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.subscriptions[0].expiry))); // print out expiry
            // byte[] result = KeyAuthApp.download("201881"); // downloads application file
            // File.WriteAllBytes("C:\\Users\\mak\\Downloads\\KeyAuth-CSHARP-Example-main\\KeyAuth-CSHARP-Example-main\\ConsoleExample\\bin\\Debug\\test.dll", result);

            Console.WriteLine("\n\n  Closing in five seconds..."); // thought people would be able to find this easier than a ReadLine...
            Thread.Sleep(3200); // I lied! Jk, it takes the average person 1.8 seconds to read the above output, so I've accounted for that. it would be a huge travesty if it didn't close in five seconds from the ouptput being displayed :)
            Environment.Exit(0);
        }
    }

}
