using System;

namespace Host {

    internal class Program {

        private static void Main(string[] args) {
            using (ServiceHost host = new ServiceHost(typeof(HostProyecto.Service1))) {
                host.Open();
                Console.WriteLine("server is running");
                Console.ReadLine();
            }
        }
    }
}