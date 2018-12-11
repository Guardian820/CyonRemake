using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyon.common
{
    class CryptManager
    {
        public static string toUtf(string _in)
        {
            string _out = "";

            try
            {
                //_out = new String(_in.getBytes("UTF8"));

                byte[] encodedBytes = Encoding.UTF8.GetBytes(_in);
                _out = encodedBytes.ToString();
            }
            catch (Exception e)
            {
                ConsoleWriter.println("UTF-8 Error: " + e.Message);
            }

            return _out;
        }
    }
}
