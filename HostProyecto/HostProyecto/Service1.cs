using ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;

namespace HostProyecto {

    /// <summary>
    /// clase que contine la implementacion de la interfaz IService1
    /// </summary>
    public partial class Service1 : IService1 {
        public List<String> chatMensajes = new List<string>();

        /// <summary>
        /// metodo que obtiene un nombre de jugador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getUsuarioUsuario(int id) {
            Model1Container BD = new Model1Container();
            Jugador jugador;
            jugador = BD.JugadorSet.Find(id);
            String regreso = jugador.usuario;
            return regreso;
        }

        /// <summary>
        /// metodo que agrega un mensaje a una partida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mensaje"></param>
        /// <param name="mensajes"></param>
        /// <returns></returns>
        public List<String> agregarMensaje(int id, string mensaje, List<String> mensajes) {
            Model1Container BD = new Model1Container();
            Jugador usuario;
            usuario = BD.JugadorSet.Find(id);
            mensajes.Add(usuario.usuario + ": " + mensaje);
            return mensajes;
        }

        /// <summary>
        /// metodo que obtiene un dato de prueba
        /// </summary>
        /// <param name="value">valor de prueba</param>
        /// <returns></returns>
        public string GetData(int value) {
            return "1";
        }

        /// <summary>
        /// metodo que obtiene el contrato que se esta usando
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// metodo que obtiene el estado de un jugador
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <returns></returns>
        public int getEstado(int id) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == id) {
                    return jugador.estado;
                }
            }
            return 0;
        }

        /// <summary>
        /// metodo que obtiene un jugador con su id
        /// </summary>
        /// <param name="value">id del jugador</param>
        /// <returns></returns>
        public Jugador GetJugador(int value) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == value) {
                    return jugador;
                }
            }
            return null;
        }

        /// <summary>
        /// metdoo que obtiene una prueba de string
        /// </summary>
        /// <returns></returns>
        public string GetPrueba() {
            return "dfghjk";
        }

        /// <summary>
        /// metodo que obtiene las puntuacions ordenenadas de menor a mayor
        /// </summary>
        /// <returns></returns>
        public List<String> getPuntuaciones() {
            Model1Container model1Container = new Model1Container();
            var groupByReference = model1Container.PuntuacionSet.ToList();
            List<Puntuacion> puntuacions = groupByReference.OrderBy(o => o.puntuacion).ToList();
            List<string> lista = new List<string>();
            int i = 0;
            foreach (Puntuacion puntuacion in puntuacions) {
                if (i > 9) {
                    break;
                }
                var punt = "";
                punt = puntuacion.puntuacion.ToString();
                lista.Add(punt);
            }
            return lista;
        }

        /// <summary>
        /// metod que obtiene los usuarios de las puntuaciones
        /// </summary>
        /// <returns></returns>
        public List<string> getUsuariosPuntuaciones() {
            Model1Container model1Container = new Model1Container();
            var groupByReference = model1Container.PuntuacionSet.ToList();
            List<Puntuacion> puntuacions = groupByReference.OrderBy(o => o.puntuacion).ToList();
            List<string> lista = new List<string>();
            int i = 0;
            foreach (Puntuacion puntuacion in puntuacions) {
                if (i > 9) {
                    break;
                }
                var punt = "";
                punt = puntuacion.puntuacion.ToString();
                lista.Add(puntuacion.Jugador.usuario);
            }
            return lista;
        }

        /// <summary>
        /// metodo que inserta un jugador a la base de datos
        /// </summary>
        /// <param name="jugador">jugador a insertar</param>
        /// <returns></returns>
        public int InsertarJugador(Jugador jugador) {
            Model1Container BD = new Model1Container();
            BD.JugadorSet.Add(jugador);
            BD.SaveChanges();
            return 1;
        }

        /// <summary>
        /// metodo que intenta hacer el login de un usaurio
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="contrasenia">contraseña</param>
        /// <returns></returns>
        public int login(string usuario, string contrasenia) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.usuario == usuario) {
                    if (jugador.contrasenia == contrasenia) {
                        return jugador.Id;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// metdoo que valida la cuenta de un usuario
        /// </summary>
        /// <param name="codigo">codigo ingresado</param>
        /// <returns></returns>
        public bool validarUsusario(string codigo) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.codigo == codigo) {
                    jugador.estado = 1;
                    BD.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// metodo que verifica si un usuario ya existe
        /// </summary>
        /// <param name="usuario">usuario a comprobar</param>
        /// <returns></returns>
        public int VerificarUsuarioExistente(String usuario) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.usuario == usuario) {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// metodo que regresa una casilla
        /// </summary>
        /// <param name="casilla"></param>
        /// <returns></returns>
        public Casilla GetDataUsingDataContract1(Casilla casilla) {
            return new Casilla();
        }

        /// <summary>
        /// metodo que obtiene el avance en campaña de un jugador
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <returns>numero de avance del jugador</returns>
        public int GetCampaniaJugador(int id) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = new List<Jugador>();
            lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == id) {
                    return jugador.campania;
                }
            }
            return 10;
        }

        /// <summary>
        /// metodo que actualiza el avance de la campaña de un jugador
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <param name="campania">numero de cambio</param>
        public void SetCampaniaJugador(int id, int campania) {
            Model1Container BD = new Model1Container();
            using (BD) {
                var jugador = BD.JugadorSet.Where(j => j.Id == id).FirstOrDefault();
                jugador.campania = campania;
                BD.Entry(jugador).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();
            }
        }

        /// <summary>
        /// metdoo que envia un codigo al correo del usuairio
        /// </summary>
        /// <param name="codigo">codigo del mensaje</param>
        /// <param name="correo">correo del jugador</param>
        /// <param name="asunto">asunto del corre</param>
        /// <param name="mensaje">mensaje del correo</param>
        /// <returns></returns>
        public int enviarCodigo(String codigo, string correo, string asunto, string mensaje) {
            int correcto = 0;
            System.Net.Mail.MailMessage mensaje1 = new System.Net.Mail.MailMessage();
            mensaje1.To.Add(correo);
            mensaje1.Subject = asunto;
            mensaje1.SubjectEncoding = System.Text.Encoding.UTF8;
            String mensajeCorreo = mensaje + codigo;
            mensaje1.Body = mensajeCorreo;
            mensaje1.IsBodyHtml = true;
            mensaje1.BodyEncoding = System.Text.Encoding.UTF8;
            mensaje1.IsBodyHtml = true;
            mensaje1.From = new System.Net.Mail.MailAddress("serpientesescalerasydragones@gmail.com");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("serpientesescalerasydragones@gmail.com", "serpientesydragones");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try {
                cliente.Send(mensaje1);
            } catch (SmtpException) {
                correcto = 1;
            }
            return correcto;
        }

        /// <summary>
        /// metodo que obtiene la ficha de campaña de un jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <returns>ficha del jugador</returns>
        public int getFichaJugador(int idJugador) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == idJugador) {
                    return jugador.fichaCampania;
                }
            }
            return 200;
        }

        /// <summary>
        /// metodo que actualiza la configuracion de un usuario
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="idioma">idioma del usuario</param>
        /// <param name="ficha">ficha del jugador</param>
        /// <returns>resultado de la actualizacion</returns>
        public int setOpciones(int idJugador, int idioma, int ficha) {
            Model1Container BD = new Model1Container();
            using (BD) {
                var jugador = BD.JugadorSet.Where(j => j.Id == idJugador).FirstOrDefault();
                jugador.idioma = idioma;
                jugador.fichaCampania = ficha;
                BD.Entry(jugador).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// metodo que obtiene el idioma del jugador en la base de datos
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <returns>idioma del jugador</returns>
        public int getIdiomaJugador(int idJugador) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == idJugador) {
                    Console.WriteLine("idioma: " + jugador.idioma + " jugador: " + jugador.usuario);
                    return jugador.idioma;
                }
            }
            return 200;
        }

        /// <summary>
        /// metodo que agrega la puntuacion de una victoria
        /// </summary>
        /// <param name="idJugador"></param>
        /// <param name="turnos"></param>
        /// <returns></returns>
        public int agregarPuntuacionVictoria(int idJugador, int turnos) {
            Jugador jugador1 = new Jugador();
            Model1Container BD = new Model1Container();
            List<Jugador> lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == idJugador) {
                    Console.WriteLine("idioma: " + jugador.idioma + " jugador: " + jugador.usuario);
                    jugador1 = jugador;
                }
            }
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Jugador = jugador1;
            puntuacion.puntuacion = turnos;
            puntuacion.fecha = DateTime.Now;
            return 1;
        }
    }

    /// <summary>
    /// clase que implementa la interfaz de IChat
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public partial class Service1 : IChat {
        private Dictionary<IChatCliente, String> usuarios = new Dictionary<IChatCliente, string>();
        private Dictionary<String, Partida> partidas = new Dictionary<String, Partida>();

        /// <summary>
        /// metodo que crea una partida en el servidor
        /// </summary>
        /// <param name="nombre">nombre de la partida</param>
        public void crearPartida(String nombre) {
            Partida partida = new Partida();
            partida.Nombre = nombre;
            partidas.Add(partida.Nombre, partida);
        }

        /// <summary>
        /// metodo que 
        /// </summary>
        /// <param name="nombre">nombre de la partida</param>
        /// <param name="tablero">tablero de la partida</param>
        /// <param name="muerteSubita">numero de turnos para la muerte subita</param>
        public void entrarJuego(string nombre, int tablero, int muerteSubita) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            partida.MuerteSubita = muerteSubita;
            int i = 0;
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.ResiveEntradaMulti(i, tablero, muerteSubita);
                i++;
            }
        }

        /// <summary>
        /// metodo que envia un mensaje a los jugadores de una partida
        /// </summary>
        /// <param name="mensaje">mensaje a escribir en la pantalla</param>
        /// <param name="nombre">nombre de la partida</param>
        public void enviarMensaje(string mensaje, String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            String usuario;
            if (!partida.Usuarios.TryGetValue(conexion, out usuario)) {
                return;
            }
            foreach (var otro in partida.Usuarios.Keys) {
                /*if (otro == conexion) {
                    continue;
                }*/
                otro.ResiveMensaje(usuario, mensaje);
            }
        }

        /// <summary>
        /// metdoo que envia un mensaje a los jugadores en una partida mutijugador
        /// </summary>
        /// <param name="mensaje">mensaje a escribir</param>
        /// <param name="nombre">nombre de la partida</param>
        public void enviarMensajeJuego(string mensaje, string nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            String usuario;
            if (!partida.Usuarios.TryGetValue(conexion, out usuario)) {
                return;
            }
            foreach (var otro in partida.Usuarios.Keys) {
                /*if (otro == conexion) {
                    continue;
                }*/
                otro.ResiveMensajeJuego(usuario, mensaje);
            }
        }

        /// <summary>
        /// metdoo que muestra la victoria de un jugador a los usuario
        /// </summary>
        /// <param name="jugador">jugador</param>
        /// <param name="nombre">nombre de la partida</param>
        public void ganoJugador(String jugador, string nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            int i = 1;
            foreach (var otro in partida.Usuarios.Keys) {
                otro.ganoJugador1(jugador, i);
            }
            partida.Usuarios.Clear();
        }

        /// <summary>
        /// metdoo que obtiene el numero de entrada de un jugador despues de un cambio
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="nombre">nombre de la partida</param>
        /// <returns></returns>
        public int getNuevoNumeroJugador(string usuario, string nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return 8;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            int i = 0;
            foreach (var otro in partida.Usuarios.Keys) {
                if (otro == conexion) {
                    return i;
                }
                i++;
            }
            return 50;
        }

        /// <summary>
        /// metdoo que obtiene el numero de entrada de un jugador a una partida
        /// </summary>
        /// <param name="usuario">usuario </param>
        /// <param name="nombre">nombre de la partida</param>
        /// <returns></returns>
        public int getNumeroJugador(String usuario, String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return 8;
            }

            if (partida.Usuarios.Count < 4) {
                if (partida.Usuarios.Count == 0) {
                    return 1;
                }
                if (partida.Usuarios.Count == 1) {
                    return 2;
                }
                if (partida.Usuarios.Count == 2) {
                    return 3;
                }
                if (partida.Usuarios.Count == 3) {
                    return 4;
                }
                return 50;
            } else {
                return 50;
            }
        }

        /// <summary>
        /// metodo que obtiene una lista de partidas disponibles
        /// </summary>
        /// <returns>lista de partidas</returns>
        public List<String> getPartidas() {
            List<String> lista = new List<string>();
            String resultado;
            if (partidas.Count() == 0) {
                return lista;
            }
            foreach (Partida otro in partidas.Values) {
                resultado = "Nombre: " + otro.Nombre + "\nLider de partida:   " + otro.Usuarios.First().Value + "Jug" +
                    "adores actuales:  " + otro.Usuarios.Count();
                lista.Add(resultado);
            }
            return lista;
        }

        /// <summary>
        /// metodo que obtiene las caracteristicas de las partidas disponibles
        /// </summary>
        /// <returns>lista de caracteristicas de las partidas disponibles</returns>
        public List<String> getPartidasClave() {
            List<String> lista = new List<string>();
            String resultado;
            if (partidas.Count() == 0) {
                return lista;
            }
            foreach (Partida otro in partidas.Values) {
                resultado = otro.Nombre;
                lista.Add(resultado);
            }
            return lista;
        }

        /// <summary>
        /// metdoo que mueve la posicion de los dragones de los jugadores
        /// </summary>
        /// <param name="estado">estado de el tablero</param>
        /// <param name="nombre">nombre de la partida</param>
        public void moverDragones(int estado, string nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            foreach (var otro in partida.Usuarios.Keys) {
                otro.moverDragones1(estado);
                Console.WriteLine("-------------------" + otro);
            }
        }

        /// <summary>
        /// metdoo que pasa el turno de un jugador a otro
        /// </summary>
        /// <param name="jugador">nombre del jugador</param>
        /// <param name="nombre">nombre de la partida</param>
        public void pasarTurno(int jugador, string nombre) {/////////////////////////////////////////
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            int i = 1;
            foreach (var otro in partida.Usuarios.Keys) {
                if (i == jugador) {
                    otro.quitarTurno();
                    Console.WriteLine("jfdbiydf" + i + "  quito turno");
                }
                if (i == jugador + 1) {
                    otro.pasarTurno1();
                    Console.WriteLine("jfdbiydf" + i + "  paso turno");
                }
                if (jugador + 1 == 5) {
                    if (i == 1) {
                        otro.pasarTurno1();
                        Console.WriteLine("jfdbiydf" + i + "  paso turno");
                    }
                }
                i++;
            }
        }

        /// <summary>
        /// metodo que muetsra el tiro de un dado a los jugadores
        /// </summary>
        /// <param name="tiro">tiro</param>
        /// <param name="nombre">nombre de la partida</param>
        public void pintadDado(int tiro, String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.pintarDado(tiro);
            }
        }

        /// <summary>
        /// metdfoo que muestra el movimiento de un jugador
        /// </summary>
        /// <param name="columna">columna de destino a mover</param>
        /// <param name="fila">fila de destino a mover</param>
        /// <param name="nombre">nombr del jugador a mover</param>
        /// <param name="numeroEntrada">numero de entrada del jugador</param>
        public void pintarMovimiento1(int columna, int fila, string nombre, int numeroEntrada) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            int i = 1;
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.pintarMovimiento(columna, fila, numeroEntrada);
                Console.WriteLine("mando a pintar movimiento con" + i);
            }
        }

        /// <summary>
        /// metdoo que saca a un jugador de una partida
        /// </summary>
        /// <param name="nombre"></param>
        public void salir(String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            String usuario;
            if (!partida.Usuarios.TryGetValue(conexion, out usuario)) {
                return;
            }
            int i = 0;
            foreach (var otro in partida.Usuarios.Keys) {
                if (otro != conexion) {
                    otro.ResiveSalidaJuegoLobby(i);
                    i++;
                } else {
                    otro.ResiveSalidaJuegoAbandonaLobby();
                }

                Console.WriteLine("fue mandado a actuaizar el usuario: " + otro);
            }
            partidas.Remove(nombre);
            Console.WriteLine("no mando excepcion antes");
        }

        /// <summary>
        /// metdoo que sale de una partida
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="nombre">nombre de la partida</param>
        /// <param name="numeroEntrada">numero de entrada a una partida</param>
        public void salirJuego(int idJugador, string nombre, int numeroEntrada) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            String usuario;
            if (!partida.Usuarios.TryGetValue(conexion, out usuario)) {
                return;
            }
            int i = 0;
            foreach (var otro in partida.Usuarios.Keys) {
                if (otro != conexion) {
                    otro.ResiveSalidaJuego(i);
                    i++;
                } else {
                    otro.ResiveSalidaJuegoAbandona();
                }

                Console.WriteLine("fue mandado a actuaizar el usuario: " + otro);
            }
            partidas.Remove(nombre);
            Console.WriteLine("no mando excepcion antes");
        }

        /// <summary>
        /// metdoo que une a un jugador a una partida
        /// </summary>
        /// <param name="usuario">usuairo a ingresar</param>
        /// <param name="nombre">nombre de la partida</param>
        /// <returns></returns>
        public int unirse(string usuario, String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return 8;
            }

            if (partida.Usuarios.Count < 4) {
                if (partida.Usuarios.Count == 0) {
                    var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
                    partida.Usuarios[conexion] = usuario;

                    return 0;
                } else {
                    var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
                    partida.Usuarios[conexion] = usuario;
                    return 1;
                }
            } else {
                return 2;
            }
        }

        /// <summary>
        /// metdoo que une a un usuario a la lista de usuaris de un lobby
        /// </summary>
        /// <param name="nombre"></param>
        public void unirseUsuario(String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            var conexion = OperationContext.Current.GetCallbackChannel<IChatCliente>();
            String usuario;
            List<String> usuariosDevuelto = new List<string>();
            if (!partida.Usuarios.TryGetValue(conexion, out usuario)) {
                return;
            }
            foreach (var otro in partida.Usuarios) {
                usuariosDevuelto.Add(otro.Value);
            }
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.ResiveUsuario(usuariosDevuelto);
            }
        }
    }

    /// <summary>
    /// clase que maneja una partida
    /// </summary>
    public partial class Partida {
        private Dictionary<IChatCliente, String> usuarios = new Dictionary<IChatCliente, string>();
        private String nombre;
        private int numeroPartida;
        private int numeroTablero;
        private int posicionJugador1;
        private int posicionJugador2;
        private int posicionJugador3;
        private int posicionJugador4;
        private int muerteSubita;
        private int turnos;

        public int NumeroPartida { get => numeroPartida; set => numeroPartida = value; }
        public int NumeroTablero { get => numeroTablero; set => numeroTablero = value; }
        public int PosicionJugador1 { get => posicionJugador1; set => posicionJugador1 = value; }
        public int PosicionJugador2 { get => posicionJugador2; set => posicionJugador2 = value; }
        public int PosicionJugador3 { get => posicionJugador3; set => posicionJugador3 = value; }
        public int PosicionJugador4 { get => posicionJugador4; set => posicionJugador4 = value; }
        public int MuerteSubita { get => muerteSubita; set => muerteSubita = value; }
        public int Turnos { get => turnos; set => turnos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Dictionary<IChatCliente, string> Usuarios { get => usuarios; set => usuarios = value; }
    }
}