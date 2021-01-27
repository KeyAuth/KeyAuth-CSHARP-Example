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
        static string version = "1.0";

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        static void Main(string[] args) {
            Console.Title = RandomString(10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n  Connecting..");
            KeyAuthApp.init();

            string key;
            if (!File.Exists(@"C:\ProgramData\" + name))
            {
                Console.WriteLine("\n\n  Please enter your license key:\n\n  ");
                key = Console.ReadLine();
                KeyAuthApp.login(key);
            }
            else
            {
                key = File.ReadAllText(@"C:\ProgramData\" + name);
                Console.WriteLine("\n\n  Logging in with saved key: " + key);
                KeyAuthApp.login(key);
            }
            Console.WriteLine("\n\n  Logged In!");
            Console.WriteLine("\n\n  Your key expires at " + KeyAuthApp.user_data.expiry);

            /*

            KeyAuthApp.download("231696", "C:\\ok.dll");

            Optional Functions:

            Console.WriteLine(KeyAuthApp.var("123456"));

            Console.ReadLine();
            */
        }
    }
}
