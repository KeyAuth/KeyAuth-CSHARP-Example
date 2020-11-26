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
           string name = "Nigga"; // place your Application Name within the Quotes.
           string ownerid = "DKjdsk232k22"; // place your OwnerID within the Quotes.
           string secret = "301bbfe4ac5e874579e001b4b9dbd0ad04db5d359358a314cce58b3b24dd3bed"; // place your Application Secret within the Quotes.

            
           api.init(name, secret, ownerid);

           Console.WriteLine("\n\nEnter key\n  ");
           string key = Console.ReadLine();

	   api.login(key, name, secret, ownerid);

           Console.ReadLine();
        }
    }
}
