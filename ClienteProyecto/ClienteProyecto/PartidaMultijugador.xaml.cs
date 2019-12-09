using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Lógica de interacción para PartidaMultijugador.xaml
    /// </summary>
    public partial class PartidaMultijugador : Window {
        List<ServiceReference4.Casilla> casillas = new List<ServiceReference4.Casilla>();
        public int idioma;
        InstanceContext contexto;
        ServiceReference4.ChatClient servidor;
        ServiceReference4.Service1Client service;
        public List<String> mensajes = new List<string>();
        public List<String> usuarios = new List<string>();
        public string partida;
        public int idJugador;
        public String usuarioN = "null";
        public Lobby lobby;
        public int tablero;
        public int muerteSubita;
        public int posicionJugador;
        public int estado;
        public int tiro;
        public int numeroEntrada=0;
        public int numeroTiro=0;

        /// <summary>
        /// constructor que crea y define las variables inicaiales de la ventana
        /// </summary>
        public PartidaMultijugador() {
            InitializeComponent();
            this.tirarBT.IsEnabled = false;
            posicionJugador = 1;
            estado = 0;
        }

        /// <summary>
        /// metodo que determina las imagenes de la ventana
        /// </summary>
        /// <param name="tablero">numeeo de tablero</param>
        public void ajustarImagenes(int tablero) {
            switch (tablero) {
                case 1: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero1MT.png", UriKind.Relative));
                    cargarMapa1();
                    
                }
                break;
                case 2: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero2_1.png", UriKind.Relative));
                    cargarMapa2();
                    
                    
                }
                break;
                case 3: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero3.png", UriKind.Relative));
                    cargarMapa3();
                    

                }
                break;
                case 4: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero4.png", UriKind.Relative));
                    cargarMapa4();
                }
                break;
                case 5: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero5.png", UriKind.Relative));
                    cargarMapa5();
                }
                break;
            }
        }

        /// <summary>
        /// metodo que mueve la ficha del jugador a una casilla indicada
        /// </summary>
        /// <param name="columna">columna de destino</param>
        /// <param name="fila">fila de destino</param>
        /// <param name="jugador">numero del jugador</param>
        internal void moverFicha(int columna, int fila, int jugador) {
            Console.WriteLine("El jugador que se mueve es: "+jugador);
            switch (jugador) {
                case 1:
                ficha1IMG.SetValue(Grid.ColumnProperty, columna);
                ficha1IMG.SetValue(Grid.RowProperty, fila);
                break;
                case 2:
                ficha2IMG.SetValue(Grid.ColumnProperty, columna);
                ficha2IMG.SetValue(Grid.RowProperty, fila);
                break;
                case 3:
                ficha3IMG.SetValue(Grid.ColumnProperty, columna);
                ficha3IMG.SetValue(Grid.RowProperty, fila);
                break;
                case 4:
                ficha4IMG.SetValue(Grid.ColumnProperty, columna);
                ficha4IMG.SetValue(Grid.RowProperty, fila);
                break;
                default:
                Console.WriteLine("Ocurrio un error al saber que ficha mover");
                break;
            }
        }

        /// <summary>
        /// metodo que crea y define las casillas e imagenes para el tablero 5
        /// </summary>
        private void cargarMapa5() {
            List<ServiceReference4.Casilla> listaCasillas = new List<ServiceReference4.Casilla>();
            int i = 1;

            for (int columna = 9; columna >= 0; columna--) {
                for (int fila = 0; fila < 10; fila++) {
                    ServiceReference4.Casilla casilla = new ServiceReference4.Casilla();
                    casilla.Fila = columna;
                    casilla.Columna = fila;
                    casilla.NumeroCasillla = i;
                    casilla.Tipo = 0;
                    casilla.CasillaDestino = 0;
                    listaCasillas.Add(casilla);
                    i++;
                }
            }
            /// tipo 0 normal 1 serpiente 2 escalera 3 dragon
            foreach (ServiceReference4.Casilla casilla1 in listaCasillas) {
                if (casilla1.NumeroCasillla == 5) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 9;
                    casilla1.CasillasCambios = 40;
                    casilla1.CasillaDestino = 45;
                }
                if (casilla1.NumeroCasillla == 47) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 7;
                    casilla1.CasillasCambios = -18;
                    casilla1.CasillaDestino = 29;
                }
                if (casilla1.NumeroCasillla == 40) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 9;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = 40;
                    casilla1.CasillaDestino = 80;
                }
                if (casilla1.NumeroCasillla == 17) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 6;
                    casilla1.CasillasCambios = 17;
                    casilla1.CasillaDestino = 34;
                }
                if (casilla1.NumeroCasillla == 71) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 0;
                    casilla1.CasillasCambios = 20;
                    casilla1.CasillaDestino = 91;
                }
                if (casilla1.NumeroCasillla == 64) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 2;
                    casilla1.FilaDestino = 7;
                    casilla1.CasillasCambios = -41;
                    casilla1.CasillaDestino = 23;
                }
                if (casilla1.NumeroCasillla == 99) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 6;
                    casilla1.FilaDestino = 3;
                    casilla1.CasillasCambios = -32;
                    casilla1.CasillaDestino = 67;
                }
                if (casilla1.NumeroCasillla == 51) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -40;
                    casilla1.CasillaDestino = 11;
                }
                if (casilla1.NumeroCasillla == 84) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 5;
                    casilla1.CasillasCambios = -35;
                    casilla1.CasillaDestino = 49;
                }
            }
            casillas = listaCasillas;
        }

        /// <summary>
        /// metodo que crea y define las casillas e imagenes para el tablero 4
        /// </summary>
        private void cargarMapa4() {
            List<ServiceReference4.Casilla> listaCasillas = new List<ServiceReference4.Casilla>();
            int i = 1;

            for (int columna = 9; columna >= 0; columna--) {
                for (int fila = 0; fila < 10; fila++) {
                    ServiceReference4.Casilla casilla = new ServiceReference4.Casilla();
                    casilla.Fila = columna;
                    casilla.Columna = fila;
                    casilla.NumeroCasillla = i;
                    casilla.Tipo = 0;
                    casilla.CasillaDestino = 0;
                    listaCasillas.Add(casilla);
                    i++;
                }
            }
            /// tipo 0 normal 1 serpiente 2 escalera 3 dragon
            foreach (ServiceReference4.Casilla casilla1 in listaCasillas) {
                if (casilla1.NumeroCasillla == 5) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 5;
                    casilla1.CasillasCambios = 40;
                    casilla1.CasillaDestino = 45;
                }
                if (casilla1.NumeroCasillla == 23) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 9;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 1;
                }
                if (casilla1.NumeroCasillla == 39) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 7;
                    casilla1.FilaDestino = 3;
                    casilla1.CasillasCambios = 29;
                    casilla1.CasillaDestino = 68;
                }
                if (casilla1.NumeroCasillla == 36) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 7;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -18;
                    casilla1.CasillaDestino = 18;
                }
                if (casilla1.NumeroCasillla == 42) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 2;
                    casilla1.FilaDestino = 1;
                    casilla1.CasillasCambios = 41;
                    casilla1.CasillaDestino = 83;
                }
                if (casilla1.NumeroCasillla == 60) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 7;
                    casilla1.FilaDestino = 6;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 38;
                }
                if (casilla1.NumeroCasillla == 85) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 3;
                    casilla1.CasillasCambios = -21;
                    casilla1.CasillaDestino = 64;
                }
                if (casilla1.NumeroCasillla == 55) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 6;
                    casilla1.CasillasCambios = -21;
                    casilla1.CasillaDestino = 34;
                }
                if (casilla1.NumeroCasillla == 97) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 6;
                    casilla1.FilaDestino = 3;
                    casilla1.CasillasCambios = -30;
                    casilla1.CasillaDestino = 67;
                }
            }
            casillas = listaCasillas;
        }

        /// <summary>
        /// metodo que obteiene el numero del jugador en la partida
        /// </summary>
        internal void obtenerNumero() {
            numeroEntrada = servidor.getNuevoNumeroJugador(usuarioN, partida);
        }

        /// <summary>
        /// metodo que crea y define las casillas e imagenes para el tablero 3
        /// </summary>
        private void cargarMapa3() {
            List<ServiceReference4.Casilla> listaCasillas = new List<ServiceReference4.Casilla>();
            int i = 1;

            for (int columna = 9; columna >= 0; columna--) {
                for (int fila = 0; fila < 10; fila++) {
                    ServiceReference4.Casilla casilla = new ServiceReference4.Casilla();
                    casilla.Fila = columna;
                    casilla.Columna = fila;
                    casilla.NumeroCasillla = i;
                    casilla.Tipo = 0;
                    casilla.CasillaDestino = 0;
                    listaCasillas.Add(casilla);
                    i++;
                }
            }
            foreach (ServiceReference4.Casilla casilla1 in listaCasillas) {
                if (casilla1.NumeroCasillla == 19) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 5;
                    casilla1.CasillasCambios = 30;
                    casilla1.CasillaDestino = 49;
                }
                if (casilla1.NumeroCasillla == 35) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 9;
                    casilla1.CasillasCambios = -30;
                    casilla1.CasillaDestino = 5;
                }
                if (casilla1.NumeroCasillla == 66) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 1;
                    casilla1.CasillasCambios = 18;
                    casilla1.CasillaDestino = 84;
                }
                if (casilla1.NumeroCasillla == 58) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 2;
                    casilla1.FilaDestino = 7;
                    casilla1.CasillasCambios = -30;
                    casilla1.CasillaDestino = 23;
                }
                if (casilla1.NumeroCasillla == 71) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 0;
                    casilla1.CasillasCambios = 20;
                    casilla1.CasillaDestino = 91;
                }
                if (casilla1.NumeroCasillla == 73) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 4;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 51;
                }
                if (casilla1.NumeroCasillla == 97) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 75;
                }
                if (casilla1.NumeroCasillla == 64) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 7;
                    casilla1.FilaDestino = 7;
                    casilla1.CasillasCambios = -36;
                    casilla1.CasillaDestino = 28;
                }
                if (casilla1.NumeroCasillla == 79) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 6;
                    casilla1.FilaDestino = 4;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 57;
                }
            }
            casillas = listaCasillas;
        }

        /// <summary>
        /// metodo que crea y define las casillas e imagenes para el tablero 2
        /// </summary>
        private void cargarMapa2() {
            List<ServiceReference4.Casilla> listaCasillas = new List<ServiceReference4.Casilla>();
            int i = 1;

            for (int columna = 9; columna >= 0; columna--) {
                for (int fila = 0; fila < 10; fila++) {
                    ServiceReference4.Casilla casilla = new ServiceReference4.Casilla();
                    casilla.Fila = columna;
                    casilla.Columna = fila;
                    casilla.NumeroCasillla = i;
                    casilla.Tipo = 0;
                    casilla.CasillaDestino = 0;
                    listaCasillas.Add(casilla);
                    i++;
                }
            }
            foreach (ServiceReference4.Casilla casilla1 in listaCasillas) {
                if (casilla1.NumeroCasillla == 6) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 5;
                    casilla1.FilaDestino = 6;
                    casilla1.CasillasCambios = 30;
                    casilla1.CasillaDestino = 36;
                }
                if (casilla1.NumeroCasillla == 34) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 2;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -21;
                    casilla1.CasillaDestino = 13;
                }
                if (casilla1.NumeroCasillla == 48) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 7;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = 30;
                    casilla1.CasillaDestino = 78;
                }
                if (casilla1.NumeroCasillla == 41) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -30;
                    casilla1.CasillaDestino = 11;
                }
                if (casilla1.NumeroCasillla == 52) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 2;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = 21;
                    casilla1.CasillaDestino = 73;
                }
                if (casilla1.NumeroCasillla == 80) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 4;
                    casilla1.CasillasCambios = -21;
                    casilla1.CasillaDestino = 59;
                }
                if (casilla1.NumeroCasillla == 96) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 74;
                }
                if (casilla1.NumeroCasillla == 50) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 5;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -34;
                    casilla1.CasillaDestino = 16;
                }
                if (casilla1.NumeroCasillla == 64) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 6;
                    casilla1.FilaDestino = 6;
                    casilla1.CasillasCambios = -27;
                    casilla1.CasillaDestino = 37;
                }
            }
            casillas = listaCasillas;
        }

        /// <summary>
        /// metodo que crea y define las casillas e imagenes para el tablero 1
        /// </summary>
        private void cargarMapa1() {
            List<ServiceReference4.Casilla> listaCasillas = new List<ServiceReference4.Casilla>();
            int i = 1;

            for (int columna = 9; columna >= 0; columna--) {
                for (int fila = 0; fila < 10; fila++) {
                    ServiceReference4.Casilla casilla = new ServiceReference4.Casilla();
                    casilla.Fila = columna;
                    casilla.Columna = fila;
                    casilla.NumeroCasillla = i;
                    casilla.Tipo = 0;
                    casilla.CasillaDestino = 0;
                    listaCasillas.Add(casilla);
                    i++;
                }
            }
            foreach (ServiceReference4.Casilla casilla1 in listaCasillas) {
                if (casilla1.NumeroCasillla == 4) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 7;
                    casilla1.CasillasCambios = 20;
                    casilla1.CasillaDestino = 24;
                }
                if (casilla1.NumeroCasillla == 37) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -22;
                    casilla1.CasillaDestino = 15;
                }
                if (casilla1.NumeroCasillla == 41) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 0;
                    casilla1.FilaDestino = 2;
                    casilla1.CasillasCambios = 30;
                    casilla1.CasillaDestino = 71;
                }
                if (casilla1.NumeroCasillla == 46) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -27;
                    casilla1.CasillaDestino = 19;
                }
                if (casilla1.NumeroCasillla == 65) {
                    casilla1.Tipo = 2;
                    casilla1.ColumnaDestino = 4;
                    casilla1.FilaDestino = 1;
                    casilla1.CasillasCambios = 20;
                    casilla1.CasillaDestino = 85;
                }
                if (casilla1.NumeroCasillla == 73) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 5;
                    casilla1.CasillasCambios = -28;
                    casilla1.CasillaDestino = 44;
                }
                if (casilla1.NumeroCasillla == 80) {
                    casilla1.Tipo = 1;
                    casilla1.ColumnaDestino = 8;
                    casilla1.FilaDestino = 5;
                    casilla1.CasillasCambios = -31;
                    casilla1.CasillaDestino = 49;
                }
                if (casilla1.NumeroCasillla == 52) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 8;
                    casilla1.CasillasCambios = -42;
                    casilla1.CasillaDestino = 14;
                }
                if (casilla1.NumeroCasillla == 97) {
                    casilla1.Tipo = 3;
                    casilla1.ColumnaDestino = 3;
                    casilla1.FilaDestino = 3;
                    casilla1.CasillasCambios = -27;
                    casilla1.CasillaDestino = 64;
                }
            }
            casillas = listaCasillas;
        }

        /// <summary>
        /// metodo que define las variables de conexion con el servidor que va a utilizar
        /// </summary>
        /// <param name="instanceContext">contexto del usuario </param>
        /// <param name="chatClient">conexion a la interfaz de chat y multijugador</param>
        /// <param name="service1Client">conexion a la interfaz de Service1</param>
        public void setServidor(InstanceContext instanceContext, ServiceReference4.ChatClient chatClient,
            ServiceReference4.Service1Client service1Client) {
            contexto = instanceContext;
            servidor = chatClient;
            service = service1Client;
        }

        private void enviarTF_Click(object sender, RoutedEventArgs e) {
            try {
                if (!String.IsNullOrEmpty(mensajeTF.Text)) {
                    servidor.enviarMensajeJuego(mensajeTF.Text, partida);
                }
            } catch (FormatException) {
                MessageBox.Show("Introduce un valor valido para el campo \"muerte subita\"", "Error en dato");
            }
        }

        /// <summary>
        /// metodo que obtiene el id del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        public void getID(int idJugador) {
            this.idJugador = idJugador;
            usuarioN = service.getUsuarioUsuario(idJugador);
            int numeroConexion;
            numeroConexion = servidor.unirse(usuarioN, partida);
            personalizarVentana(numeroConexion);
            servidor.unirseUsuario(partida);
        }

        /// <summary>
        /// metodo que personaliza la ventana del cliente basandose en su numero de ususairo
        /// en la partida
        /// </summary>
        /// <param name="numeroCliente">numero del cliente en la partida</param>
        private void personalizarVentana(int numeroCliente) {
            if (numeroCliente == 0) {
                //cambios de ventana
            }
            if (numeroCliente == 1) {
                if (idioma == 0) {
                    //cambios de ventana
                } else {
                    //cambios de ventana
                }
                //cambios de ventana
            }
            if (numeroCliente == 2) {
                MessageBox.Show("Lo sentimos la sala esta llena", "Error");
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.getID(idJugador);
                menuPrincipal.setIdioma(idioma);
                menuPrincipal.Show();
                this.Close();
            }
        }

        /// <summary>
        /// metodo que estalece el idioma de la ventana
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
            chatJuegoLB.Content = Properties.Recursos.labelChat;
            enviarBT.Content = Properties.Recursos.buttonEnviar;
            tirarBT.Content = Properties.Recursos.buttonTirar;
        }

        /// <summary>
        /// metodo que cambia la partida
        /// </summary>
        /// <param name="seleccion">partida seleccionada</param>
        internal void setPartida(string seleccion) {
            this.partida = seleccion;
        }

        private void tirarBT_Click(object sender, RoutedEventArgs e) {
            try {
                numeroTiro++;
                int columnaDestino = 0;
                int filaDestino = 0;
                Random random = new Random();
                tiro = random.Next(1, 7);
                MessageBoxTemporal.Show("tirando", "tirando", 0, true);
                servidor.pintadDado(tiro, partida);
                Console.WriteLine("tiro del dado: " + tiro);
                int hipotetico = posicionJugador;
                if (hipotetico + tiro > 100) {
                    hipotetico = hipotetico + tiro - 100;
                    hipotetico = hipotetico * -1;
                    tiro = hipotetico;
                }
                posicionJugador += tiro;
                foreach (ServiceReference4.Casilla casilla in casillas) {
                    if (casilla.NumeroCasillla == posicionJugador) {
                        if (casilla.NumeroCasillla == 100) {
                            service.agregarPuntuacionVictoria(idJugador, numeroTiro);
                            String jugador = service.getUsuarioUsuario(idJugador);
                            MessageBoxTemporal.Show("Ganaste", "Fin del juego", 0, true);
                            Console.WriteLine("sdcdc");
                            servidor.ganoJugador(jugador, partida);
                            MessageBoxTemporal.Show("Ganaste", "Fin del juego", 0, true);
                            return;
                        }
                        if (casilla.Tipo == 0) {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                        }
                        if (casilla.Tipo == 1 || casilla.Tipo == 2) {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                            Console.WriteLine("columna a mover: " + columnaDestino + "filaDesdino: " + filaDestino + "partida: " + partida);
                            servidor.pintarMovimiento1(columnaDestino, filaDestino, partida, numeroEntrada);
                            if (casilla.Tipo == 1) {
                                MessageBoxTemporal.Show("caiste en una serpiente", "Serpiente", 0, true);
                            } else {
                                MessageBoxTemporal.Show("caiste en una escalera", "Escalera", 0, true);
                            }
                            columnaDestino = casilla.ColumnaDestino;
                            filaDestino = casilla.FilaDestino;
                            posicionJugador += casilla.CasillasCambios;
                        }
                        if (casilla.Tipo == 3) {
                            if (estado == 0) {
                                columnaDestino = casilla.Columna;
                                filaDestino = casilla.Fila;
                                Console.WriteLine("columna a mover: " + columnaDestino + "filaDesdino: " + filaDestino + "partida: " + partida);
                                servidor.pintarMovimiento1(columnaDestino, filaDestino, partida, numeroEntrada);
                                if (estado == 0) {
                                    estado = 1;
                                    servidor.moverDragones(estado, partida);
                                } else {
                                    estado = 0;
                                }
                                columnaDestino = casilla.ColumnaDestino;
                                filaDestino = casilla.FilaDestino;
                                posicionJugador += casilla.CasillasCambios;
                            } else {
                                columnaDestino = casilla.ColumnaDestino;
                                filaDestino = casilla.FilaDestino;
                            }
                        }
                    } else
                    if (estado == 1) {
                        if (casilla.CasillaDestino == posicionJugador) {
                            if (casilla.Tipo == 3) {
                                columnaDestino = casilla.ColumnaDestino;
                                filaDestino = casilla.FilaDestino;
                                Console.WriteLine("columna a mover: " + columnaDestino + "filaDesdino: " + filaDestino + "partida: " + partida);
                                servidor.pintarMovimiento1(columnaDestino, filaDestino, partida, numeroEntrada);
                                servidor.moverDragones(estado, partida);
                                columnaDestino = casilla.Columna;
                                filaDestino = casilla.Fila;
                                posicionJugador -= casilla.CasillasCambios;
                            }
                        }
                    }
                }
                MessageBoxTemporal.Show("tirando", "tirando", 0, true);
                Console.WriteLine("columna a mover: " + columnaDestino + "filaDesdino: " + filaDestino + "partida: " + partida);
                servidor.pintarMovimiento1(columnaDestino, filaDestino, partida, numeroEntrada);
                MessageBoxTemporal.Show("tirando", "tirando", 0, true);
                Console.WriteLine("numero de jugador: " + numeroEntrada + " partida: " + partida);
                servidor.pasarTurno(numeroEntrada, partida);
            } catch (FormatException) {
                MessageBox.Show("Introduce un valor valido para el campo \"muerte subita\"", "Error en dato");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                servidor.salirJuego(idJugador, partida, numeroEntrada);
            } catch (FormatException) {
                MessageBox.Show("Introduce un valor valido para el campo \"muerte subita\"", "Error en dato");
            }
        }
    }
}
