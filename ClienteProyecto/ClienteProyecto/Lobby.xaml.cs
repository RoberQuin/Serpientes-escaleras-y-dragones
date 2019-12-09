using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
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
    /// Clase que implementa el Callback de las respuestas del servidor para el cliente
    /// </summary>
    public partial class MiLlamadaDeVuelta : ServiceReference4.IChatCallback {
        Lobby lobby;
        PartidaMultijugador PartidaMultijugador;

        public Lobby Lobby { get => lobby; set => lobby = value; }
        public PartidaMultijugador PartidaMultijugador1 { get => PartidaMultijugador; set => PartidaMultijugador = value; }

        /// <summary>
        /// metodo que muestra una descripcion de la victoria para avisar que ganó alguien
        /// y ademas cierra la ventana y regresa a los jugadores al lobby
        /// </summary>
        /// <param name="Jugador">el nombre del jugador que ganó</param>
        /// <param name="numeroJugador">el numero del cliente actual</param>
        public void ganoJugador1(string Jugador, int numeroJugador) {
            Console.WriteLine("mando a mostrar al ganar");
            MessageBoxTemporal.Show("Ganó: "+Jugador,"Fin del juego",2,true);
            Console.WriteLine("mando a mostrar al ganar");
            Lobby lobby = new Lobby();
            lobby.setIdioma(PartidaMultijugador1.idioma);
            lobby.setPartida(PartidaMultijugador1.partida);
            lobby.getID(PartidaMultijugador1.idJugador);
            lobby.Show();
            PartidaMultijugador1.Close();
        }

        /// <summary>
        /// metodo que cambia el orden de los dragones cuando alguien cae en uno
        /// </summary>
        /// <param name="estado">estado del tablero</param>
        public void moverDragones1(int estado) {
            if (PartidaMultijugador1.estado == 0) {
                PartidaMultijugador1.estado = 1;
                switch (PartidaMultijugador1.tablero) {
                    case 1:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png",UriKind.Relative));
                    break;
                    case 2:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1D.png",UriKind.Relative));
                    break;
                    case 3:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero3D.png",UriKind.Relative));
                    break;
                    case 4:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero4D.png",UriKind.Relative));
                    break;
                    case 5:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero5D.png",UriKind.Relative));
                    break;
                }
            }else
            if (PartidaMultijugador1.estado == 1) {
                PartidaMultijugador1.estado = 0;
                switch (PartidaMultijugador1.tablero) {
                    case 1:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1MT.png",UriKind.Relative));
                    break;
                    case 2:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1.png",UriKind.Relative));
                    break;
                    case 3:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero3.png",UriKind.Relative));
                    break;
                    case 4:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero4.png",UriKind.Relative));
                    break;
                    case 5:
                    PartidaMultijugador1.tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero5.png",UriKind.Relative));
                    break;
                }
            }
        }

        /// <summary>
        /// metodo que cambia el turno de los jugadores
        /// </summary>
        public void pasarTurno1() {
            PartidaMultijugador1.tirarBT.IsEnabled = true;
            Console.WriteLine("se dio el turno");
        }

        /// <summary>
        /// metodo que muestra la imagen del dado con base a su tiro
        /// </summary>
        /// <param name="tiro"></param>
        public void pintarDado(int tiro) {
            switch (tiro) {
                case 1: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado1.png",UriKind.Relative));
                }
                break;
                case 2: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado2.png",UriKind.Relative));
                }
                break;
                case 3: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado3.png",UriKind.Relative));
                }
                break;
                case 4: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado4.png",UriKind.Relative));
                }
                break;
                case 5: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado5.png",UriKind.Relative));
                }
                break;
                case 6: {
                    PartidaMultijugador1.dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado6.png",UriKind.Relative));
                }
                break;
                default: {
                    Console.WriteLine("Error inesperado en el valor Random");
                }
                break;
            }
        }

        /// <summary>
        /// metodo que muestra el movimiento de un jugador a su destino
        /// </summary>
        /// <param name="columna">columna a donde se moverá</param>
        /// <param name="fila">fila a donde se moverá</param>
        /// <param name="jugador">jugador que se moverá</param>
        public void pintarMovimiento(int columna, int fila, int jugador) {
            PartidaMultijugador1.moverFicha(columna,fila,jugador);
            //PartidaMultijugador1.numeroEntrada = jugador;
        }

        /// <summary>
        /// metodo que le quita el turno a el ultimo jugador que tiro
        /// </summary>
        public void quitarTurno() {
            PartidaMultijugador1.tirarBT.IsEnabled = false;
            Console.WriteLine("se quito el turno");
        }

        /// <summary>
        /// metodo que ajusta los atributos de ventana multijugador y se la muestra al cliente
        /// </summary>
        /// <param name="i">numero del jugador</param>
        /// <param name="tablero">tablero a crear</param>
        /// <param name="muerteSubita">numero de turnos para la muerte subita</param>
        public void ResiveEntradaMulti(int i,int tablero,int muerteSubita) {
            PartidaMultijugador1.lobby = lobby;
            PartidaMultijugador1.setServidor(lobby.contexto, lobby.servidor, lobby.service);
            PartidaMultijugador1.tablero = tablero;
            PartidaMultijugador1.ajustarImagenes(tablero);
            PartidaMultijugador1.setPartida(lobby.partida);
            PartidaMultijugador1.numeroEntrada = lobby.numeroEntrada;
            PartidaMultijugador1.idJugador = lobby.idJugador;
            PartidaMultijugador1.idioma = lobby.idioma;
            PartidaMultijugador1.Show();
            lobby.Close();
            if (i == 0) {
                PartidaMultijugador.tirarBT.IsEnabled = true;
            }
        }

        /// <summary>
        /// metodo que escribe los mensajes en el chat del lobby a todos los jugadores
        /// </summary>
        /// <param name="usuario">usuario que manda el mensaje</param>
        /// <param name="mensaje">mensaje del usuario</param>
        public void ResiveMensaje(string usuario, string mensaje) {
            lobby.mensajes.Add(usuario+" : "+mensaje );
            List<String> dfd = new List<string>();
            lobby.chatLB.ItemsSource = dfd;
            lobby.chatLB.ItemsSource = lobby.mensajes;
            lobby.mensajeTF.Text = "";
            Console.WriteLine("Usuario: "+usuario+"  Mensaje: "+mensaje);
        }

        /// <summary>
        /// metodo que escribe los mnesajes en el chat del multijugador a todos los jugadores
        /// </summary>
        /// <param name="usuario">usuario que manda el mensaje</param>
        /// <param name="mensaje">mensaje del usuario</param>
        public void ResiveMensajeJuego(string usuario, string mensaje) {
            PartidaMultijugador1.mensajes.Add(usuario + " : " + mensaje);
            List<String> dfd = new List<string>();
            PartidaMultijugador1.chatLB.ItemsSource = dfd;
            PartidaMultijugador1.chatLB.ItemsSource = PartidaMultijugador1.mensajes;
            PartidaMultijugador1.mensajeTF.Text = "";
            Console.WriteLine("Usuario: " + usuario + "  Mensaje: " + mensaje);
        }

        /// <summary>
        /// metodo que muetsra la salida de un usuario del lobby
        /// </summary>
        /// <param name="numero">numero del jugador</param>
        public void ResiveSalida(int numero) {
            lobby.actualizarFicha(numero);
            if (numero == 0) {
                //actualizar como host
                lobby.actualizarUsuarios();
            } else {
                lobby.actualizarUsuarios();
            }
        }

        /// <summary>
        /// metodo que muestra la salida de un usauiro del multijugador
        /// </summary>
        /// <param name="numero">numero del jugadr</param>
        public void ResiveSalidaJuego(int numero) {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.setIdioma(PartidaMultijugador1.idioma);
            menuPrincipal.getID(PartidaMultijugador1.idJugador);
            menuPrincipal.Show();
            PartidaMultijugador1.Close();
            menuPrincipal.mostrarAbandono(0);
            
        }

        /// <summary>
        /// metodo que muestra la salida del jugador del multijugador
        /// </summary>
        public void ResiveSalidaJuegoAbandona() {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.setIdioma(PartidaMultijugador1.idioma);
            menuPrincipal.getID(PartidaMultijugador1.idJugador);
            menuPrincipal.Show();
            PartidaMultijugador1.Close();
            menuPrincipal.mostrarAbandono(1);
            
        }

        /// <summary>
        /// metodo que muestra la salida de un usuairo de el lobby
        /// </summary>
        public void ResiveSalidaJuegoAbandonaLobby() {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.setIdioma(lobby.idioma);
            menuPrincipal.getID(lobby.idJugador);
            menuPrincipal.Show();
            lobby.Close();
            menuPrincipal.mostrarAbandonoLobby(0);
            
        }

        /// <summary>
        /// metodo que muestra la salida del jugador del lobby
        /// </summary>
        /// <param name="i">numero del jugador</param>
        public void ResiveSalidaJuegoLobby(int i) {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.setIdioma(lobby.idioma);
            menuPrincipal.getID(lobby.idJugador);
            menuPrincipal.Show();
            lobby.Close();
            menuPrincipal.mostrarAbandonoLobby(1);
            
        }

        /// <summary>
        /// metodo que agrega a los usuarios que estan en la partida a la lista de 
        /// usuarios del lobby
        /// </summary>
        /// <param name="usuariosDevueltos">lista de ususarios en la partida</param>
        public void ResiveUsuario(String[] usuariosDevueltos) {
            lobby.usuarios.Clear();
            foreach(String usu in usuariosDevueltos) {
                lobby.usuarios.Add(usu);
            }
            //lobby.usuarios = usuariosDevueltos;
            List<String> dfd = new List<string>();
            lobby.usuariosLB.ItemsSource = dfd;
            lobby.usuariosLB.ItemsSource = lobby.usuarios;
            if (lobby.usuarios.Count() == 4) {
                lobby.esperandoJugadoresLB.Visibility = Visibility.Hidden;
                lobby.iniciarJuegoBT.IsEnabled = true;

            }
            //lobby.mensajeTF.Text = "";
            //Console.WriteLine("Usuario: " + usuario );
        }

        /// <summary>
        /// metodo que recibe la lista de los usuairos del multijugador
        /// </summary>
        /// <param name="lista"></param>
        public void ResiveUsuarioJuego(string[] lista) {
            //
        }
    }

    public partial class Lobby : Window {
        public int idioma;
        public InstanceContext contexto;
        public ServiceReference4.ChatClient servidor;
        public ServiceReference4.Service1Client service;
        public List<String> mensajes = new List<string>();
        public List<String> usuarios = new List<string>();
        public string partida;
        public int idJugador;
        public String usuarioN = "null";
        public int numeroEntrada=0;
        public int tablero=1;

        /// <summary>
        /// decribe la interaccion de la clase Lobby.xaml
        /// </summary>
        public Lobby() {
            InitializeComponent();
            MiLlamadaDeVuelta mi = new MiLlamadaDeVuelta();
            mi.PartidaMultijugador1 = new PartidaMultijugador();
            mi.Lobby = this;
            contexto = new InstanceContext(mi) ;
            servidor = new ServiceReference4.ChatClient(contexto);
            service = new ServiceReference4.Service1Client();
            this.iniciarJuegoBT.IsEnabled = false;
            tableroIMG.Source= new BitmapImage(new Uri("Imagenes/tablero1MT.png",UriKind.Relative));
            //tablero = 1;
        }


        private void chatLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void enviarTF_Click(object sender, RoutedEventArgs e) {
            try {
                if (!String.IsNullOrEmpty(mensajeTF.Text)) {
                    servidor.enviarMensaje(mensajeTF.Text, partida);
                }
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo que obtiene el ID del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        public void getID(int idJugador) {
            this.idJugador = idJugador;
            usuarioN = service.getUsuarioUsuario(idJugador);

            int numeroConexion;
            numeroEntrada = servidor.getNumeroJugador(usuarioN,partida);
            numeroConexion = servidor.unirse(usuarioN,partida);
            personalizarVentana(numeroConexion);
            servidor.unirseUsuario(partida);
        }

        /// <summary>
        /// metodo que determina las pciones disponibles para el usuario
        /// </summary>
        /// <param name="numeroCliente">numero de usuario</param>
        private void personalizarVentana(int numeroCliente) {
            nombreTablero.Visibility = Visibility.Hidden;
            if(numeroCliente == 0) {
                esperandoLB.Visibility = Visibility.Hidden;
                fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo5.png",UriKind.Relative));
            }
            if (numeroCliente == 1) {
                if (idioma == 0) {
                    tableroLB.Content = Properties.Resources.labelTablero;
                    esperandoJugadoresLB.Visibility = Visibility.Visible;
                    iniciarJuegoBT.IsEnabled = false;
                } else {
                    tableroLB.Content = Properties.Recursos.labelTablero;
                }
                tableroIMG.Visibility = Visibility.Hidden;
                tableroLB.Visibility = Visibility.Hidden;
                siguienteBT.Visibility = Visibility.Hidden;
                anteriorBT.Visibility = Visibility.Hidden;
                muerteSubitaLB.Visibility = Visibility.Hidden;
                muerteSubitaTF.Visibility = Visibility.Hidden;
                iniciarJuegoBT.Visibility = Visibility.Hidden;
                esperandoJugadoresLB.Visibility = Visibility.Visible;
                switch (numeroEntrada) {
                    case 2:
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo1.png",UriKind.Relative));
                    break;
                    case 3:
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png",UriKind.Relative));
                    break;
                    case 4:
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo3.png",UriKind.Relative));
                    break;
                    default:
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo4.png",UriKind.Relative));
                    break; 
                }
            }
            if (numeroCliente==2) {
                MessageBox.Show("Lo sentimos la sala esta llena","Error");
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.getID(idJugador);
                menuPrincipal.setIdioma(idioma);
                menuPrincipal.Show();
                this.Close();
            }
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
            enviarBT.Content = Properties.Recursos.buttonEnviar;
            fichaLB.Content = Properties.Recursos.labelTuFicha;
            salirBT.Content = Properties.Recursos.buttonSalir;
            chatJuegoLB.Content = Properties.Recursos.labelChat;
            esperandoLB.Content = Properties.Recursos.labelEspera;
            tableroLB.Content = Properties.Recursos.labelTablero;
            muerteSubitaLB.Content = Properties.Recursos.labelMuerteSubita;
            jugadoresLB.Content = Properties.Recursos.labelJugadores;
            anteriorBT.Content = Properties.Recursos.labelAnterior;
            siguienteBT.Content = Properties.Recursos.labelSiguiente;
            iniciarJuegoBT.Content = Properties.Recursos.buttonIniciarJuego;
        }

        private void salirBT_Click(object sender, RoutedEventArgs e) {
            try {
                servidor.salir(partida);
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo queactualiza los usuarios actuales en el lobby
        /// </summary>
        internal void actualizarUsuarios() {
            servidor.unirseUsuario(partida);
        }

        /// <summary>
        /// metodo que cambia la partida
        /// </summary>
        /// <param name="seleccion">partida seleccionada</param>
        internal void setPartida(string seleccion) {
            this.partida = seleccion;
        }

        private void iniciarJuegoBT_Click(object sender, RoutedEventArgs e) {
            try {
                if (this.usuarios.Count() < 4) {
                    MessageBox.Show("Es necesario que estén los 4 jugadores para poder iniciar el juego" +
                        "", "Se necesitan mas jugadores");
                } else {
                    servidor.entrarJuego(partida, tablero, int.Parse(muerteSubitaTF.Text));
                }
                if (int.Parse(muerteSubitaTF.Text) < 0) {
                    MessageBox.Show("Introduce un valor valido para el campo \"muerte subita\"","Error en dato");
                }
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            } catch (FormatException) {
                MessageBox.Show("Introduce un valor valido para el campo \"muerte subita\"", "Error en dato");
            }
        }

        private void siguienteBT_Click(object sender, RoutedEventArgs e) {
            switch (tablero) {
                case 1: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero2_1.png",UriKind.Relative));
                    tablero = 2;
                }
                break;
                case 2: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero3.png",UriKind.Relative));
                    tablero = 3;
                }
                break;
                case 3: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero4.png",UriKind.Relative));
                    tablero = 4;
                }
                break;
                case 4: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero5.png",UriKind.Relative));
                    tablero = 5;
                }
                break;
                case 5: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero1MT.png",UriKind.Relative));
                    tablero = 1;
                }
                break;
                default: {
                    Console.WriteLine("Default");
                }
                break;
            }
        }

        private void anteriorBT_Click(object sender, RoutedEventArgs e) {
            switch (tablero) {
                case 1: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero5.png",UriKind.Relative));
                    tablero = 5;
                }
                break;
                case 2: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero1MT.png",UriKind.Relative));
                    tablero = 1;
                }
                break;
                case 3: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero2_1.png",UriKind.Relative));
                    tablero = 2;
                }
                break;
                case 4: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero3.png",UriKind.Relative));
                    tablero = 3;
                }
                break;
                case 5: {
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero4.png",UriKind.Relative));
                    tablero = 4;
                }
                break;
                default: {
                    Console.WriteLine("Default");
                }
                break;
            }
        }

        /// <summary>
        /// metodoq que actualiza las fichas de los usuarios
        /// </summary>
        /// <param name="numero">numero de jugador</param>
        internal void actualizarFicha(int numero) {
            switch (numero) {
                case 0: {
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo5.png",UriKind.Relative));
                }
                break;
                case 1: {
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo1.png",UriKind.Relative));
                }
                break;
                case 2: {
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png",UriKind.Relative));
                }
                break;
                case 3: {
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo3.png",UriKind.Relative));
                }
                break;
                default: {
                    fichaAsignadaIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo4.png",UriKind.Relative));
                }
                break;
            }
        }

    }
}
