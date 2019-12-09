using ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;

namespace HostProyecto {
    /// <summary>
    /// clase que contine la implementacion de la interfaz IService1
    /// </summary>
    public partial class Service1 : IService1 {
        public List<String> chatMensajes = new List<string>();

        public String getUsuarioUsuario(int id) {
            Model1Container BD = new Model1Container();
            Jugador jugador;
            jugador = BD.JugadorSet.Find(id);
            String regreso = jugador.usuario;
            return regreso;
        }

        public List<String> agregarMensaje(int id, string mensaje, List<String> mensajes) {
            Model1Container BD = new Model1Container();
            Jugador usuario;
            usuario = BD.JugadorSet.Find(id);
            mensajes.Add(usuario.usuario + ": " + mensaje);
            return mensajes;
        }

        public string GetData(int value) {
            return "1";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

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

        public string GetPrueba() {
            return "dfghjk";
        }

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

        public int InsertarJugador(Jugador jugador) {
            Model1Container BD = new Model1Container();
            BD.JugadorSet.Add(jugador);
            BD.SaveChanges();
            return 1;
        }

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

        public Casilla GetDataUsingDataContract1(Casilla casilla) {
            throw new NotImplementedException();
        }

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

        public void SetCampaniaJugador(int id, int campania) {
            Model1Container BD = new Model1Container();
            using (BD) {
                var jugador = BD.JugadorSet.Where(j => j.Id == id).FirstOrDefault();
                jugador.campania = campania;
                BD.Entry(jugador).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();
            }
        }

        public int enviarCodigo(String codigo, string correo,string asunto,string mensaje) {
            var fromAddress = new MailAddress("serpientesescalerasydragones@gmail.com", "SerpientesEscDra");
            var toAddress = new MailAddress("" + correo, "Destino");
            const string fromPassword = "serpientesydragones";
            string subject = asunto;
            string body = mensaje + codigo;

            var smtp = new SmtpClient {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress) {
                Subject = subject,
                Body = body
            }) {
                smtp.Send(message);
            }
            return 0;
        }

        public int getFichaJugador(int idJugador) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = BD.JugadorSet.ToList();
            foreach(Jugador jugador in lista) {
                if (jugador.Id == idJugador) {
                    return jugador.fichaCampania;
                }
            }
            return 200;
        }

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

        public int getIdiomaJugador(int idJugador) {
            Model1Container BD = new Model1Container();
            List<Jugador> lista = BD.JugadorSet.ToList();
            foreach (Jugador jugador in lista) {
                if (jugador.Id == idJugador) {
                    Console.WriteLine("idioma: "+jugador.idioma+" jugador: "+jugador.usuario);
                    return jugador.idioma;
                }
            }
            return 200;
        }

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

        Dictionary<IChatCliente, String> usuarios = new Dictionary<IChatCliente, string>();
        Dictionary<String, Partida> partidas = new Dictionary<String, Partida>();

        public void crearPartida(String nombre) {
            Partida partida = new Partida();
            partida.Nombre = nombre;
            partidas.Add(partida.Nombre,partida);
        }

        public void entrarJuego(string nombre,int tablero,int muerteSubita) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            partida.MuerteSubita = muerteSubita;
            int i =0;
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.ResiveEntradaMulti(i,tablero,muerteSubita);
                i++;
            }
        }

        public void enviarMensaje(string mensaje,String nombre) {
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

        public List<String> getPartidas() {
            List<String> lista = new List<string>();
            String resultado;
            if (partidas.Count() == 0) {
                return lista;
            }
            foreach(Partida otro in partidas.Values) {
                resultado = "Nombre: " + otro.Nombre + "\nLider de partida:   " + otro.Usuarios.First().Value + "Jug" +
                    "adores actuales:  " + otro.Usuarios.Count();
                lista.Add(resultado);
            }
            return lista;
        }

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

        public void moverDragones(int estado, string nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            foreach (var otro in partida.Usuarios.Keys) {
                otro.moverDragones1(estado);
                Console.WriteLine("-------------------"+otro);
            }
        }

        public void pasarTurno(int jugador, string nombre) {/////////////////////////////////////////
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            int i = 1;
            foreach (var otro in partida.Usuarios.Keys) {
                if (i == jugador) {
                    otro.quitarTurno();
                    Console.WriteLine("jfdbiydf"+i+"  quito turno");
                }
                if (i == jugador + 1) {
                    otro.pasarTurno1();
                    Console.WriteLine("jfdbiydf" + i + "  paso turno");
                }
                if (jugador + 1==5) {
                    if (i==1) {
                        otro.pasarTurno1();
                        Console.WriteLine("jfdbiydf" + i + "  paso turno");
                    }
                }
                i++;
            }
        }

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

        public void pintarMovimiento1(int columna, int fila, string nombre,int numeroEntrada) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return;
            }
            int i=1;
            foreach (var otro in partida.Usuarios.Keys) {
                Console.WriteLine("el usuario es:" + otro);
                otro.pintarMovimiento(columna,fila,numeroEntrada);
                Console.WriteLine("mando a pintar movimiento con" + i);
            }
            //return 1;
        }

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
            /*Partida partida;
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
                    otro.ResiveSalida(i);
                    i++;
                }
                
                Console.WriteLine("fue mandado a actuaizar el usuario: " + otro);
            }
            foreach (var otro in partida.Usuarios.Keys) {
                if (otro == conexion) {
                    partida.Usuarios.Remove(conexion);
                    Console.WriteLine("fue borrado el usuario: "+otro);
                }
            }
            Console.WriteLine("no mando excepcion antes");*/
        }

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

        public int unirse(string usuario, String nombre) {
            Partida partida;
            if (!partidas.TryGetValue(nombre, out partida)) {
                return 8;
            }
            
            if (partida.Usuarios.Count<4) {
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
                Console.WriteLine("el usuario es:"+otro);
                otro.ResiveUsuario(usuariosDevuelto);
            }
        }
    }
    public partial class Partida {
        Dictionary<IChatCliente, String> usuarios = new Dictionary<IChatCliente, string>();
        String nombre;
        int numeroPartida;
        int numeroTablero;
        int posicionJugador1;
        int posicionJugador2;
        int posicionJugador3;
        int posicionJugador4;
        int muerteSubita;
        int turnos;

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
