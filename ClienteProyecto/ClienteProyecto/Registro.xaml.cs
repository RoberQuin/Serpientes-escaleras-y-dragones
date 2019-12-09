using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace ClienteProyecto {

    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window {
        private bool contraseniaVisible = false;
        private int idioma;

        public Registro() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void aceptarBT_Click(object sender, RoutedEventArgs e) {
            try {
                igualarContrasenias();
                int validacion = validarDatosJugador();
                if (validacion == 0) {
                    return;
                }
                ServiceReference4.Jugador jugador = new ServiceReference4.Jugador();
                jugador.contrasenia = ComputeSha256Hash(contraseniaTF.Password);
                jugador.email = correoTF.Text;
                jugador.estado = 0;
                if (validarCadena(nombreTF.Text)) {
                    jugador.nombre = nombreTF.Text;
                } else {
                    MessageBox.Show("Error en el nombre");
                    return;
                }
                if (validarCadena(usuarioTF.Text)) {
                    jugador.usuario = usuarioTF.Text;
                } else {
                    MessageBox.Show("Error en el Usuario");
                    return;
                }
                jugador.campania = 0;
                jugador.fichaCampania = 0;
                jugador.idioma = 0;
                jugador.partidasJugadas = 0;
                jugador.codigo = generarCodigo();
                int validacionCorreo = 0;
                validacionCorreo = enviarCodigo(jugador.codigo);
                if (validacionCorreo != 0) {
                    MessageBox.Show("Ocurrio un error al enviar el correo", "Error");
                    return;
                }
                ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
                servicio.InsertarJugador(jugador);
                //mandar a la ventana validar
                Validar validar = new Validar();
                validar.setIdioma(idioma);
                validar.Show();
                this.Close();
            } catch (System.ServiceModel.EndpointNotFoundException) {
                MessageBox.Show("Hubo un error al conectar con el servidor", "Error en el host");
            }
        }

        /// <summary>
        /// metodo que iguala las contraseñas visibles y no visibles para unificarlas
        /// </summary>
        private void igualarContrasenias() {
            if (contraseniaVisible == true) {
                contraseniaTF.Password = verContraTF.Text;
            }
        }

        /// <summary>
        /// metodo que envia el codigo del
        /// </summary>
        /// <param name="codigo"></param>
        private int enviarCodigo(String codigo) {
            try {
                String mensaje;
                String asunto;
                if (idioma == 0) {
                    mensaje = Properties.Resources.StringMensaje;
                    asunto = Properties.Resources.StringAsunto;
                } else {
                    mensaje = Properties.Recursos.StringMensaje;
                    asunto = Properties.Recursos.StringAsunto;
                }
                ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();
                return service.enviarCodigo(codigo, correoTF.Text, asunto, mensaje);
            } catch (Exception) {
                MessageBox.Show("No se pudo mandar el correo");
                return 1;
            }
        }

        /// <summary>
        /// metodo que establece el idioma de la ventana
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
            contraseniaLB.Content = Properties.Recursos.labelContrasena;
            correoLB.Content = Properties.Recursos.labelCorreo;
            nombreLB.Content = Properties.Recursos.labelNombre;
            registroLB.Content = Properties.Recursos.labelRegistrar;
            restriccionContraseniaLB.Content = Properties.Recursos.labelRestriccionContrasena;
            restriccionEmailLB.Content = Properties.Recursos.labelRestriccionEmail;
            restriccionNombreLB.Content = Properties.Recursos.labelRestriccionNombre;
            restriccionUsuarioLB.Content = Properties.Recursos.labelRestriccionusuario;
            usuarioLB.Content = Properties.Recursos.labelUsuario;
            aceptarBT.Content = Properties.Recursos.buttonAceptar;
            cancelarBT.Content = Properties.Recursos.buttonCancelar;
            mostrarContraBT.Content = Properties.Recursos.buttonMostrarContrasena;
        }

        /// <summary>
        /// metodo que genera el codigo de verificacion
        /// </summary>
        /// <returns>codigo de verificacion</returns>
        private string generarCodigo() {
            String codigo = "";
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            for (int i = 0; i < 5; i++) {
                codigo += random.Next(0, 10);
            }
            return codigo;
        }

        /// <summary>
        /// metodo que valida los datos ingresados
        /// </summary>
        /// <returns></returns>
        private int validarDatosJugador() {
            if (nombreTF.Text.Length < 1) {
                MessageBox.Show("Existe un error en tu nombre, por favor revisalo", "Error");
                return 0;
            }
            ServiceReference4.Service1Client servicio = new ServiceReference4.Service1Client();
            int yaExiste = servicio.VerificarUsuarioExistente(usuarioTF.Text);
            if (yaExiste == 1) {
                MessageBox.Show("El usuario ya existe", "Ya existe");
                return 0;
            }
            if (usuarioTF.Text.Length < 3) {
                MessageBox.Show("Existe un error en tu usuario, por favor revisalo", "Error");
                return 0;
            }
            if (contraseniaTF.Password.Length < 5) {
                MessageBox.Show("Existe un error en tu contraseña, por favor revisalo", "Error");
                return 0;
            }
            if (correoTF.Text.Length < 1 || correoTF.Text.Length > 50) {
                MessageBox.Show("Existe un error en tu correo, por favor revisalo", "Error");
                return 0;
            }
            /*validacionCaracteres = validarCadena(nombreTF.Text);
            if(vali)*/
            return 1;
        }

        /// <summary>
        /// metodo que cambia los datos de un texto a un codigo encriptado
        /// </summary>
        /// <param name="rawData">datos a encriptar</param>
        /// <returns>codigo resultante</returns>
        private string ComputeSha256Hash(string rawData) {
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (contraseniaVisible == false) {
                contraseniaTF.Visibility = Visibility.Hidden;
                verContraTF.Visibility = Visibility.Visible;
                verContraTF.Text = contraseniaTF.Password;
                contraseniaVisible = true;
                mostrarContraBT.Content = "Ocultar Contraseña";
            } else {
                contraseniaTF.Visibility = Visibility.Visible;
                verContraTF.Visibility = Visibility.Hidden;
                contraseniaTF.Password = verContraTF.Text;
                contraseniaVisible = false;
                mostrarContraBT.Content = "Mostrar Contraseña";
            }
        }

        private void cancelarBT_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.setIdioma(idioma);
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// metodo que valida la cadena ingresada
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public bool validarCadena(String dato) {
            bool revision = true;
            foreach (char caracter in dato) {
                String c = caracter.ToString();
                int code = Encoding.ASCII.GetBytes(c)[0];
                if (code != 32) {
                    if (code < 65 || code > 122 || (code > 91 && code < 97)) {
                        revision = false;
                    }
                }
            }
            return revision;
        }
    }
}