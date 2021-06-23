using System;
using System.IO;

namespace KeyAuth
{
    class Program
    {

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

            Console.Title = "KeyAuth API Example";
            Console.WriteLine("\n\n  Connecting..");
            KeyAuthApp.init();
            Console.Write("\n\n Enter your license key: ");
            string key = Console.ReadLine();
            KeyAuthApp.license(key);
            Console.WriteLine("\n\n  Logged In!");
            // byte[] result = KeyAuthApp.download("902901"); // downloads application file
            // File.WriteAllBytes("C:\\Users\\mak\\Downloads\\KeyAuth-CSHARP-Example-main (5)\\KeyAuth-CSHARP-Example-main\\ConsoleExample\\bin\\Debug\\countkeys.txt", result);
            Console.ReadLine();
        }
    }
}
