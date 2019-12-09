using ADO;
using HostProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host1 {
    /// <summary>
    /// clase que levanta el servidor para exhibir las interfaces
    /// </summary>
    class Program {
        /// <summary>
        /// metodo que levanta las interfaces para ser usadas remotamente desde el cliente
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            using (ServiceHost host = new ServiceHost(typeof(HostProyecto.Service1))) {
                host.Open();
                Console.WriteLine("server is running");
                Console.ReadLine();
            }
        }
    }
}
