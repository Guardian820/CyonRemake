using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cyon.Utils.Java
{
    public class Runtime
    {
        
        private static Runtime mRuntime = new Runtime();

        public static Runtime getRuntime()
        {
            return mRuntime;
        }

        public void addShutdownHook(Thread hook)
        {
            hook.Start();
        }
    }
}
