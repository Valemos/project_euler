using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace eu25_1000DigitFibonacci
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

            BigInteger num = new BigInteger(1) ;
            BigInteger prevNum = new BigInteger(1);
            BigInteger nextNum = new BigInteger(0);
            int index = 2;

            while(num.ToString().Length != 1000)..
            {
                nextNum = num + prevNum;
                prevNum = num;
                num = nextNum;
                index++;
            }
            Clipboard.SetText(Convert.ToString(index));
            //4782
        }
    }
}
