using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ClienteProyecto {

    /// <summary>
    /// Lógica de interacción para Opciones.xaml
    /// </summary>
    public partial class Opciones : Window {
        private int idioma;
        private int idJugador;
        private int respaldo;
        private int ficha = 0;
        private int respaldoFicha = 0;

        public Opciones() {
            InitializeComponent();
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
            respaldo = idioma;
        }

        /// <summary>
        /// metodo que obtiene el id del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="estado">estado de campaña</param>
        public void getID(int idJugador, int estado) {
            this.idJugador = idJugador;
            if (estado == 0) {
                ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
                ficha = service.getFichaJugador(idJugador);
                PintarFicha(ficha);
            } else {
                PintarFicha(respaldoFicha);
            }
        }

        /// <summary>
        /// metodo que muestra la imagen de la ficha que selecciona el jugador
        /// </summary>
        /// <param name="ficha">numero de ficha del jugador</param>
        private void PintarFicha(int ficha) {
            switch (ficha) {
                case 0: {
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha1.png", UriKind.Relative));
                }
                break;

                case 1: {
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha2.png", UriKind.Relative));
                }
                break;

                case 2: {
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha3.png", UriKind.Relative));
                }
                break;

                case 3: {
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha4.png", UriKind.Relative));
                }
                break;

                case 4: {
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha5.png", UriKind.Relative));
                }
                break;
            }
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            seleccionarFichaLB.Content = Properties.Recursos.labelFicha;
            seleccionarIdiomaLB.Content = Properties.Recursos.labelIdioma;
            cancelarBT.Content = Properties.Recursos.buttonCancelar;
            guardarBT.Content = Properties.Recursos.buttonGuardar;
        }

        private void inglesCI_Selected(object sender, RoutedEventArgs e) {
            idioma = 0;
            Opciones opciones = new Opciones();
            opciones.respaldoFicha = ficha;
            opciones.ficha = ficha;
            opciones.getID(this.idJugador, 1);
            opciones.setIdioma(this.idioma);
            opciones.Show();
            this.Close();
        }

        private void espanolCI_Selected(object sender, RoutedEventArgs e) {
            idioma = 1;
            aplicarIdioma();
        }

        private void guardarBT_Click(object sender, RoutedEventArgs e) {
            try {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
                servicio.setOpciones(idJugador, idioma, ficha);
                menuPrincipal.getID(idJugador);
                menuPrincipal.setIdioma(idioma);
                menuPrincipal.Show();
                this.Close();
            } catch (Exception) {
                MessageBox.Show("ocurrio un error inesperado", "error");
            }
        }

        private void cancelarBT_Click(object sender, RoutedEventArgs e) {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.getID(idJugador);
            menuPrincipal.setIdioma(respaldo);
            menuPrincipal.Show();
            this.Close();
        }

        private void siguienteBT_Click(object sender, RoutedEventArgs e) {
            switch (ficha) {
                case 0: {
                    ficha = 1;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha2.png", UriKind.Relative));
                }
                break;

                case 1: {
                    ficha = 2;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha3.png", UriKind.Relative));
                }
                break;

                case 2: {
                    ficha = 3;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha4.png", UriKind.Relative));
                }
                break;

                case 3: {
                    ficha = 4;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha5.png", UriKind.Relative));
                }
                break;

                case 4: {
                    ficha = 0;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha1.png", UriKind.Relative));
                }
                break;
            }
        }

        private void anteriorBT_Click(object sender, RoutedEventArgs e) {
            switch (ficha) {
                case 0: {
                    ficha = 4;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha5.png", UriKind.Relative));
                }
                break;

                case 1: {
                    ficha = 0;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha1.png", UriKind.Relative));
                }
                break;

                case 2: {
                    ficha = 1;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha2.png", UriKind.Relative));
                }
                break;

                case 3: {
                    ficha = 2;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha3.png", UriKind.Relative));
                }
                break;

                case 4: {
                    ficha = 3;
                    fichaIMG.Source = new BitmapImage(new Uri("Imagenes/ficha4.png", UriKind.Relative));
                }
                break;
            }
        }
    }
}