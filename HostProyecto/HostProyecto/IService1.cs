using ADO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HostProyecto {

    /// <summary>
    /// interface implementada por el servidor para brindar las funcionalidades de control de cuentas
    /// </summary>
    [ServiceContract]
    public interface IService1 {

        /// <summary>
        /// metodo que obtiene a un jugador
        /// </summary>
        /// <param name="value">nombre del jugador</param>
        /// <returns></returns>
        [OperationContract]
        Jugador GetJugador(int value);

        /// <summary>
        /// metodo que obtiene la informacion del contrato de conexion
        /// </summary>
        /// <param name="composite">tipo de composisicion</param>
        /// <returns></returns>
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        /// <summary>
        /// metodo que obtiene un contrato
        /// </summary>
        /// <param name="casilla">casilla</param>
        /// <returns></returns>
        [OperationContract]
        Casilla GetDataUsingDataContract1(Casilla casilla);

        /// <summary>
        /// metodo que agrega un nuevo jugador a la base de datos
        /// </summary>
        /// <param name="jugador">jugador a agregar</param>
        /// <returns>resultado de validacion</returns>
        [OperationContract]
        int InsertarJugador(Jugador jugador);

        /// <summary>
        /// metodo que valida si un usuario ya existe
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>resultado de validacion</returns>
        [OperationContract]
        int VerificarUsuarioExistente(String usuario);

        /// <summary>
        /// metodo que vaida a un usuario
        /// </summary>
        /// <param name="codigo">codigo de validacion</param>
        /// <returns>resultado de la validacion</returns>
        [OperationContract]
        bool validarUsusario(String codigo);

        /// <summary>
        /// metodo que inetnta ingresar al sistema
        /// </summary>
        /// <param name="usuario">usuario ingresado</param>
        /// <param name="contrasenia">contraseña ingresada</param>
        /// <returns></returns>
        [OperationContract]
        int login(String usuario, String contrasenia);

        /// <summary>
        /// metodo que obtiene el esatdo de un jugador
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <returns>estado del jugador</returns>
        [OperationContract]
        int getEstado(int id);

        /// <summary>
        /// metdoo que obtiene las puntiuaciones del juego
        /// </summary>
        /// <returns>lista de puntuaciones</returns>
        [OperationContract]
        List<string> getPuntuaciones();

        /// <summary>
        /// metodo que obtiene los usuarios  alos que pertenecen las puntuaaciones
        /// </summary>
        /// <returns>lista de usuarios</returns>
        [OperationContract]
        List<string> getUsuariosPuntuaciones();

        /// <summary>
        /// metodo que obtiene el atributo usuario de un usaurio
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>nombre del usuario</returns>
        [OperationContract]
        String getUsuarioUsuario(int id);

        /// <summary>
        /// metodo que obteiene le avance en la campaña de un jugador
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <returns>avance del jugador</returns>
        [OperationContract]
        int GetCampaniaJugador(int id);

        /// <summary>
        /// metodo que cambia el estado del jugador en la campaña
        /// </summary>
        /// <param name="id"></param>
        /// <param name="campania"></param>
        [OperationContract]
        void SetCampaniaJugador(int id, int campania);

        /// <summary>
        /// metodo que agrega un mensaje a la lista de mensajes del servidor
        /// </summary>
        /// <param name="id">id del jugador</param>
        /// <param name="mensaje">mensaje del jugador</param>
        /// <param name="mensajes">lista de mensajes</param>
        /// <returns></returns>
        [OperationContract]
        List<String> agregarMensaje(int id, String mensaje, List<String> mensajes);

        /// <summary>
        /// metodo que envia un codigo al coreo electronico del usuario
        /// </summary>
        /// <param name="codigo">codigo a envuiar</param>
        /// <param name="correo">correo del destino</param>
        /// <param name="asunto">asunto del correo</param>
        /// <param name="mensaje">mensaje del corre</param>
        /// <returns></returns>
        [OperationContract]
        int enviarCodigo(String codigo, string correo, string asunto, string mensaje);

        /// <summary>
        /// metodo que btiene la ficha de campaña del jugador
        /// </summary>
        /// <param name="idJugador">id del juagdor</param>
        /// <returns>numero de ficha del jugador</returns>
        [OperationContract]
        int getFichaJugador(int idJugador);

        /// <summary>
        /// metodo que cambia las opciones de configuaracion de un jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="idioma">idioma de un jugador</param>
        /// <param name="ficha">ficha de un jugador</param>
        /// <returns></returns>
        [OperationContract]
        int setOpciones(int idJugador, int idioma, int ficha);

        /// <summary>
        /// metodo que obtiene el idioma preferido de un jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <returns>idioma del jugador</returns>
        [OperationContract]
        int getIdiomaJugador(int idJugador);

        /// <summary>
        /// metodo que agrega una puntuacion de victoria a la base de datos
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="turnos">turnos de victoria</param>
        /// <returns></returns>
        [OperationContract]
        int agregarPuntuacionVictoria(int idJugador, int turnos);
    }

    [DataContract]
    public class CompositeType {
        private bool boolValue = true;
        private string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class ChatControl {
        private List<String> chat;

        [DataMember]
        public List<string> Chat { get { return chat; } set { chat = value; } }
    }

    /// <summary>
    /// clase para el manejo de las casillas de un tablero
    /// </summary>
    [DataContract]
    public class Casilla {
        private int estado;
        private int columna;
        private int fila;
        private int columnaDestino;
        private int filaDestino;
        private int tipo;
        private int numeroCasillla;
        private int casillasCambios;
        private int casillaDestino;

        [DataMember]
        public int Estado { get => estado; set => estado = value; }

        [DataMember]
        public int Columna { get => columna; set => columna = value; }

        [DataMember]
        public int Fila { get => fila; set => fila = value; }

        [DataMember]
        public int ColumnaDestino { get => columnaDestino; set => columnaDestino = value; }

        [DataMember]
        public int FilaDestino { get => filaDestino; set => filaDestino = value; }

        [DataMember]
        public int Tipo { get => tipo; set => tipo = value; }

        [DataMember]
        public int NumeroCasillla { get => numeroCasillla; set => numeroCasillla = value; }

        [DataMember]
        public int CasillasCambios { get => casillasCambios; set => casillasCambios = value; }

        [DataMember]
        public int CasillaDestino { get => casillaDestino; set => casillaDestino = value; }
    }
}