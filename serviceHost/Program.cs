using contract;
using contract.Devices;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HMIServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(service.HMIService)))
            {
                host.Open();
                
              
                Console.WriteLine("Service up and running at:");
                foreach (var ea in host.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                    
                }

                Console.ReadLine();
               
                host.Close();
                
            }
        }
    }
}
