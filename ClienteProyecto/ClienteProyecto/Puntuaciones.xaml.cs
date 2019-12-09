using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClienteProyecto {
    /// <summary>
    /// Lógica de interacción para Puntuaciones.xaml
    /// </summary>
    public partial class Puntuaciones : Window {
        String[] listaPuntuaciones= new string[10];
        String[] listaUsuarios = new string[10];
        int idioma;
        public Puntuaciones() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// metdo que determina el idioma de la ventana y carga las puntuaciones
        /// </summary>
        /// <param name="idioma">idioma del sistema</param>
        internal void setIdioma(int idioma) {
            this.idioma = idioma;
            if (idioma != 0) {
                aplicarIdioma();
            }
            cargarPuntuaciones();
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            tituloLB.Content = Properties.Recursos.labelTituloPuntuaciones;
            aceptarBT.Content= Properties.Recursos.buttonAceptar;
        }

        /// <summary>
        /// metodo que carga las puntuaciones de la base de datos
        /// </summary>
        private void cargarPuntuaciones() {
            ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
            listaPuntuaciones = servicio.getPuntuaciones();
            listaUsuarios = servicio.getUsuariosPuntuaciones();
            List<String> listaPuntuaciones1 = new List<string>();
            List<String> listaUsuarios1 = new List<string>();
            if (idioma == 0) {
                listaPuntuaciones1.Add("Score:");
                listaUsuarios1.Add("User:");
            } else {
                listaPuntuaciones1.Add("Puntuacion:");
                listaUsuarios1.Add("Usuario:");
            }
            foreach(String puntuacion in listaPuntuaciones) {
                listaPuntuaciones1.Add(puntuacion);
            }
            foreach (String usuario in listaUsuarios) {
                listaUsuarios1.Add(usuario);
            }
            puntuacionesLT.ItemsSource = listaPuntuaciones1;
            usuariosLT.ItemsSource = listaUsuarios1;
        }

        private void aceptarBT_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
