using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyon.common
{
    class SocketManager
    {
        public static void send(StreamWriter @out, string packet)
        {
            if (@out != null && !packet.Equals("") && !packet.Equals("" + (char)0x00))
            {
                packet = CryptManager.toUtf(packet);
                @out.Write((packet) + (char)0x00);
                @out.Flush();
            }
        }


        public static void REALM_SEND_POLICY_FILE(StreamWriter @out)
        {
            String packet = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<cross-domain-policy>" +
                "<allow-access-from domain=\"*\" to-ports=\"*\" secure=\"false\" />" +
                "<site-control permitted-cross-domain-policies=\"master-only\" />" +
                "</cross-domain-policy>";
            send(@out, packet);
            //if (OxyEmu.CONFIG_DEBUG)
            //    GameServer.addToSockLog("Game: Send>>" + packet);
        }

        public static string REALM_SEND_HC_PACKET(StreamWriter @out)
        {

            String alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder hashkey = new StringBuilder();

            Random rand = new Random();

            for (int i = 0; i < 32; i++)
            {
                hashkey.Append(alphabet[rand.Next(alphabet.Length)]);
            }
            String packet = "HC" + hashkey;
            send(@out, packet);
            //if (OxyEmu.CONFIG_DEBUG)
            //    RealmServer.addToSockLog("Realm: Send>>" + packet);
            return hashkey.ToString();
        }

        public static void REALM_SEND_REQUIRED_VERSION(StreamWriter @out)
        {
            String packet = "AlEv" + Constants.CLIENT_VERSION;
            send(@out, packet);
            //if (OxyEmu.CONFIG_DEBUG)
                //RealmServer.addToSockLog("Conn: Send>>" + packet);
        }
    }
}
