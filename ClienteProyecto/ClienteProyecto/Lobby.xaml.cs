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
    /// Lógica de interacción para Lobby.xaml
    /// </summary>
    public partial class Lobby : Window {
        List<String> vs = new List<string>();
        public Lobby() {
            InitializeComponent();
            
        }


        private void chatLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void enviarTF_Click(object sender, RoutedEventArgs e) {
            vs.Add(mensajeTF.Text);
            chatLB.ItemsSource = new List<String>();
            chatLB.ItemsSource = vs;
        }
    }
}
