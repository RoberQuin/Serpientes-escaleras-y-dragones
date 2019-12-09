using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace HostProyecto {

    /// <summary>
    /// interfaz implementada por el sefvidor para brindar la funcionalidad de los servicios
    /// del servidor
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IChatCliente))]
    public interface IChat {

        /// <summary>
        /// Metodo que une a un jugador a una partida
        /// </summary>
        /// <param name="usuario">usuario a unir a la partida</param>
        /// <param name="nombre">nombre de la partida a la que se unira</param>
        /// <returns>nuemro del jugador en la partida</returns>
        [OperationContract]
        int unirse(String usuario, String nombre);

        /// <summary>
        /// metodo que envia un mensaje a los demas jugadres en una partida
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="nombre">partida</param>
        [OperationContract(IsOneWay = true)]
        void enviarMensaje(String mensaje, String nombre);

        /// <summary>
        /// metodo que envia un mensaje a los demas jugadres en una partida multijugador
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="nombre">partida</param>
        [OperationContract(IsOneWay = true)]
        void enviarMensajeJuego(String mensaje, String nombre);

        /// <summary>
        /// metodo que agrega a los demas jugadores el usuario recien unido
        /// </summary>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void unirseUsuario(String nombre);

        /// <summary>
        /// metodo para salir de una partida
        /// </summary>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void salir(string nombre);

        /// <summary>
        /// metodo que crea una partida
        /// </summary>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void crearPartida(String nombre);

        /// <summary>
        /// metodo que obtiene las partidas del servidor
        /// </summary>
        /// <returns>lista de partidas</returns>
        [OperationContract]
        List<String> getPartidas();

        /// <summary>
        /// metodo que oby¿tiene las claves de las partidas del servidor
        /// </summary>
        /// <returns>lista de claves</returns>
        [OperationContract]
        List<String> getPartidasClave();

        /// <summary>
        /// metodo que regresa el numero de jugador en la partida
        /// </summary>
        /// <param name="usuario">nombre del usuario</param>
        /// <param name="nombre">nombre de la partida</param>
        /// <returns>numero del jugador en la partida</returns>
        [OperationContract]
        int getNumeroJugador(String usuario, String nombre);

        /// <summary>
        /// metodo que obtiene el numero de jugador en la partida
        /// </summary>
        /// <param name="nombre">nobre del jugador</param>
        /// <param name="tablero">numero de tablero</param>
        /// <param name="muerteSubita">numero de turnos para muerte subita</param>
        [OperationContract(IsOneWay = true)]
        void entrarJuego(String nombre, int tablero, int muerteSubita);

        /// <summary>
        /// metodo que muestra el numero del dado
        /// </summary>
        /// <param name="tiro">numero de tiro para el dado</param>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void pintadDado(int tiro, String nombre);

        /// <summary>
        /// metodo que manda a llamar un metodo para mover a un jugador
        /// </summary>
        /// <param name="columna">columa de destino</param>
        /// <param name="fila">numero de fila de destino</param>
        /// <param name="nombre">nombre de el jugador</param>
        /// <param name="numeroEntrada">numero de entrada de jugador a la partida</param>
        [OperationContract(IsOneWay = true)]
        void pintarMovimiento1(int columna, int fila, String nombre, int numeroEntrada);

        /// <summary>
        /// metodo que pasa el turno de un jugador a otro
        /// </summary>
        /// <param name="jugador">nombre del jugador</param>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void pasarTurno(int jugador, String nombre);

        /// <summary>
        /// metodo que mueve los dragones de ubicacion
        /// </summary>
        /// <param name="estado">estado del tablero</param>
        /// <param name="nombre">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void moverDragones(int estado, String nombre);

        /// <summary>
        /// metodo que manda a llamar otro metodo que muestra la victoria de un jugador
        /// </summary>
        /// <param name="jugador">nombre del jugador</param>
        /// <param name="partida">nombre de la partida</param>
        [OperationContract(IsOneWay = true)]
        void ganoJugador(String jugador, String partida);

        /// <summary>
        /// metodo que sale del juego de un jugador
        /// </summary>
        /// <param name="idJugador">id del jugador</param>
        /// <param name="partida">nombre de la partida</param>
        /// <param name="numeroEntrada"></param>
        [OperationContract(IsOneWay = true)]
        void salirJuego(int idJugador, String partida, int numeroEntrada);

        /// <summary>
        /// metodo que obtiene el numero de jugador despues de un cambio en la lista de los jugadores
        /// </summary>
        /// <param name="usuario">nombre de el usuario</param>
        /// <param name="nombre">nombre de la partida</param>
        /// <returns>numero de jugador</returns>
        [OperationContract]
        int getNuevoNumeroJugador(String usuario, String nombre);
    }

    /// <summary>
    /// interfaz implementada por el cliente para recibir los mensajes del servidor
    /// </summary>
    [ServiceContract]
    public interface IChatCliente {

        /// <summary>
        /// metodo que recibe un mensaje para ecribirlo en el lobby
        /// </summary>
        /// <param name="usuario">nombre del usuario</param>
        /// <param name="mensaje">mensaje del usuario</param>
        [OperationContract(IsOneWay = true)]
        void ResiveMensaje(String usuario, String mensaje);

        /// <summary>
        /// metodo que recibe una lista de usuario spara ecribitlos en el lobby
        /// </summary>
        /// <param name="lista">lista de usuarios</param>
        [OperationContract(IsOneWay = true)]
        void ResiveUsuario(List<String> lista);

        /// <summary>
        /// metodo que recibe un usuario que quita de la lista del lobby
        /// </summary>
        /// <param name="numero">numero del jugador que se quita</param>
        [OperationContract(IsOneWay = true)]
        void ResiveSalida(int numero);

        /// <summary>
        /// metodo que recibe un mensaje que escribira en el chat del juego
        /// </summary>
        /// <param name="usuario">nombre del usuario</param>
        /// <param name="mensaje">mensaje del usuario</param>
        [OperationContract(IsOneWay = true)]
        void ResiveMensajeJuego(String usuario, String mensaje);

        /// <summary>
        /// metodo que que recibe una lista de usuarios que agregara al juego
        /// </summary>
        /// <param name="lista">lista de usuarios</param>
        [OperationContract(IsOneWay = true)]
        void ResiveUsuarioJuego(List<String> lista);

        /// <summary>
        /// metodo que recibe una saida de juego de un usaurio que quitara del juego
        /// </summary>
        /// <param name="numero">numero de jugador</param>
        [OperationContract(IsOneWay = true)]
        void ResiveSalidaJuego(int numero);

        /// <summary>
        /// metodo que recibe el abandono de un jugador
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ResiveSalidaJuegoAbandona();

        /// <summary>
        /// metodo que que recibe la entrada de un jugadior al multijugador y lo agrega en la ventana
        /// </summary>
        /// <param name="i">numero de jugador</param>
        /// <param name="tablero">numero de tablero</param>
        /// <param name="muerteSubita">numero de turnos para la muerte subita</param>
        [OperationContract(IsOneWay = true)]
        void ResiveEntradaMulti(int i, int tablero, int muerteSubita);

        /// <summary>
        /// metodo que recibe el tiro del dado parar mostrarlo en la ventana de multijugador
        /// </summary>
        /// <param name="tiro"></param>
        [OperationContract(IsOneWay = true)]
        void pintarDado(int tiro);

        /// <summary>
        /// metodo que recibe las coordenadas de un movimiento que muestra en las ventaanas de multij
        /// ugador
        /// </summary>
        /// <param name="columna">columna de destino</param>
        /// <param name="fila">fila de destino</param>
        /// <param name="jugador">nombre del jugador</param>
        [OperationContract(IsOneWay = true)]
        void pintarMovimiento(int columna, int fila, int jugador);

        /// <summary>
        /// metodo que pasa un turno a otro jugador
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void pasarTurno1();

        /// <summary>
        /// metodo que quita el turno a un jugador
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void quitarTurno();

        /// <summary>
        /// metodo que mueve la posicion de los dragones
        /// </summary>
        /// <param name="estado">estado del tablero</param>
        [OperationContract(IsOneWay = true)]
        void moverDragones1(int estado);

        /// <summary>
        /// metodo que muetsra en l aventana que ganó un jugadir
        /// </summary>
        /// <param name="Jugador">nombre del jugador que ganó</param>
        /// <param name="numeroJugador">numero de jugador actua</param>
        [OperationContract(IsOneWay = true)]
        void ganoJugador1(String Jugador, int numeroJugador);

        /// <summary>
        /// metodo que recibe la salida del jugador del lobby
        /// </summary>
        /// <param name="i">numero de jugador que salió</param>
        [OperationContract(IsOneWay = true)]
        void ResiveSalidaJuegoLobby(int i);

        /// <summary>
        /// metodo que recibe la salida de un jugador del lobby
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void ResiveSalidaJuegoAbandonaLobby();
    }
}