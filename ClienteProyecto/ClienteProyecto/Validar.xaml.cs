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
    /// Lógica de interacción para Validar.xaml
    /// </summary>
    public partial class Validar : Window {
        int idioma;
        public Validar() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void aceptarBT_Click(object sender, RoutedEventArgs e) {
            try {
                bool correcto = false;
                var codigo = codigoTF.Text;
                ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
                correcto = servicio.validarUsusario(codigo);
                if(correcto == true) {
                    MessageBox.Show("tu cuenta fue validada con exito","exito");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.setIdioma(idioma);
                    mainWindow.Show();
                    this.Close();
                } else {
                    MessageBox.Show("este codigo no pertenece a ningun usuario\nrevisalo por favor","error");
                }
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        private void cancelarBT_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.setIdioma(idioma);
            mainWindow.Show();
            this.Close();
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
            envioLB.Content = Properties.Recursos.labelVerificacion;
            verificacionLB.Content = Properties.Recursos.labelCodigoVerificacion;
            aceptarBT.Content = Properties.Recursos.buttonAceptar;
            cancelarBT.Content = Properties.Recursos.buttonCancelar;
        }
    }
}
