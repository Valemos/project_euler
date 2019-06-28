using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p104_Pandigital_Fibonacci_ends
{
    class Program
    {
        /*
The Fibonacci sequence is defined by the recurrence relation:

    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

It turns out that F541, which contains 113 digits, is the first Fibonacci number 
for which the last nine digits are 1-9 pandigital (contain all the digits 1 to 9, 
but not necessarily in order). And F2749, which contains 575 digits, is the first 
Fibonacci number for which the first nine digits are 1-9 pandigital.

Given that Fk is the first Fibonacci number for which the first nine digits AND the 
last nine digits are 1-9 pandigital, find k.
*/
        static int elementNum = 2;
        static int curElement = 0;

        static int elementMinus1 = 1;
        static int elementMinus2 = 1;

        [STAThread]
        static void Main(string[] args)
        {
            int[] num = { 5,6,1,4,7,2,9,8,3 };
            Console.WriteLine(toString(quicksort(num)));
            Console.ReadKey();
        }
        

        static int getFibonacci(int n)
        {
            while(elementNum < n)
            {
                curElement = elementMinus1 + elementMinus2;

                elementMinus2 = elementMinus1;
                elementMinus1 = curElement;

                elementNum++;
            }

            return curElement;
        }

        static bool isPandigital(string strNumber)
        {
            if(strNumber.Length == 9)
            {
                int[] number = convertToIntArray(strNumber);
                quicksort(number);
                
            }

            return false;
        }

        static int[] convertToIntArray(string str)
        {
            int[] num = new int[9];
            for (int i = 0; i < 9; i++)
            {
                num[i] = (int) char.GetNumericValue(str[i]);
            }
            return num;
        }

        static int[] quicksort(int[] num)
        {
            int swaps = 0;
            while(swaps != 0)
            {
                swaps = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (num[i] < num[i + 1])
                    {
                        int tmp = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = tmp;
                        swaps++;
                    }
                }
            }
            return num;
        }

        static string toString(int[] num)
        {
            StringBuilder futureString = new StringBuilder(num.Length);

            for(int i = 0; i < num.Length; i++)
            {
                futureString.Append(num[i]);
            }
            return futureString.ToString(0, num.Length);
        }
    }
}
