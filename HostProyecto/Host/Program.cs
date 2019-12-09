using System;
using System.ServiceModel;

namespace Host {
    class Program {
        static void Main(string[] args) {
            using (ServiceHost host = new ServiceHost(typeof(HostProyecto.Service1))) {
                host.Open();
                Console.WriteLine("server is running");
                Console.ReadLine();
            }
        }
    }
}
