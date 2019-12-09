using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WMPLib;

namespace ClienteProyecto {

    /// <summary>
    /// Lógica de interacción para JuegoCampaña.xaml
    /// </summary>
    public partial class JuegoCampaña : Window {
        private List<ServiceReference4.Casilla> casillas = new List<ServiceReference4.Casilla>();
        public int idJugador;
        public int idioma;
        public int numeroCampania;
        private int posicionJugador;
        private int posicionEnemigo;
        private int estado;
        private int tiro;
        private int avance = 0;
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// contructor que define el estado inicial de las variables
        /// </summary>
        public JuegoCampaña() {
            InitializeComponent();
            posicionJugador = 1;
            posicionEnemigo = 1;
            estado = 0;
            //oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo1.png", UriKind.Relative));
        }

        /// <summary>
        /// metodo que define las imagenes como enemigo y tablero del juego con base a un numero de tablero
        /// </summary>
        /// <param name="tablero">numero de tablero que define el nivel y las imagenes</param>
        public void ajustarImagenes(int tablero) {
            switch (tablero) {
                case 2: {
                    avance = 2;
                    player.URL = @"Sountrack/Level1.mp4";
                    player.controls.play();
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero1MT.png", UriKind.Relative));
                    cargarMapa1();
                    fichaEnemigoIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo1.png", UriKind.Relative));
                    oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo1.png", UriKind.Relative));
                }
                break;

                case 5: {
                    avance = 5;
                    player.URL = @"Soundtrack/Level2.mp4";
                    player.controls.play();
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero2_1.png", UriKind.Relative));
                    cargarMapa2();
                    fichaEnemigoIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png", UriKind.Relative));
                    oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png", UriKind.Relative));
                }
                break;

                case 8: {
                    avance = 8;
                    player.URL = @"Soundtrack/Level3.mp4";
                    player.controls.play();
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero3.png", UriKind.Relative));
                    cargarMapa3();
                    fichaEnemigoIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png", UriKind.Relative));
                    oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo2.png", UriKind.Relative));
                }
                break;

                case 11: {
                    avance = 11;
                    player.URL = @"Soundtrack/Level4.mp4";
                    player.controls.play();
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero4.png", UriKind.Relative));
                    cargarMapa4();
                    fichaEnemigoIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo4.png", UriKind.Relative));
                    oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo4.png", UriKind.Relative));
                }
                break;

                case 14: {
                    avance = 14;
                    player.URL = @"Soundtrack/Level5.mp4";
                    player.controls.play();
                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/tablero5.png", UriKind.Relative));
                    cargarMapa5();
                    fichaEnemigoIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo5.png", UriKind.Relative));
                    oponenteIMG.Source = new BitmapImage(new Uri("Imagenes/enemigo5.png", UriKind.Relative));
                }
                break;

                default: {
                    MessageBox.Show("Lo sentimos pero ocurrio un error inesperado y progreso se reinició", "Ocurrio" +
                        "un error");
                }
                break;
            }
        }

