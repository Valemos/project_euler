using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler9
{
    class Program
    {
        static int howMuch = 1000;
        static double sum = 0;
        static double c;

        static void Main(string[] args)
        {
            for (double a = 1;a < howMuch;a++)
            {

                for(double b = 1; b < howMuch; b++)
                {
                    if (a < b)
                    {
                        c = Math.Sqrt((a * a) + (b * b));
                    }

                    if(a < b && b < c)
                    {
                        sum = a + b + c;
                    }

                    if(sum == howMuch)
                    {
                        Console.WriteLine(a * b * c);
                        break;
                    }
                }
                if (sum == howMuch) break;
            }
            Console.ReadKey();
        }
    }
}
