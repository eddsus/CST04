using AppSD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(AppServiceService));
            host.Open();
            Console.WriteLine("Synchronizer AppService up'n running");
            Console.ReadLine();
        }
    }
}
