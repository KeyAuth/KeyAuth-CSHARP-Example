using System;
using System.IO;
using System.Linq;

namespace KeyAuth
{
    class Program
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /*
         * 
         * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=UXRkNEvgxJU
         * 
         */

        static string name = "";
        static string ownerid = "";
        static string secret = "";
        static string version = "";

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        static void Main(string[] args) {
            Console.Title = RandomString(10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n  Connecting..");
            KeyAuthApp.init();


            // Register and Login Functions (still in beta)
            // KeyAuthApp.register("username", "password", "key");
            //KeyAuthApp.login("username", "password"); 

            string key;
            if (!File.Exists(@"C:\ProgramData\" + name))
            {
                Console.WriteLine("\n\n  Please enter your license key:\n\n  ");
                key = Console.ReadLine();
                KeyAuthApp.license(key);
            }
            else
            {
                key = File.ReadAllText(@"C:\ProgramData\" + name);
                Console.WriteLine("\n\n  Logging in with saved key: " + key);
                KeyAuthApp.license(key);
            }
            Console.WriteLine("\n\n  Logged In!");
            Console.ReadLine();
            Console.WriteLine("\n\n  Your key expires at " + KeyAuthApp.user_data.expiry);

            Console.ReadLine(); // remove this. this is for testing purposes. it's whats keeping your application open forever
            /*
            Optional Functions:

            KeyAuthApp.webhook("lfvbBrbFhI", "?sellerkey=CUqDqlCIgl&type=resethash");
            // send secure request to webhook which is impossible to crack into. the base link set on the website is https://keyauth.com/api/seller/, which nobody except you can see, so the final request is https://keyauth.com/api/seller/?sellerkey=CUqDqlCIgl&type=resethash

            KeyAuthApp.download("231696", "C:\\ok.dll"); // downloads application file

            Console.WriteLine(KeyAuthApp.var("123456")); // retrieves application variable
            */
        }
    }
}
