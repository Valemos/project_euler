using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_221
{
    class Program
    {
        static void Main(string[] args)
        {
            float A = 0;

            for(int i = 1; i <= 22; i++)
            {
                A += 1 / (100 - i);
            }

            Console.WriteLine(A);
            Console.ReadKey();

            int counter = 0;

            long b = 3;

            

            long c;

            while (true)
            {
                for (c = 2; c < b; c++)
                {
                    if ( (b*c)%(b+c) != 1)
                        continue;

                    A = (b * c) * (b * c - 1) / (b + c);
                    counter++;

                    if(counter == 150000)
                        break;
                    
                    b++;
                }
                if (counter == 150000)
                {
                    A = (b * c) * (b * c - 1) / (b + c);
                    break;
                }
                b++;
            }

            Console.WriteLine(A);
            Console.ReadKey();
        }
    }
}
