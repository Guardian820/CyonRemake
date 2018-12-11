using Cyon.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyon.common
{
    class World
    {


        private static Dictionary<int, Compte> Comptes = new Dictionary<int, Compte>();
        private static Dictionary<string, int> ComptebyName = new Dictionary<string, int>();
        private static Dictionary<int, Personnage> Persos = new Dictionary<int, Personnage>();
        private static Dictionary<short, Carte> Cartes = new Dictionary<short, Carte>();
        private static Dictionary<int, Objet> Objets = new Dictionary<int, Objet>();
        private static Dictionary<int, ExpLevel> ExpLevels = new Dictionary<int, ExpLevel>();
        private static Dictionary<int, Sort> Sorts = new Dictionary<int, Sort>();
        private static Dictionary<int, ObjTemplate> ObjTemplates = new Dictionary<int, ObjTemplate>();
        private static Dictionary<int, Monstre> MobTemplates = new Dictionary<int, Monstre>();
        private static Dictionary<int, NPC_tmpl> NPCTemplates = new Dictionary<int, NPC_tmpl>();
        private static Dictionary<int, NPC_question> NPCQuestions = new Dictionary<int, NPC_question>();
        private static Dictionary<int, NPC_reponse> NPCReponses = new Dictionary<int, NPC_reponse>();
        private static Dictionary<int, IOTemplate> IOTemplate = new Dictionary<int, IOTemplate>();
        private static Dictionary<int, Dragodinde> Dragodindes = new Dictionary<int, Dragodinde>();
        private static Dictionary<int, SuperArea> SuperAreas = new Dictionary<int, SuperArea>();
        private static Dictionary<int, Area> Areas = new Dictionary<int, Area>();
        private static Dictionary<int, SubArea> SubAreas = new Dictionary<int, SubArea>();
        private static Dictionary<int, Metier> Jobs = new Dictionary<int, Metier>();
        //private static Dictionary<int, List<Couple<Integer, int>>> Crafts = new Dictionary<int, List<Couple<Integer, int>>>();
        private static Dictionary<int, Dictionary<int, int>> Crafts = new Dictionary<int, Dictionary<int, int>>();
        private static Dictionary<int, ItemSet> ItemSets = new Dictionary<int, ItemSet>();
        private static Dictionary<int, Guild> Guildes = new Dictionary<int, Guild>();
        private static Dictionary<int, HDV> Hdvs = new Dictionary<int, HDV>();
        private static Dictionary<int, Dictionary<int, List<HDV.HdvEntry>>> _hdvsItems = new Dictionary<int, Dictionary<int, List<HDV.HdvEntry>>>();  //Contient tout les items en ventes des comptes dans le format<compteID,<hdvID,items<>>>
        private static Dictionary<int, Personnage> Married = new Dictionary<int, Personnage>();
        private static Dictionary<int, Animations> Animations = new Dictionary<int, Animations>();
        private static Dictionary<short, Carte.MountPark> MountPark = new Dictionary<short, Carte.MountPark>();
        private static Dictionary<int, Trunk> Trunks = new Dictionary<int, Trunk>();
        private static Dictionary<int, Percepteur> Percepteurs = new Dictionary<int, Percepteur>();
        private static Dictionary<int, House> Houses = new Dictionary<int, House>();
        private static Dictionary<short, List<int>> Seller = new Dictionary<short, List<int>>();
        private static StringBuilder Challenges = new StringBuilder();

        private static int nextObjetID;

        public static void createWorld()
        {
            SQLManager.LOAD_EXP();
            ConsoleWriter.println(ExpLevels.Count + " niveles fueron cargados.");
            SQLManager.LOAD_SORTS();
            ConsoleWriter.println(Sorts.Count + " hechizos fueron cargados.");
            SQLManager.LOAD_MOB_TEMPLATE();
            ConsoleWriter.println(MobTemplates.Count + " monstruos fueron cargados.");
            SQLManager.LOAD_OBJ_TEMPLATE();
            ConsoleWriter.println(ObjTemplates.Count + " planillas de objetos fueron cargados.");
            SQLManager.LOAD_NPC_TEMPLATE();
            ConsoleWriter.println(NPCTemplates.Count + " npc fueron cargados.");
            SQLManager.LOAD_NPC_QUESTIONS();
            SQLManager.LOAD_NPC_ANSWERS();
            SQLManager.LOAD_AREA();
            ConsoleWriter.println(Areas.Count + " zonas fueron cargados.");
            SQLManager.LOAD_SUBAREA();
            SQLManager.LOAD_IOTEMPLATE();
            ConsoleWriter.println(IOTemplate.Count + " planillas de IO fueron cargados.");
            SQLManager.LOAD_CRAFTS();
            ConsoleWriter.println(Crafts.Count + " recetas fueron cargadas.");
            SQLManager.LOAD_JOBS();
            ConsoleWriter.println(Jobs.Count + " oficios fueron cargados.");
            SQLManager.LOAD_ITEMSETS();
            ConsoleWriter.println(ItemSets.Count + " sets (equipamiento) fueron cargados.");
            SQLManager.LOAD_MAPS();
            ConsoleWriter.println(Cartes.Count + " mapas fueron cargados.");
            int nbr = SQLManager.LOAD_TRIGGERS();
            ConsoleWriter.println(nbr + " triggers fueron cargados.");
            nbr = SQLManager.LOAD_ENDFIGHT_ACTIONS();
            ConsoleWriter.println(nbr + " acciones de termino de combate fueron cargadas.");
            nbr = SQLManager.LOAD_NPCS();
            nbr = SQLManager.LOAD_ITEM_ACTIONS();
            SQLManager.LOAD_DROPS();
            SQLManager.LOAD_ANIMATIONS();
            ConsoleWriter.println(Animations.Count + " animaciones fueron cargadas.");
            SQLManager.LOGGED_ZERO();
            SQLManager.LOAD_ITEMS_FULL();
            SQLManager.LOAD_COMPTES();
            ConsoleWriter.println(Comptes.Count + " cuentas fueron cargadas.");
            SQLManager.LOAD_PERSOS();
            ConsoleWriter.println(Persos.Count + " personajes fueron cargados.");
            SQLManager.LOAD_GUILDS();
            ConsoleWriter.println(Guildes.Count + " gremios fueron cargados.");
            SQLManager.LOAD_MOUNTS();
            ConsoleWriter.println(Dragodindes.Count + " monstruos fueron cargados.");
            SQLManager.LOAD_GUILD_MEMBERS();
            nbr = SQLManager.LOAD_MOUNTPARKS();
            ConsoleWriter.println(nbr + " cercados fueron cargados.");
            nbr = SQLManager.LOAD_PERCEPTEURS();
            nbr = SQLManager.LOAD_HOUSES();
            ConsoleWriter.println(nbr + " casas fueron cargadas.");
            nbr = SQLManager.LOAD_TRUNK();
            ConsoleWriter.println(nbr + " cofres fueron cargados.");
            nbr = SQLManager.LOAD_ZAAPS();
            ConsoleWriter.println(nbr + " zaaps fueron cargados.");
            nbr = SQLManager.LOAD_ZAAPIS();
            ConsoleWriter.println(nbr + " zaapis fueron cargados.");
            SQLManager.LOAD_CHALLENGES();
            ConsoleWriter.println(Challenges.ToString().Split(';').Length + " retos fueron cargados.");
            nbr = SQLManager.LOAD_BANIP();
            ConsoleWriter.println(nbr + " IP baneadas fueron cargadas.");
            SQLManager.LOAD_HDVS();
            SQLManager.LOAD_HDVS_ITEMS();
            //nextObjetID = SQLManager.getNextObjetID();
        }

        public static short get_state()
        {
            short a = 1;
            return a;
        }
    }
}
