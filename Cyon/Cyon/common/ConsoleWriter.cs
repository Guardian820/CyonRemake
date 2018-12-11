using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyon.common
{
    class ConsoleWriter
    {
        public static void clear()
        {
            //AnsiConsole.out.print("\033[H\033[2J");
            Console.Clear();
        }

        public static void setTitle(string title)
        {
            Console.Title = title;
        }

        public static void println(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
