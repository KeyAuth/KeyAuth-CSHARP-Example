using KeyAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = ""; // place your Application Name within the Quotes.
            string ownerid = ""; // place your OwnerID within the Quotes.
            string secret = ""; // place your Application Secret within the Quotes.

            Console.Title = "KeyAuth C# Example";
            string key = ""; // dont delete this line!!
            api.init(name, secret, ownerid);

            if (!File.Exists(@"C:\ProgramData\keyauthkeysave.txt"))
            {
                Console.WriteLine("\n\n  Enter key\n  ");
                key = Console.ReadLine();
                api.login(key, name, secret, ownerid);
            }
            else
            {
                key = File.ReadAllText(@"C:\ProgramData\keyauthkeysave.txt");
                Console.WriteLine("\n\n  Logging in with saved key: " + key);
                api.login(key, name, secret, ownerid);
            }

            Console.WriteLine("\n\n  --Main Program--");

            Console.WriteLine("\n\n  Checking for level..");
            if(api.level("1",key,name,secret,ownerid))
            {
                Console.WriteLine("\n\n  Key has level");
            }
            else
            {
                Console.WriteLine("\n\n  Key doesn't have level");
            }

            Console.ReadLine();
        }
    }
}
