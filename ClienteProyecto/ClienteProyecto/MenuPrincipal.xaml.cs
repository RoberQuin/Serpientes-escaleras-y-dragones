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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window {
        int idioma;
        int idJugador;
        public MenuPrincipal() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void multijugadorBT_Click(object sender, RoutedEventArgs e) {
            try {
                Partida partida = new Partida();
                partida.getID(idJugador);
                partida.setIdioma(idioma);
                partida.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo que obtiene el id del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        public void getID(int idJugador) {
            this.idJugador = idJugador;
        }

        private void salirBT_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.setIdioma(idioma);
            mainWindow.Show();
            this.Close();
        }

        private void acercaBT_Click(object sender, RoutedEventArgs e) {
            Ayuda ayuda = new Ayuda();
            if (idioma == 0) {
                ayuda.ayudaIngles();
            } else {
                ayuda.ayudaEspanol();
            }
            
            ayuda.Show();
        }

        private void ayudaBT_Click(object sender, RoutedEventArgs e) {
            Ayuda ayuda = new Ayuda();
            if (idioma == 0) {
                ayuda.acecaIngles();
            } else {
                ayuda.acercaEspanol();
            }
            
            ayuda.Show();
        }

        private void opcionesBT_Click(object sender, RoutedEventArgs e) {
            try {
                Opciones opciones = new Opciones();
                opciones.setIdioma(idioma);
                opciones.getID(idJugador,0);
                opciones.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void puntuacionesBT_Click(object sender, RoutedEventArgs e) {
            try {
                Puntuaciones puntuaciones = new Puntuaciones();
                puntuaciones.setIdioma(idioma);
                puntuaciones.Show();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo que determina el idioma de la ventana
        /// </summary>
        /// <param name="idioma">idioma del sistema</param>
        internal void setIdioma(int idioma) {
            Console.WriteLine("11 "+idJugador);
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            this.idioma=service.getIdiomaJugador(idJugador);
            Console.WriteLine("el idioma es: "+this.idioma);
            if (this.idioma != 0) {
                aplicarIdioma();
            }
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            acercaBT.Content = Properties.Recursos.buttonAcercaDe;
            campaniaBT.Content = Properties.Recursos.buttonCampania;
            multijugadorBT.Content = Properties.Recursos.buttonMultijugador;
            opcionesBT.Content = Properties.Recursos.buttonOpciones;
            puntuacionesBT.Content = Properties.Recursos.buttonPuntuaciones;
            salirBT.Content = Properties.Recursos.buttonSalir;
            tituloIG.Source = new BitmapImage(new
                Uri("Imagenes/TituloImagenesEspanol" +
                "RD.png",UriKind.Relative));
        }

        private void campaniaBT_Click(object sender, RoutedEventArgs e) {
            try {
                SeleccionJuego seleccion = new SeleccionJuego();
                seleccion.getID(idJugador);
                seleccion.setIdioma(idioma);
                seleccion.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void opcionesBT_MouseEnter(object sender, MouseEventArgs e) {
            dragon3IMG.Visibility = Visibility.Visible;
        }

        private void opcionesBT_MouseLeave(object sender, MouseEventArgs e) {
            dragon3IMG.Visibility = Visibility.Hidden;
        }

        private void multijugadorBT_MouseEnter(object sender, MouseEventArgs e) {
            dragon2IMG.Visibility = Visibility.Visible;
        }

        private void multijugadorBT_MouseLeave(object sender, MouseEventArgs e) {
            dragon2IMG.Visibility = Visibility.Hidden;
        }

        private void campaniaBT_MouseEnter(object sender, MouseEventArgs e) {
            dragon1IMG.Visibility = Visibility.Visible;
        }

        private void campaniaBT_MouseLeave(object sender, MouseEventArgs e) {
            dragon1IMG.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// metodo que muestra el abandono de alguien en el multijugador
        /// </summary>
        /// <param name="jugador"></param>
        internal void mostrarAbandono(int jugador) {
            if (jugador == 0) {
                if (idioma != 0) {
                    MessageBox.Show("Regresaste al menu principal por que uno de los jugadores abandono y se nece" +
                "sitan 4 jugadores para jugar", "Alguien salío");
                } else {
                    MessageBox.Show("You returned to the main menu because one of the players left and 4 players " +
                        "are needed to play", "someone came out");
                }
            } else {
                if (idioma != 0) {
                    MessageBox.Show("Saliste de la partida de manera exitosa", "salida exitosa");
                } else {
                    MessageBox.Show("You left the game correctly", "successful exit");
                }
            }
        }

        /// <summary>
        /// metodo que muestra el abandono de alguiene en el lobby
        /// </summary>
        /// <param name="jugador"></param>
        internal void mostrarAbandonoLobby(int jugador) {
            if (jugador == 1) {
                if (idioma != 0) {
                    MessageBox.Show("Regresaste al menu principal por que uno de los jugadores salio del lobby" +
                        "", "Alguien salío");
                } else {
                    MessageBox.Show("You returned to the main menu because one of the players left the lobby" +
                        "", "someone came out");
                }
            } else {
                if (idioma != 0) {
                    MessageBox.Show("Saliste de la partida de manera exitosa", "salida exitosa");
                } else {
                    MessageBox.Show("You left the game correctly", "successful exit");
                }
            }
        }
    }
}
