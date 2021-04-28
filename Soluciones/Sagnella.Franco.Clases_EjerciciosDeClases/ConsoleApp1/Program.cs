using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 20;
            for(; ; )
            {
                Console.Write(i + " ");

                if (i >= -10)
                    i -= 4;
                else
                    break;
            }

            Console.ReadKey();
        }
    }
}
