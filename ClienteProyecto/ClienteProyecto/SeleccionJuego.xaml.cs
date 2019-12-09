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
    /// Lógica de interacción para SeleccionJuego.xaml
    /// </summary>
    public partial class SeleccionJuego : Window {
        public int idJugador;
        public int idioma;
        public SeleccionJuego() {
            InitializeComponent();
            
        }

        /// <summary>
        /// metodo que determina los botones disponibles para la seleccion de campaña del jugador
        /// </summary>
        private void determinarBotones() {
            ServiceReference4.Service1Client service1Client = new ServiceReference4.Service1Client();
            int progreso = service1Client.GetCampaniaJugador(idJugador);
            Console.WriteLine("Progreso: "+progreso);
            if (progreso == 0) {
                Console.WriteLine("quito el continuar");
                continuaBT.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {//LLama a la historia nueva
            try {
                ServiceReference4.Service1Client service1Client = new ServiceReference4.Service1Client();
                service1Client.SetCampaniaJugador(idJugador, 1);
                Historia historia = new Historia();
                historia.getID(idJugador);
                historia.setIdioma(idioma);
                historia.setIMG(0);
                historia.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {//llama continuar
            try {
                int progreso;
                ServiceReference4.Service1Client service1Client = new ServiceReference4.Service1Client();
                progreso = service1Client.GetCampaniaJugador(idJugador);
                JuegoCampaña juego = new JuegoCampaña();
                juego.getID(idJugador);
                juego.setIdioma(idioma);
                juego.ajustarImagenes(progreso);
                juego.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            MenuPrincipal menu = new MenuPrincipal();
            menu.getID(idJugador);
            menu.setIdioma(idioma);
            menu.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que obtiene el id del usuairo
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        internal void getID(int idJugador) {
            this.idJugador = idJugador;
            determinarBotones();
        }

        /// <summary>
        /// metodo que determina el idioma de la ventana
        /// </summary>
        /// <param name="idioma">idioma del sistema</param>
        internal void setIdioma(int idioma) {
            this.idioma = idioma;
            if (idioma != 0) {
                aplicarIdioma();
            }
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            continuaBT.Content = Properties.Recursos.buttonContinuar;
            nuevaBT.Content = Properties.Recursos.buttonNueva;
            logoIMG.Source = new BitmapImage(new Uri("Imagenes/tituloImagenesEspanolRD.png", UriKind.Relative));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            dragon1IMG.Visibility = Visibility.Visible;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            dragon1IMG.Visibility = Visibility.Hidden;
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e) {
            dragon2IMG.Visibility = Visibility.Visible;
        }

        private void Button_MouseLeave_1(object sender, MouseEventArgs e) {
            dragon2IMG.Visibility = Visibility.Hidden;
        }
    }
}
