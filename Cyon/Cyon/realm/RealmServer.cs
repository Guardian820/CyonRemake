using Cyon.common;
using Cyon.Utils.Java;
using Cyon.Utils.Java.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cyon.realm
{
    class RealmServer : Runnable
    {
        private Thread _t;

        private Socket _socket;


        public static int _totalNonAbo = 0;//Total de connections non abo
        public static int _totalAbo = 0;//Total de connections abo
        public static int _queueID = -1;//Numéro de la queue
        public static int _subscribe = 1;//File des non abonnées (0) ou abonnées (1)

        public static List<RealmServer> realm_client = new List<RealmServer>();

        public RealmServer()
        {
            try
            {
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress address = IPAddress.Parse(Program.IP);
                IPEndPoint localEP = new IPEndPoint(address, Program.CONFIG_REALM_PORT);
                this._socket.Bind(localEP);
                this._socket.Listen(10);
                Thread thread = new Thread(new ThreadStart(this.Run));
                thread.Start();
                ConsoleWriter.println("Esperando conexiones entrantes, puerto de conexion: " + Program.CONFIG_REALM_PORT);
            }
            catch (Exception e)
            {
                ConsoleWriter.println("Fallo al conectar el servidor!");
                ConsoleWriter.println(e.Message);
            }
        }
        
        public void Run()
        {
            while (Program.isRunning)//bloque sur _SS.accept()
            {
                try
                {
                    Socket _ss = _socket.Accept();
                    ConsoleWriter.println("RealmServer: Cliente conectado!");
                    // RealmThread client = new RealmThread(_ss);
                    new RealmThread(_ss);

                }
                catch (Exception e)
                {
                    //if (!_SS.isClosed())
                    //    _SS.close();
                    ConsoleWriter.println(e.Message);
                }
            }
        }
    }
}
