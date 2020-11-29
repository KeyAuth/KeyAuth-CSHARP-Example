using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KeyAuth;

namespace KeyAuth
{
    class Program
    {

        static void Main(string[] args) {
           string name = ""; // place your Application Name within the Quotes.
           string ownerid = ""; // place your OwnerID within the Quotes.
           string secret = ""; // place your Application Secret within the Quotes.

            
           api.init(name, secret, ownerid);

           Console.WriteLine("\n\nEnter key\n  ");
           string key = Console.ReadLine();

	   api.login(key, name, secret, ownerid);

           Console.ReadLine();
        }
    }
}
