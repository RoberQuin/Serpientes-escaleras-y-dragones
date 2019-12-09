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
    /// Clase ayuda
    /// La clase Ayuda permite generar los textos de ayuda y de acerca de, dependiendo del idioma usado
    /// </summary>
    public partial class Ayuda : Window {
        int idioma;
        public Ayuda() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void aceptarBT_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        /// <summary>
        /// metodo que muestra el "acerca de" del juego en español
        /// </summary>
        internal void ayudaEspanol() {
            tituloTF.Content = "Acerca de";
            contenidoTB.Text = "Juego desarrollado por Luis Angel Olivo Martínez y roberto" +
                "quiñones cordova como proyecto para las clases de Tecnologias para la construccion de" +
                " software y diseño de interfaces de usuario" +
                "\n \n juego no desarrollado con fines de lucro y unicamente con fines academicos" +
                "15/10/2019";
            aceptarBT.Content = Properties.Recursos.buttonAceptar;
        }

        /// <summary>
        /// metodo que muestra el "acerca de" en español
        /// </summary>
        internal void ayudaIngles() {
            tituloTF.Content = "About";
            contenidoTB.Text = "Game developed by Luis Angel Olivo Martínez y roberto" +
             "Quiñones Cordova as a project for the Technology classes for the construction of" +
             "software and user interface design" +
             "\n \n game not developed for profit and only for academic purposes" +
             "10/15/2019";
            
        }

        /// <summary>
        /// metodo que muestra la ayuda en ingles
        /// </summary>
        internal void acecaIngles() {
            tituloTF.Content = "Help";
            contenidoTB.Text = "Options for the game: \nCampaña: \nStart or continue your adventure" +
             "to conquer the different stages of time \nMultiplayer: \nAdventure in an experience" +
             "Multiplayer to prove your superiority against three opponents \nOptions: \n" +
             "Customize your experience with options that suit your gaming experience \n" +
             "Best scores: \nCheck who has surpassed you, who you surpassed or if you are the" +
             "best player of the game";
        }

        /// <summary>
        /// metodo que muestra la ayuda en español
        /// </summary>
        internal void acercaEspanol() {
            tituloTF.Content = "Ayuda";
            contenidoTB.Text = "Opciones para el juego:\nCampaña:\nInicia o continua tu aventura " +
                "para conquistar las diferentes etapas del tiempo\nMultijugador:\nAventurate en una experiencia" +
                "multijugador para demostrar tu superioridad contra tres oponentes\nOpciones:\n" +
                "Personaliza tu experiencia con opciones que se adapten a tu experiencia del juego\n" +
                "Mejores puntuaciones:\nRevisa quienes te han superado, a quien superaste o si eres el " +
                "mejor jugador del juego";
            aceptarBT.Content = Properties.Recursos.buttonAceptar;
        }
    }
}
