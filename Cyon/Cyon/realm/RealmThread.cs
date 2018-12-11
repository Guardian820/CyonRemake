using Cyon.common;
using Cyon.objects;
using Cyon.Utils.Java;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cyon.realm
{
    class RealmThread : Runnable
    {
        private Socket _ss;
        private string _remoteEP;
        public RealmThread(Socket ss)
        {
            _ss = ss;
            this._remoteEP = this._ss.RemoteEndPoint.ToString();

            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(this.Run));
            thread.Start();
        }

        public void Run()
        {
        }
        
    }
}