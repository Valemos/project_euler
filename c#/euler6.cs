using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler6
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum1 = 0, sum2 = 0;
            for(int num = 1;num <= 100; num++)
            {
                sum1 += (num * num);

                sum2 += num;
            }
            sum2 = sum2 * sum2;

            int result = sum2 - sum1;

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
