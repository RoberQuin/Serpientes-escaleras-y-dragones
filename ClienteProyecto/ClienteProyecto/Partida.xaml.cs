using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace ClienteProyecto {

    /// <summary>
    /// Lógica de interacción para Partida.xaml
    /// </summary>
    public partial class Partida : Window {
        public int idJugador;
        public int idioma;
        private List<String> partidasDatos = new List<string>();
        private List<String> partidasClaveDatos = new List<string>();
        private bool disponibles;

        public Partida() {
            InitializeComponent();
            cargarPartidas();
        }

        /// <summary>
        /// metodo que obtiene y muestra las partidas definidas en el servidor
        /// </summary>
        private void cargarPartidas() {
            try {
                MiLlamadaDeVuelta mi = new MiLlamadaDeVuelta();
                ServiceReference4.ChatClient servidor = new ServiceReference4.ChatClient(new InstanceContext(mi));
                Console.WriteLine("1");
                String[] partidas = new string[0];
                partidas = servidor.getPartidas();
                Console.WriteLine("1.5");
                String[] nombres = new string[0];
                nombres = servidor.getPartidasClave();
                Console.WriteLine("2");
                foreach (String partida in partidas) {
                    partidasDatos.Add(partida);
                    Console.WriteLine("Se agrego 1 partida partida");
                }
                Console.WriteLine("3");
                foreach (String partida in nombres) {
                    partidasClaveDatos.Add(partida);
                    Console.WriteLine("Se agrego 1 partida Nombre");
                }
                Console.WriteLine("4");
                if (partidasDatos.Count() == 0) {
                    disponibles = false;
                } else {
                    disponibles = true;
                }
                Console.WriteLine("5");
                this.partidasLT.ItemsSource = partidasDatos;
            } catch (Exception e) {
                Console.WriteLine(e.Message + "Error en la recoleccion de partidas");
            }
        }

        /// <summary>
        /// metodo que obtiene el id del jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        internal void getID(int idJugador) {
            this.idJugador = idJugador;
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
            if (partidasDatos.Count == 0) {
                if (idioma != 0) {
                    partidasDatos.Add("No hay partidas Disponibles, Crea una!");
                } else {
                    partidasDatos.Add("No games Available, Create one!");
                }
            }
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            cancelarBT.Content = Properties.Recursos.buttonCancelar;
            partidasLB.Content = Properties.Recursos.labelPartidas;
            crearLB.Content = Properties.Recursos.labelCrearPartida;
            crearBT.Content = Properties.Recursos.buttonCrearPartida;
            unirseBT.Content = Properties.Recursos.buttonUnirse;
            nombreLB.Content = Properties.Recursos.labelNombrePartida;
        }

        private void unirseBT_Click(object sender, RoutedEventArgs e) {
            try {
                if (disponibles == false) {
                    MessageBox.Show("No hay partidas disponibles. crea una en la parte i" +
                        "zquierda", "No hay partidas");
                    return;
                }
                String seleccion = partidasLT.SelectedItem.ToString();
                int seleccionNumero = partidasLT.SelectedIndex;
                int i = 0;
                foreach (String sleecion2 in partidasClaveDatos) {
                    Console.WriteLine("entra a condicion");
                    if (i == seleccionNumero) {
                        seleccion = sleecion2;
                        Console.WriteLine("Partida Encontrada");
                    }
                    Console.WriteLine("sale de condicion");
                    i++;
                }
                Console.WriteLine("El nombre de la partida a la que te unes es: " + seleccion);
                Lobby lobby = new Lobby();
                lobby.setIdioma(idioma);
                lobby.setPartida(seleccion);
                lobby.getID(idJugador);
                lobby.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void crearBT_Click(object sender, RoutedEventArgs e) {
            try {
                MiLlamadaDeVuelta mi = new MiLlamadaDeVuelta();
                ServiceReference4.ChatClient servidor = new ServiceReference4.ChatClient(new InstanceContext(mi));
                String nombre = nombreTB.Text;
                servidor.crearPartida(nombre);
                ServiceReference4.Service1Client service;
                service = new ServiceReference4.Service1Client();
                String usuarioN;
                usuarioN = service.getUsuarioUsuario(idJugador);
                Console.WriteLine("10 " + usuarioN + " 55 " + nombre);
                Lobby lobby = new Lobby();
                lobby.setIdioma(idioma);
                lobby.setPartida(nombre);
                lobby.getID(idJugador);
                lobby.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void cancelarBT_Click(object sender, RoutedEventArgs e) {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.getID(idJugador);
            menuPrincipal.setIdioma(idioma);
            menuPrincipal.Show();
            this.Close();
        }
    }
}