        /// <summary>
        /// metodo que define la interaccion del tiro del enemigo
        /// </summary>
        public void tirarEnemigo() {
            int columnaDestino = 0;
            int filaDestino = 0;
            Random random = new Random();
            tiro = random.Next(1, 6);
            for (int i = 1; i < 15; i++) {
                //Random random = new Random();
                int cambio = random.Next(1, 6);
                //pintarDado(cambio);
                SetTimerInterrupts();
                timer.IsEnabled = true;
                tiro = cambio;
            }
            pintarDado(tiro);
            int hipotetico = posicionEnemigo;
            if (hipotetico + tiro > 100) {
                hipotetico = hipotetico + tiro - 100;
                hipotetico = hipotetico * -1;
                tiro = hipotetico;
                posicionEnemigo = 100 + hipotetico;
            } else {
                posicionEnemigo += tiro;
            }

            foreach (ServiceReference4.Casilla casilla in casillas) {
                if (casilla.NumeroCasillla == posicionEnemigo) {
                    Console.WriteLine("E " + casilla.NumeroCasillla);
                    if (casilla.NumeroCasillla == 100) {
                        MessageBox.Show("Perdiste", "Vuelve a intentarlo");
                        player.controls.stop();
                        JuegoCampaña juego = new JuegoCampaña();
                        juego.getID(idJugador);
                        juego.setIdioma(idioma);
                        juego.ajustarImagenes(avance);
                        juego.Show();
                        this.Close();
                    }
                    if (casilla.Tipo == 0) {
                        columnaDestino = casilla.Columna;
                        filaDestino = casilla.Fila;
                    }
                    if (casilla.Tipo == 1 || casilla.Tipo == 2) {
                        columnaDestino = casilla.Columna;
                        filaDestino = casilla.Fila;
                        fichaEnemigoIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                        fichaEnemigoIMG.SetValue(Grid.RowProperty, filaDestino);
                        if (casilla.Tipo == 1) {
                            MessageBoxTemporal.Show("el enemigo cayó en una serpiente", "Serpiente", 0, true);
                        } else {
                            MessageBoxTemporal.Show("el enemigo cayó en una escalera", "Escalera", 0, true);
                        }
                        columnaDestino = casilla.ColumnaDestino;
                        filaDestino = casilla.FilaDestino;
                        posicionEnemigo += casilla.CasillasCambios;
                    }
                    if (casilla.Tipo == 3) {
                        if (estado == 0) {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                            fichaEnemigoIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                            fichaEnemigoIMG.SetValue(Grid.RowProperty, filaDestino);
                            MessageBoxTemporal.Show("el enemigo cayó en un dragon", "Dragon", 0, true);
                            if (estado == 0) {
                                estado = 1;
                                switch (numeroCampania) {
                                    case 1:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                    break;

                                    case 2:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1D.png", UriKind.Relative));
                                    break;

                                    case 3:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero3D.png", UriKind.Relative));
                                    break;

                                    case 4:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero4D.png", UriKind.Relative));
                                    break;

                                    case 5:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero5D.png", UriKind.Relative));
                                    break;
                                }
                                //tableroIMG.Source = new BitmapImage(new Uri("C:/Users/rockm/Desktop/5to Semestre/Tecnologias/10ma iteracion/ClienteProyecto/ClienteProyecto/Imagenes/Tablero1D.png"));
                            } else {
                                columnaDestino = casilla.Columna;
                                filaDestino = casilla.Fila;
                            }
                            columnaDestino = casilla.ColumnaDestino;
                            filaDestino = casilla.FilaDestino;
                            posicionEnemigo += casilla.CasillasCambios;
                        } else {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                        }
                    }
                } else
                if (estado == 1) {
                    if (casilla.CasillaDestino == posicionEnemigo) {
                        if (casilla.Tipo == 3) {
                            columnaDestino = casilla.ColumnaDestino;
                            filaDestino = casilla.FilaDestino;
                            fichaEnemigoIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                            fichaEnemigoIMG.SetValue(Grid.RowProperty, filaDestino);
                            MessageBoxTemporal.Show("el enemigo cayó en un dragon", "Dragon", 0, true);
                            if (estado == 0) {
                                estado = 1;
                                tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                            } else {
                                estado = 0;
                                switch (numeroCampania) {
                                    case 1:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1MT.png", UriKind.Relative));
                                    break;

                                    case 2:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1.png", UriKind.Relative));
                                    break;

                                    case 3:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                    break;

                                    case 4:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                    break;

                                    case 5:
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                    break;
                                }
                            }
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                            posicionEnemigo -= casilla.CasillasCambios;
                        }
                    }
                }
            }
            fichaEnemigoIMG.SetValue(Grid.ColumnProperty, columnaDestino);
            fichaEnemigoIMG.SetValue(Grid.RowProperty, filaDestino);
            tirarBT.IsEnabled = true;
            //Thread.Sleep(1000);
        }

        /// <summary>
        /// metodo que crea las instancias e imagenes del nivel 5
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
            numeroCampania = 2;
        }

