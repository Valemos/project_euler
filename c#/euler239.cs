using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_239
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string res;
            BigInteger factorial100 = 1;

            for(int i = 1; i <= 100; i++)
            {
                factorial100 = factorial100 * i;            
            }

            factorial100 = factorial100 - 14950;

            for(BigInteger i = 1; i <= 100; i++)
            {
                factorial100 = factorial100 / i;
            }

            res = Convert.ToString(factorial100);

            Clipboard.SetText(res);
        }
    }
}
