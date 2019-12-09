using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteProyecto {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        bool contraseniaVisible = false;
        int idioma=0;
        public MainWindow() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void inicioBT_Click(object sender, RoutedEventArgs e) {
            try {
                igualarContrasenias();
                String usuario = usuarioTB.Text;
                String contrasenia = ComputeSha256Hash(contraseniaTB.Password);
                int idJugador;
                ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
                idJugador = servicio.login(usuario, contrasenia);
                if (idJugador == 0) {
                    MessageBox.Show("tu usuario o contraseña no son validos", "error");
                    return;
                } else {
                    var estado = servicio.getEstado(idJugador);
                    if (estado == 0) {
                        MessageBox.Show("para ingresar debes validar tu cuenta", "error");
                        return;
                    }
                }

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.getID(idJugador);
                menuPrincipal.setIdioma(idioma);

                menuPrincipal.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor","Error en el host");
            }
        }

        private void validarBT_Click(object sender, RoutedEventArgs e) {
            Validar validar = new Validar();
            validar.setIdioma(idioma);
            validar.Show();
            this.Close();
        }

        private void registrarBT_Click(object sender, RoutedEventArgs e) {
            Registro registro = new Registro();
            registro.setIdioma(idioma);
            registro.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que cambia los numeros y letras por encriptaciones
        /// </summary>
        /// <param name="rawData">datos a encriptar</param>
        /// <returns></returns>
        private string ComputeSha256Hash(string rawData) {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (contraseniaVisible == false) {
                contraseniaTB.Visibility = Visibility.Hidden;
                verContraTF.Visibility = Visibility.Visible;
                verContraTF.Text = contraseniaTB.Password;
                contraseniaVisible = true;
                mostrarContraBT.Content = "Ocultar Contraseña";
            } else {
                contraseniaTB.Visibility = Visibility.Visible;
                verContraTF.Visibility = Visibility.Hidden;
                contraseniaTB.Password = verContraTF.Text;
                contraseniaVisible = false;
                mostrarContraBT.Content = "Mostrar Contraseña";
            }
        }

        /// <summary>
        /// metodo que iguala las contraseñas visible y no visible para el acceso de sesion
        /// </summary>
        private void igualarContrasenias() {
            if (contraseniaVisible == true) {
                contraseniaTB.Password = verContraTF.Text;
            }
        }

        private void inglesCI_Selected(object sender, RoutedEventArgs e) {
            idioma = 0;
            usuarioLB.Content = Properties.Resources.buttonValidar;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void espanolCI_Selected(object sender, RoutedEventArgs e) {
            idioma = 1;
            aplicarIdioma();
        }

        /// <summary>
        /// metodo que determina el idioma de la ventana
        /// </summary>
        /// <param name="idioma">idioma de la ventana</param>
        internal void setIdioma(int idioma) {
            this.idioma = idioma;
            if (idioma != 0) {
                aplicarIdioma();
                //idiomaCB.SelectedItem = espanolCI;
            } else{
                //idiomaCB.SelectedItem = inglesCI; 
            }
        }

        /// <summary>
        /// metodo que aplica el idioma español
        /// </summary>
        private void aplicarIdioma() {
            usuarioLB.Content = Properties.Recursos.labelUsuario;
            registroLB.Content = Properties.Recursos.labelRegistro;
            contraseniaLB.Content = Properties.Recursos.labelContrasena;
            idiomaLB.Content = Properties.Recursos.labelIdioma;
            inicioBT.Content = Properties.Recursos.buttonIniciarSesion;
            registrarBT.Content = Properties.Recursos.buttonRegistrar;
            validarBT.Content = Properties.Recursos.buttonValidar;
            mostrarContraBT.Content = Properties.Recursos.buttonMostrarContrasena;
            imagenTituloIG.Source = new BitmapImage(new 
                Uri("Imagenes/TituloImagenesEspanol" +
                "RD.png",UriKind.Relative));
        }

    }
}