        /// <summary>
        /// metodo que crea las instancias e imagenes del nivel 4
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
            numeroCampania = 4;
        }

        /// <summary>
        /// metodo que crea las instancias e imagenes del nivel 3
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
            numeroCampania = 3;
        }

        /// <summary>
        /// metodo que crea las instancias e imagenes del nivel 2
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
            numeroCampania = 2;
        }

        /// <summary>
        /// metodo que crea las instancias e imagenes del nivel 1
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
            numeroCampania = 1;
        }

        /// <summary>
        /// metodo que define la interaccion del juego cuando tira el jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tirarBT_Click(object sender, RoutedEventArgs e) {
            try {
                int columnaDestino = 0;
                int filaDestino = 0;
                Random random = new Random();
                tiro = random.Next(1, 7);
                pintarDado(tiro);
                for (int i = 1; i < 2; i++) {
                    //Random random = new Random();
                    int cambio = random.Next(1, 7);
                    //pintarDado(cambio);
                    SetTimerInterrupts();
                    timer.IsEnabled = true;
                    tiro = cambio;
                }
                pintarDado(tiro);
                Console.WriteLine("tiro del dado: " + tiro);
                int hipotetico = posicionJugador;
                if (hipotetico + tiro > 100) {
                    hipotetico = hipotetico + tiro - 100;
                    hipotetico = hipotetico * -1;
                    tiro = hipotetico;
                    posicionJugador = 100 + hipotetico;
                } else {
                    posicionJugador += tiro;
                }
                //posicionJugador += tiro;
                foreach (ServiceReference4.Casilla casilla in casillas) {
                    if (casilla.NumeroCasillla == posicionJugador) {
                        Console.WriteLine(casilla.NumeroCasillla);
                        if (casilla.NumeroCasillla == 100) {
                            MessageBox.Show("Ganaste!!", "Ganaste");
                            player.controls.stop();
                            manejarVictoria(avance);
                            break;
                        }
                        if (casilla.Tipo == 0) {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                        }
                        if (casilla.Tipo == 1 || casilla.Tipo == 2) {
                            columnaDestino = casilla.Columna;
                            filaDestino = casilla.Fila;
                            fichaJugadorIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                            fichaJugadorIMG.SetValue(Grid.RowProperty, filaDestino);
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
                                fichaJugadorIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                                fichaJugadorIMG.SetValue(Grid.RowProperty, filaDestino);
                                MessageBoxTemporal.Show("caiste en un dragon", "Dragon", 0, true);
                                if (estado == 0) {
                                    estado = 1;
                                    switch (numeroCampania) {
                                        case 1:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                        break;

                                        case 2:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1D.png", UriKind.Relative));
                                        break;

                                        case 3:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero3D.png", UriKind.Relative));
                                        break;

                                        case 4:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero4D.png", UriKind.Relative));
                                        break;

                                        case 5:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero5D.png", UriKind.Relative));
                                        break;
                                    }
                                } else {
                                    estado = 0;
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1MT.png", UriKind.Relative));
                                }
                                columnaDestino = casilla.ColumnaDestino;
                                filaDestino = casilla.FilaDestino;
                                posicionJugador += casilla.CasillasCambios;
                            } else {
                                columnaDestino = casilla.Columna;
                                filaDestino = casilla.Fila;
                            }
                        }
                    } else
                    if (estado == 1) {
                        if (casilla.CasillaDestino == posicionJugador) {
                            if (casilla.Tipo == 3) {
                                columnaDestino = casilla.ColumnaDestino;
                                filaDestino = casilla.FilaDestino;
                                fichaJugadorIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                                fichaJugadorIMG.SetValue(Grid.RowProperty, filaDestino);
                                MessageBoxTemporal.Show("caiste en un dragon", "Dragon", 0, true);
                                if (estado == 0) {
                                    estado = 1;
                                    tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                } else {
                                    estado = 0;
                                    switch (numeroCampania) {
                                        case 1:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1MT.png", UriKind.Relative));
                                        break;

                                        case 2:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero2_1.png", UriKind.Relative));
                                        break;

                                        case 3:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                        break;

                                        case 4:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                        break;

                                        case 5:
                                        tableroIMG.Source = new BitmapImage(new Uri("Imagenes/Tablero1D.png", UriKind.Relative));
                                        break;
                                    }
                                }
                                columnaDestino = casilla.Columna;
                                filaDestino = casilla.Fila;
                                posicionJugador -= casilla.CasillasCambios;
                            }
                        }
                    }
                }
                fichaJugadorIMG.SetValue(Grid.ColumnProperty, columnaDestino);
                fichaJugadorIMG.SetValue(Grid.RowProperty, filaDestino);
                tirarBT.IsEnabled = false;
                MessageBoxTemporal.Show("La computadora esta pensando", "Espere...", 0, true);
                tirarEnemigo();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            } catch (Exception) {
                MessageBox.Show("ocurrio un error inesperado", "error");
            }
        }

        /// <summary>
        /// metodo que define la interaccion cuando gana el jugador
        /// </summary>
        /// <param name="avance">numero de avance en la campaña del jugador</param>
        private void manejarVictoria(int avance) {
            ServiceReference4.Service1Client service1Client = new ServiceReference4.Service1Client();
            switch (avance) {
                case 2: {
                    service1Client.SetCampaniaJugador(idJugador, 3);
                    Historia historia = new Historia();
                    historia.getID(idJugador);
                    historia.setIdioma(idioma);
                    historia.setIMG(3);
                    historia.Show();
                    this.Close();
                }
                break;

                case 5: {
                    service1Client.SetCampaniaJugador(idJugador, 7);
                    Historia historia = new Historia();
                    historia.getID(idJugador);
                    historia.setIdioma(idioma);
                    historia.setIMG(7);
                    historia.Show();
                    this.Close();
                }
                break;

                case 8: {
                    service1Client.SetCampaniaJugador(idJugador, 10);
                    Historia historia = new Historia();
                    historia.getID(idJugador);
                    historia.setIdioma(idioma);
                    historia.setIMG(10);
                    historia.Show();
                    this.Close();
                }
                break;

                case 11: {
                    service1Client.SetCampaniaJugador(idJugador, 13);
                    Historia historia = new Historia();
                    historia.getID(idJugador);
                    historia.setIdioma(idioma);
                    historia.setIMG(13);
                    historia.Show();
                    this.Close();
                }
                break;

                case 14: {
                    service1Client.SetCampaniaJugador(idJugador, 16);
                    Historia historia = new Historia();
                    historia.getID(idJugador);
                    historia.setIdioma(idioma);
                    historia.setIMG(16);
                    historia.Show();
                    this.Close();
                }
                break;

                default: {
                    MessageBox.Show("Lo sentimos pero ocurrio un error inesperado y progreso se reinició", "Ocurrio" +
                        "un error");
                }
                break;
            }
        }

        /// <summary>
        /// metodo que cambia la imagen del dado
        /// </summary>
        /// <param name="tiro">numero de tiro que determina al dado</param>
        private void pintarDado(int tiro) {
            switch (tiro) {
                case 1: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado1.png", UriKind.Relative));
                }
                break;

                case 2: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado2.png", UriKind.Relative));
                }
                break;

                case 3: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado3.png", UriKind.Relative));
                }
                break;

                case 4: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado4.png", UriKind.Relative));
                }
                break;

                case 5: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado5.png", UriKind.Relative));
                }
                break;

                case 6: {
                    dadoIMG.Source = new BitmapImage(new Uri("Imagenes/dado6.png", UriKind.Relative));
                }
                break;

                default: {
                    Console.WriteLine("Error inesperado en el valor Random");
                }
                break;
            }
            //Thread.Sleep(500);
        }

        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// metodo que cambia el contador del timer
        /// </summary>
        private void SetTimerInterrupts() {
            timer.IsEnabled = false;
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e) {
            //Console.WriteLine("la fecha de hoy eso");
            pintarDado(tiro);
            //Console.WriteLine("tiro del dado: "+ tiro);
        }

        /// <summary>
        /// metodo que obtiene el ID del jugador
        /// </summary>
        /// <param name="idJugador">Id del jugador</param>
        internal void getID(int idJugador) {
            this.idJugador = idJugador;
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
            int fichaTu = service.getFichaJugador(idJugador);
            pintarFichaJugador(fichaTu);
        }

        /// <summary>
        /// metodo que muestra la interaccion del jugador al tirar
        /// </summary>
        /// <param name="fichaTu">numero de ficha</param>
        private void pintarFichaJugador(int fichaTu) {
            switch (fichaTu) {
                case 0: {
                    tuIMG.Source = new BitmapImage(new Uri("Imagenes/ficha1.png", UriKind.Relative));
                    fichaJugadorIMG.Source = new BitmapImage(new Uri("Imagenes/ficha1.png", UriKind.Relative));
                }
                break;

                case 1: {
                    tuIMG.Source = new BitmapImage(new Uri("Imagenes/ficha2.png", UriKind.Relative));
                    fichaJugadorIMG.Source = new BitmapImage(new Uri("Imagenes/ficha2.png", UriKind.Relative));
                }
                break;

                case 2: {
                    tuIMG.Source = new BitmapImage(new Uri("Imagenes/ficha3.png", UriKind.Relative));
                    fichaJugadorIMG.Source = new BitmapImage(new Uri("Imagenes/ficha3.png", UriKind.Relative));
                }
                break;

                case 3: {
                    tuIMG.Source = new BitmapImage(new Uri("Imagenes/ficha4.png", UriKind.Relative));
                    fichaJugadorIMG.Source = new BitmapImage(new Uri("Imagenes/ficha4.png", UriKind.Relative));
                }
                break;

                case 4: {
                    tuIMG.Source = new BitmapImage(new Uri("Imagenes/ficha5.png", UriKind.Relative));
                    fichaJugadorIMG.Source = new BitmapImage(new Uri("Imagenes/ficha5.png", UriKind.Relative));
                }
                break;
            }
        }

        /// <summary>
        /// metodo que obtiene el idioma del juego
        /// </summary>
        /// <param name="idioma">numero del idioma del juego</param>
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
            oponenteLB.Content = Properties.Recursos.labelOponente;
            tuLB.Content = Properties.Recursos.labelTu;
            tirarBT.Content = Properties.Recursos.buttonTirar;
        }

        /// <summary>
        /// metodo que sale del juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) {
            SeleccionJuego seleccion = new SeleccionJuego();
            seleccion.getID(idJugador);
            seleccion.setIdioma(idJugador);
            seleccion.Show();
            this.Close();
        }
    }
}