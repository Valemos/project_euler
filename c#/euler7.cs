using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler7
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany = 10;

            int prime = 0;
            int num = 2;
            int sum = 0;
            for (;num < howMany; num++)
            {
                bool check = false;
                for (int l = num; l >= 1; l--)
                {
                    if (num % l == 0 && l != 1 && l != num)
                    {
                        check = false;
                        break;
                    }
                    else check = true;
                }

                
                if (check)
                    {
                        prime = num;
                        sum += prime;
                    }
                if (prime > howMany)
                {
                    break;
                }
            }
            
            Console.WriteLine(sum);
            Console.WriteLine("Press...");
            Console.ReadKey();
        }
    }
}
