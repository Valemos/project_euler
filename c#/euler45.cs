﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Numerics;


/*

Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
Pentagonal 	  	Pn=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
Hexagonal 	  	Hn=n(2n−1) 	  	1, 6, 15, 28, 45, ...

It can be verified that T285 = P165 = H143 = 40755.

Find the next triangle number that is also pentagonal and hexagonal.

*/

namespace eu45
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            SystemSounds.Exclamation.Play();

            //formula of n for Triangular
            // n = (Math.Sqrt(1 + Hn*8)-1)/2

            //formula for Pentagonal
            // n = (1 + Math.Sqrt(1 + Hn*24))/6

            ///*
            bool exit = true;
            for(int n = 144; exit; n++)
            {
                long Hn = n * (2 * n - 1);

                double Np = (1 + Math.Sqrt((double)(1 + Hn * 24))) / 6;
                long NpINT = (long)Np;
                if (Np == NpINT)
                {
                    double Nt = (Math.Sqrt(1 + Hn * 8) - 1) / 2;
                    long NtINT = (long)Nt;
                    if(Nt == NtINT)
                    {
                        SystemSounds.Exclamation.Play();
                        Console.WriteLine(Hn);
                        Console.ReadKey();
                        Clipboard.SetText(Convert.ToString(Hn));
                        exit = false;
                    }
                }
            }
            //*/
        }

        public static BigInteger SqRtN(BigInteger N)
        {
            /*++
             *  Using Newton Raphson method we calculate the
             *  square root (N/g + g)/2
             */
            BigInteger rootN = N;
            int bitLength = 1; // There is a bug in finding bit length hence we start with 1 not 0
            while (rootN / 2 != 0)
            {
                rootN /= 2;
                bitLength++;
            }
            bitLength = (bitLength + 1) / 2;
            rootN = N >> bitLength;

            BigInteger lastRoot = BigInteger.Zero;
            do
            {
                lastRoot = rootN;
                rootN = (BigInteger.Divide(N, rootN) + rootN) >> 1;
            }
            while (!((rootN ^ lastRoot).ToString() == "0"));
            return rootN;
        } // SqRtN


    }
}
