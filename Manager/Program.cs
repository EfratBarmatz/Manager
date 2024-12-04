using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connaction= "data source=srv2\\pupils;initial catalog=MyShop_327707238;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";

            Products pr = new Products();

            Console.WriteLine( pr.InsertProduct(connaction)+"row insert" );
            pr.getAllProducts(connaction);

            //Console.WriteLine(pr.InsertCategory(connaction));
        }
    }
}
