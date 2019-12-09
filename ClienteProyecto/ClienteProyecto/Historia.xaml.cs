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
    /// Lógica de interacción para Historia.xaml
    /// </summary>
    public partial class Historia : Window {
        int idioma;
        int idJugador;
        int img;
        int estado;
        public Historia() {
            InitializeComponent();
        }

        /// <summary>
        /// metodo que define que es lo que se va a mostrar en la ventana una vez que se crea la misma
        /// </summary>
        /// <param name="v">numero de estado para definir la imagen del contenido</param>
        internal void setIMG(int v) {
            img = v;
            estado = v;
            if (v == 0) {
                fondoIMG.Source = new BitmapImage(new Uri("C:/Users/rockm/Desktop/5to Semestre/Tecnologias/10ma iteracion/ClienteProyecto/ClienteProyecto/Imagenes/Explicacion1.png"));
                explicacionIMG.Content = Properties.Resources.labelExplicacion1;
            }
            if (v == 3) {
                fondoIMG.Source = new BitmapImage(new Uri("C:/Users/rockm/Desktop/5to Semestre/Tecnologias/11va iteracion/ClienteProyecto/ClienteProyecto/Imagenes/explicacion3.png"));
                explicacionIMG.Content = Properties.Resources.labelExplicacion3;
            }
            if (v == 7) {
                fondoIMG.Source = new BitmapImage(new Uri("Imagenes/explicacion4.png",UriKind.Relative));
                explicacionIMG.Content = Properties.Resources.labelExplicacion3;
            }
            if (v == 10) {
                fondoIMG.Source = new BitmapImage(new Uri("Imagenes/explicacion5.png", UriKind.Relative));
                explicacionIMG.Content = Properties.Resources.labelExplicacion3;
            }
            if (v == 13) {
                fondoIMG.Source = new BitmapImage(new Uri("Imagenes/explicacion6.png", UriKind.Relative));
                explicacionIMG.Content = Properties.Resources.labelExplicacion3;
            }
            if (v == 16) {
                fondoIMG.Source = new BitmapImage(new Uri("Imagenes/explicacion7.png", UriKind.Relative));
                explicacionIMG.Content = Properties.Resources.labelExplicacion3;
            }
        }

        private void continuar_Click(object sender, RoutedEventArgs e) {
            switch (estado) {
                case 0: {
                    estado0();
                }break;
                case 1: {
                    estado1();
                }break;
                case 3: {
                    estado3();
                }break;
                case 7: {
                    estado7();
                }break;
                case 10: {
                    estado10();
                }break;
                case 13: {
                    estado13();
                }break;
                case 16: {
                    estado16();
                }break;
                case 17: {
                    estado17();
                }break;
            }
        }

        /// <summary>
        /// metodo que manda al juego con estado 14 
        /// </summary>
        private void estado13() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador, 14);
            JuegoCampaña juego = new JuegoCampaña();
            juego.setIdioma(idioma);
            juego.getID(idJugador);
            juego.ajustarImagenes(14);
            juego.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que manda una historia con estado 17
        /// </summary>
        private void estado16() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador, 17);
            fondoIMG.Source = new BitmapImage(new Uri("C:/Users/rockm/Desktop/5to Semestre/Tecnologias/10ma iteracion/ClienteProyecto/ClienteProyecto/Imagenes/explicacion2.png"));
            explicacionIMG.Content = Properties.Resources.labelExplicacion2;
            this.estado = 17;
        }

        /// <summary>
        /// metodo que reinicia el progreso del jugador a 0
        /// </summary>
        private void estado17() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador,0);
        }

        /// <summary>
        /// metodo que manda a el juego con estado 11
        /// </summary>
        private void estado10() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador, 11);
            JuegoCampaña juego = new JuegoCampaña();
            juego.setIdioma(idioma);
            juego.getID(idJugador);
            juego.ajustarImagenes(11);
            juego.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que manda a el juego con estado 8
        /// </summary>
        private void estado7() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador, 8);
            JuegoCampaña juego = new JuegoCampaña();
            juego.setIdioma(idioma);
            juego.getID(idJugador);
            juego.ajustarImagenes(8);
            juego.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que manda a el juego con estado 3
        /// </summary>
        private void estado3() {
            try {
                ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
                service.SetCampaniaJugador(idJugador, 5);
                JuegoCampaña juego = new JuegoCampaña();
                juego.setIdioma(idioma);
                juego.getID(idJugador);
                juego.ajustarImagenes(5);
                juego.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo que manda a el juego con estado 1
        /// </summary>
        private void estado1() {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador, 2);
            JuegoCampaña juego = new JuegoCampaña();
            juego.setIdioma(idioma);
            juego.getID(idJugador);
            juego.ajustarImagenes(2);
            juego.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que manda a la historia con estado 0
        /// </summary>
        private void estado0() {
            fondoIMG.Source = new BitmapImage(new Uri("C:/Users/rockm/Desktop/5to Semestre/Tecnologias/10ma iteracion/ClienteProyecto/ClienteProyecto/Imagenes/explicacion2.png"));
            explicacionIMG.Content = Properties.Resources.labelExplicacion2;
            this.estado = 1;
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            service.SetCampaniaJugador(idJugador,1);
        }

        /// <summary>
        /// metodo que obtiene el ID del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        internal void getID(int idJugador) {
            this.idJugador = idJugador;
        }

        /// <summary>
        /// metodo que obtiene el idioma del juego
        /// </summary>
        /// <param name="idioma">idioma que se va a establecer</param>
        internal void setIdioma(int idioma) {
            this.idioma = idioma;
        }
    }
}
