using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cyon.common
{
    class SQLManager
    {
        private static MySqlConnection othCon;

        public static void LOAD_EXP()
        {
            
        }

        private static MySqlConnection statCon;
        public static bool setUpConnexion()
        {
            try
            {

                othCon = new MySqlConnection();
                othCon.ConnectionString = string.Format("server={0};uid={1};pwd='{2}';database={3}", Program.DB_HOST, Program.DB_USER, Program.DB_PASS, Program.OTHER_DB_NAME);
                othCon.Open();

                statCon = new MySqlConnection();
                statCon.ConnectionString = string.Format("server={0};uid={1};pwd='{2}';database={3}", Program.DB_HOST, Program.DB_USER, Program.DB_PASS, Program.STATIC_DB_NAME);
                statCon.Open();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void LOAD_SORTS()
        {
            
        }

        public static void LOAD_MOB_TEMPLATE()
        {
            
        }

        public static void LOAD_OBJ_TEMPLATE()
        {
            
        }

        public static void LOAD_NPC_TEMPLATE()
        {
            
        }

        public static void LOAD_NPC_QUESTIONS()
        {
            
        }

        public static void LOAD_NPC_ANSWERS()
        {
            
        }

        public static void LOAD_AREA()
        {
            
        }

        public static void LOAD_SUBAREA()
        {
            
        }

        public static void LOAD_HDVS_ITEMS()
        {
            
        }

        public static void LOAD_IOTEMPLATE()
        {
            
        }

        public static void LOAD_HDVS()
        {
            
        }

        public static void LOAD_CRAFTS()
        {
            
        }

        public static int LOAD_BANIP()
        {
            int a = 0;
            return a;
        }

        public static void LOAD_JOBS()
        {
            
        }

        public static void LOAD_CHALLENGES()
        {
            
        }

        public static void LOAD_ITEMSETS()
        {
            
        }

        public static int LOAD_ZAAPIS()
        {
            int a = 0;
            return a;
        }

        public static void LOAD_MAPS()
        {
            
        }

        public static int LOAD_ZAAPS()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_TRIGGERS()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_TRUNK()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_ENDFIGHT_ACTIONS()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_HOUSES()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_NPCS()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_ITEM_ACTIONS()
        {
            int a = 0;
            return a;
        }

        public static int LOAD_PERCEPTEURS()
        {
            int a = 0;
            return a;
        }

        public static void LOAD_DROPS()
        {
            
        }

        public static void LOAD_ANIMATIONS()
        {
            
        }

        public static int LOAD_MOUNTPARKS()
        {
            int a = 0;
            return a;
        }

        public static void LOGGED_ZERO()
        {
            
        }

        public static void LOAD_GUILD_MEMBERS()
        {
            
        }

        public static void LOAD_ITEMS_FULL()
        {
            
        }

        public static void LOAD_COMPTES()
        {
            
        }

        public static void LOAD_MOUNTS()
        {
            
        }

        public static void LOAD_PERSOS()
        {
            
        }

        public static void LOAD_GUILDS()
        {
            
        }

        public static int getNextObjetID()
        {
            int a = 0;
            return a;
        }
    }
}

