using Cyon.common;
using Cyon.game;
using Cyon.realm;
using Cyon.Utils.Java;
using Cyon.Utils.Java.net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cyon
{
    class Program
    {
        private static string CONFIG_FILE = "CyonConfig.ini";
        public static bool isRunning = false;
        public static bool isInit = false;
        
	    public static string IP = "127.0.0.1";
        public static string DB_HOST;
        public static string DB_USER;
        public static string DB_PASS;
        public static string STATIC_DB_NAME;
        public static string OTHER_DB_NAME;

        public static string GAMESERVER_IP;
        public static string CONFIG_MOTD = "";
        public static string CONFIG_MOTD_COLOR = "";
        public static string CONFIG_MOTD_COLORS = "";
        public static string CONFIG_MOTD_COLORR = "";
        public static string CONFIG_MOTD_ZOZO = "";
        public static bool CONFIG_DEBUG = false;
        //public static PrintStream PS;
        public static bool CONFIG_POLICY = false;
        public static int CONFIG_REALM_PORT = 443;
        public static int CONFIG_GAME_PORT = 5555;

        public static bool CONFIG_ALLOW_MULTI = false;
        public static int CONFIG_START_LEVEL = 1;
        public static int CONFIG_START_KAMAS = 0;
        public static string START_ITEMS = "9999999:1";
        public static string MAP_NO_PRISMES = "18004,18003,15032,15031,15030,15029,15028,935,528,9454,951,1242,164,1158,8037,8437,8088,8125,8163,10643,11170,1841,844,11210,4263,3022,6855,6137,3250,4739,5295,8785,7411,6954,2191,10297,10349,10304,10317";

        public static long INCARNAM_TIME = 30000;
        public static int CONFIG_SAVE_TIME = 10 * 60 * 10000;
        public static int CONFIG_DROP = 1;
        public static bool CONFIG_ZAAP = true;
        public static int CONFIG_PLAYER_LIMIT = 30;
        public static bool CONFIG_IP_LOOPBACK = true;

        public static int XP_PVP = 10;
        public static int LVL_PVP = 15;
        public static bool ALLOW_MULE_PVP = false;
        public static int XP_PVM = 1;
        public static int KAMAS = 1;
        public static int HONOR = 1;
        public static int XP_METIER = 1;
        public static int PORC_FM = 1;
        public static int CONFIG_LVLMAXMONTURE = 100;

        public static bool CONFIG_USE_MOBS = false;
        public static bool CONFIG_USE_IP = false;
        public static GameServer gameServer;
        public static RealmServer realmServer;

        public static bool isSaving = false;
        public static bool AURA_SYSTEM = false;

        public static List<int> arenaMap = new List<int>(8);
        public static int CONFIG_ARENA_TIMER = 10 * 60 * 1000;// 10 minutes
        public static int CONFIG_DB_COMMIT = 30 * 1000;
        public static int CONFIG_MAX_IDLE_TIME = 1800000;//En millisecondes
        public static List<int> NOTINHDV = new List<int>();

        public static bool SHOW_RECV = false;
        public static int PLAYER_IP = 3;

        public static int serverID = 1;

        public static int pa = 18;
        public static int pm = 8;

        public static int CONFIG_TIME_REBOOT = 25160000;
        public static bool CONFIG_REBOOT_AUTO = false;
        public static int CONFIG_LOAD_DELAY = 60000;

        public static bool CONFIG_ACTIVER_STATS_2 = false;


        public static short CONFIG_MAP_PVP = 952;
        public static int CONFIG_CELL_PVP = 252;
        public static short CONFIG_MAP_PVM = 1372;
        public static int CONFIG_CELL_PVM = 195;
        public static short CONFIG_MAP_SHOP = 10114;
        public static int CONFIG_CELL_SHOP = 282;
        public static short CONFIG_MAP_EVENT = 18004;
        public static int CONFIG_CELL_EVENT = 274;
        public static short CONFIG_MAP_ENCLOS = 18004;
        public static int CONFIG_CELL_ENCLOS = 274;
        public static short CONFIG_MAP_COMMERCE = 7411;
        public static int CONFIG_CELL_COMMERCE = 200;

        public static string PUB1 = "";
        public static string PUB2 = "";
        public static string PUB3 = "";
        public static bool CONFIG_PUB = false;
        public static int MORPH_VIP = 8006;

        public static long CONFIG_MS_PER_TURN = 30000;
        public static long CONFIG_MS_FOR_START_FIGHT = 45000;

        public static List<int> FEED_MOUNT_ITEM = new List<int>();
        public static List<int> CartesNoPrismes = new List<int>();

        public static bool CONFIG_XP_DEFI = false;

        static void Main(string[] args)
        {
            Runtime.getRuntime().addShutdownHook(new Thread(Run));
            ConsoleWriter.clear();
            ConsoleWriter.setTitle("Cyon Remake - Cargando...");
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println(makeHeader());
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println("Cargando la configuracion..");
            loadConfiguration();
            isInit = true;
            ConsoleWriter.println("configuracion lista.");
            ConsoleWriter.println("Conectandose con MySQL server.");
            if (SQLManager.setUpConnexion())
                ConsoleWriter.println("Conexion lista.");
            else
            {
                ConsoleWriter.println("Conexion invalida.");
                closeServers();
                Environment.Exit(0);
            }
            ConsoleWriter.println("Creando el mundo.\n");
            var startTime = TimeSpan.FromMilliseconds(Environment.TickCount) ;//System.currentTimeMillis();
            World.createWorld();
            var differenceTime = startTime.ToString("ss");
            ConsoleWriter.println("\nEmulator listo en : " + differenceTime + " s");
            isRunning = true;
            ConsoleWriter.println("==============================================================\n");
            //ConsoleWriter.println("Esperando conexiones entrantes, puerto de juego: " + CONFIG_GAME_PORT);
            string Ip = "";
            try
            {
                Ip = InetAddress.getLocalHost().getHostAddress();
            }
            catch (Exception e)
            {
                ConsoleWriter.println(e.Message);
                try
                {
                    Thread.Sleep(10000);
                }
                catch (Exception e1) { }
                Console.ReadKey();
                Environment.Exit(1);

            }
            Ip = IP;
            gameServer = new GameServer(Ip);
            
            realmServer = new RealmServer();
            ConsoleWriter.println("IP du serveur: " + IP);
            //refreshTitle();
            //EmuStart();¿
            GC.Collect();
        }

        private static void refreshTitle()
        {
            if (!isRunning) return;
            StringBuilder title = new StringBuilder();
            title.Append("Cyon - REALMPort: ").Append(CONFIG_REALM_PORT).Append(" GAMEPort: ").Append(CONFIG_GAME_PORT);
            //title.Append(" En linea: ").Append(gameServer.getPlayerNumber()).append(" Statut: ");
            switch (World.get_state())
            {
                case (short)1: title.Append("Disponible"); break;
                case (short)2: title.Append("Guardando"); break;
                default: title.Append("Desconectado"); break;
            }
            ConsoleWriter.setTitle(title.ToString());
        }

        private static void EmuStart()
        {
            ConsoleWriter.clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println(makeHeader());
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println("\nCyon Remake Emu: Esperando conexiones...");
            ConsoleWriter.println(string.Format("\n'Ayuda' o '?' para ver la lista de comandos disponibles en la consola.",Console.ForegroundColor = ConsoleColor.Red));
            new ConsoleWriter();
        }

        private static void ReStart()
        {
            ConsoleWriter.clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println(makeHeader());
            ConsoleWriter.println("==============================================================\n");
            ConsoleWriter.println(string.Format("'Ayuda' o '?' para ver la lista de comandos disponibles en la consola.", Console.ForegroundColor = ConsoleColor.Yellow));
            new ConsoleWriter();
        }

        private static void loadConfiguration()
        {
            try
            {
                StreamReader config = new StreamReader(CONFIG_FILE);
                string line = "";
                while ((line = config.ReadLine()) != null)
                {
                    if (line.Split('=').Length == 1) continue;
                    string param = line.Split('=')[0].Trim();
                    string value = line.Split('=')[1].Trim();
                    if (param.Equals("DEBUG"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_DEBUG = true;
                            ConsoleWriter.println("Modo Debug: ON");
                        }
                    }
                    else if (param.Equals("SEND_POLICY"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_POLICY = true;
                        }
                    }
                    else if (param.Equals("START_ITEMS"))
                    {
                        if (value == "")
                            START_ITEMS = null;
                        else
                            START_ITEMS = value;
                    }
                    else if (param.Equals("START_KAMAs"))
                    {
                        CONFIG_START_KAMAS = int.Parse(value);
                        if (CONFIG_START_KAMAS < 0)
                            CONFIG_START_KAMAS = 0;
                        if (CONFIG_START_KAMAS > 1000000000)
                            CONFIG_START_KAMAS = 1000000000;
                    }
                    else if (param.Equals("START_LEVEL"))
                    {
                        CONFIG_START_LEVEL = int.Parse(value);
                        if (CONFIG_START_LEVEL < 1)
                            CONFIG_START_LEVEL = 1;
                        if (CONFIG_START_LEVEL > 200)
                            CONFIG_START_LEVEL = 200;
                    }
                    else if (param.Equals("PUB1"))
                    {
                        PUB1 = value;

                    }
                    else if (param.Equals("PUB2"))
                    {
                        PUB2 = value;
                    }
                    else if (param.Equals("PUB3"))
                    {
                        PUB3 = value;
                    }
                    else if (param.Equals("ACTIV_PUB"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_PUB = true;
                        }

                    }
                    else if (param.Equals("SHOP_MAP"))
                    {
                        CONFIG_MAP_SHOP = short.Parse(value);
                    }
                    else if (param.Equals("SHOP_CELL"))
                    {
                        CONFIG_CELL_SHOP = int.Parse(value);
                    }
                    else if (param.Equals("PVM_MAP"))
                    {
                        CONFIG_MAP_PVM = short.Parse(value);
                    }
                    else if (param.Equals("PVM_CELL"))
                    {
                        CONFIG_CELL_PVM = int.Parse(value);
                    }
                    else if (param.Equals("COMMERCE_MAP"))
                    {
                        CONFIG_MAP_COMMERCE = short.Parse(value);
                    }
                    else if (param.Equals("COMMERCE_CELL"))
                    {
                        CONFIG_CELL_COMMERCE = int.Parse(value);
                    }
                    else if (param.Equals("LOAD_ACTION_DELAY"))
                    {
                        CONFIG_LOAD_DELAY = (int.Parse(value) * 1000);
                    }
                    else if (param.Equals("PVP_MAP"))
                    {
                        CONFIG_MAP_PVP = short.Parse(value);
                    }
                    else if (param.Equals("PVP_CELL"))
                    {
                        CONFIG_CELL_PVP = int.Parse(value);
                    }
                    else if (param.Equals("KAMAS"))
                    {
                        KAMAS = int.Parse(value);
                    }
                    else if (param.Equals("HONOR"))
                    {
                        HONOR = int.Parse(value);
                    }
                    else if (param.Equals("SAVE_TIME"))
                    {
                        CONFIG_SAVE_TIME = int.Parse(value) * 60 * 1000000000;
                    }
                    else if (param.Equals("XP_PVM"))
                    {
                        XP_PVM = int.Parse(value);
                    }
                    else if (param.Equals("XP_PVP"))
                    {
                        XP_PVP = int.Parse(value);
                    }
                    else if (param.Equals("MAX_LEVEL_MONTURE"))
                    {
                        CONFIG_LVLMAXMONTURE = (int.Parse(value));

                    }
                    else if (param.Equals("LVL_PVP"))
                    {
                        LVL_PVP = int.Parse(value);
                    }
                    else if (param.Equals("PLAYER_IP"))
                    {
                        PLAYER_IP = int.Parse(value);
                    }
                    else if (param.Equals("DROP"))
                    {
                        CONFIG_DROP = int.Parse(value);
                    }
                    else if (param.Equals("MOTD"))
                    {
                        CONFIG_MOTD = line.Split('=')[1];
                    }
                    else if (param.Equals("PORC_FM"))
                    {
                        PORC_FM = int.Parse(value);
                    }
                    else if (param.Equals("LOCALIP_LOOPBACK"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_IP_LOOPBACK = true;
                        }
                    }
                    else if (param.Equals("MAP_NO_PRISMES"))
                    {
                        foreach (string curID in value.Split(','))
                        {
                            CartesNoPrismes.Add(int.Parse(curID));
                        }
                    }
                    else if (param.Equals("ZAAP"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_ZAAP = true;
                        }
                    }
                    else if (param.Equals("ACTIV_CARACT_2"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_ACTIVER_STATS_2 = true;
                        }
                    }
                    else if (param.Equals("ACTIV_REBOOT"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_REBOOT_AUTO = true;
                        }
                    }
                    else if (param.Equals("USE_IP"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_USE_IP = true;
                        }
                    }
                    else if (param.Equals("MOTD_COLOR"))
                    {
                        CONFIG_MOTD_COLOR = value;
                    }
                    else if (param.Equals("XP_METIER"))
                    {
                        XP_METIER = int.Parse(value);
                    }
                    else if (param.Equals("GAME_PORT"))
                    {
                        CONFIG_GAME_PORT = int.Parse(value);
                    }
                    else if (param.Equals("REALM_PORT"))
                    {
                        CONFIG_REALM_PORT = int.Parse(value);
                    }
                    else if (param.Equals("HOST_IP"))
                    {
                        IP = value;
                    }
                    else if (param.Equals("DB_HOST"))
                    {
                        DB_HOST = value;
                    }
                    else if (param.Equals("DB_USER"))
                    {
                        DB_USER = value;
                    }
                    else if (param.Equals("DB_PASS"))
                    {
                        if (value == null) value = "";
                        DB_PASS = value;
                    }
                    else if (param.Equals("STATIC_DB_NAME"))
                    {
                        STATIC_DB_NAME = value;
                    }
                    else if (param.Equals("OTHER_DB_NAME"))
                    {
                        OTHER_DB_NAME = value;
                    }
                    else if (param.Equals("USE_MOBS"))
                    {
                        CONFIG_USE_MOBS = value.Equals("true");
                    }
                    else if (param.Equals("ALLOW_MULTI_ACCOUNT"))
                    {
                        CONFIG_ALLOW_MULTI = value.Equals("true");
                    }
                    else if (param.Equals("PLAYER_LIMIT"))
                    {
                        CONFIG_PLAYER_LIMIT = int.Parse(value);
                    }
                    else if (param.Equals("ARENA_MAP"))
                    {
                        foreach (string curID in value.Split(','))
                        {
                            arenaMap.Add(int.Parse(curID));
                        }
                    }
                    else if (param.Equals("ARENA_TIMER"))
                    {
                        CONFIG_ARENA_TIMER = int.Parse(value);
                    }
                    else if (param.Equals("AURA_SYSTEM"))
                    {
                        AURA_SYSTEM = value.Equals("true");
                    }
                    else if (param.Equals("ACTIVER_XP_DEFI"))
                    {
                        if (value.Equals("true"))
                        {
                            CONFIG_XP_DEFI = true;
                        }
                    }
                    else if (param.Equals("ALLOW_MULE_PVP"))
                    {
                        ALLOW_MULE_PVP = value.Equals("true");
                    }
                    else if (param.Equals("MAX_IDLE_TIME"))
                    {
                        CONFIG_MAX_IDLE_TIME = (int.Parse(value) * 60000);
                    }
                    else if (param.Equals("SERVER_ID"))
                    {
                        serverID = int.Parse(value);
                    }
                    else if (param.Equals("NOT_IN_HDV"))
                    {
                        foreach (string curID in value.Split(','))
                        {
                            NOTINHDV.Add(int.Parse(curID));
                        }
                    }
                    else if (param.Equals("MAXPA"))
                    {
                        pa = int.Parse(value);
                    }
                    else if (param.Equals("MAXPM"))
                    {
                        pm = int.Parse(value);
                    }
                    else if (param.Equals("REBOOT_TIME"))
                    {
                        CONFIG_TIME_REBOOT = int.Parse(value);
                    }
                    else if (param.Equals("FEED_MOUNT"))
                    {
                        foreach (string curID in value.Split(','))
                        {
                            FEED_MOUNT_ITEM.Add(int.Parse(curID));
                        }
                    }
                    else if (param.Equals("SHOW_RECV"))

                    {
                        SHOW_RECV = value.Equals("true");
                    }
                }
                if (STATIC_DB_NAME == null || OTHER_DB_NAME == null || DB_HOST == null || DB_PASS == null || DB_USER == null)
                {
                    throw new Exception();
                }

                config.Close();
            }
            catch (Exception e)
            {
                ConsoleWriter.println(e.Message);
                ConsoleWriter.println("El archivo de configuracion no se encontro o hay errores de lectura!");
                ConsoleWriter.println("Fermeture du serveur...");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }

        private static string makeHeader()
        {
            
            StringBuilder mess = new StringBuilder();
            mess.Append("-");
            mess.Append("\nCyon Remake Emu V" + Constants.SERVER_VERSION);
            mess.Append("\nBy " + Constants.SERVER_MAKER + ".");
            mess.Append("\n-");
            return mess.ToString();
        }

        private static void Run()
        {
            closeServers();
        }

        public static void closeServers()
        {
            if(isRunning == false)
            {
                Console.Write("Cierre el servidor... ");
                Console.Write("Servidor cerrado!\n");
                Console.ReadKey();
            }
            if (isRunning == true)
            {
                while(isRunning==true)
                {
                    Console.ReadLine();
                }
                
            }
        }
    }
}
