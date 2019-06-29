using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace euler16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger powOfTwo = new BigInteger(1);

            for (int loop = 0;loop<1000;loop++)
            {
                powOfTwo = BigInteger.Multiply(powOfTwo, 2);
            }
            string nearRes = powOfTwo.ToString();
            long result = 0;

            foreach (char el in nearRes)
            {
                result += (int)Char.GetNumericValue(el);
            }

            Console.WriteLine(result);

            Console.WriteLine("press...");
            Console.ReadKey();
        }
    }
}
