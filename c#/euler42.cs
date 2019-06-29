/*

The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. 

If the word value is a triangle number then we shall call the word a triangle word.

Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace euler42
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = "words.txt";


            FileStream fstrm = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fstrm);

            //convert file to array
            string[] mtx1 = sr.ReadToEnd().Split(',','"');
            int len = mtx1.Length / 3;
            string[] words = new string[len];

            int v = 0;
            for(int l = 1;l<mtx1.Length;l+=3)
            {
                words[v] = mtx1[l];
                v++;
            }

            //set an array for values of words

            //int maxValue = 0;
            int[] value = new int[len];

            for(int s = 0; s < len; s++)
            {
                int val = 0;
                foreach(char el in words[s])
                {
                    //sum the value
                    if (el == 'A') { val += 1; continue; }
                    if (el == 'B') { val += 2; continue; }
                    if (el == 'C') { val += 3; continue; }
                    if (el == 'D') { val += 4; continue; }
                    if (el == 'E') { val += 5; continue; }
                    if (el == 'F') { val += 6; continue; }
                    if (el == 'G') { val += 7; continue; }
                    if (el == 'H') { val += 8; continue; }
                    if (el == 'I') { val += 9; continue; }
                    if (el == 'J') { val += 10; continue; }
                    if (el == 'K') { val += 11; continue; }
                    if (el == 'L') { val += 12; continue; }
                    if (el == 'M') { val += 13; continue; }
                    if (el == 'N') { val += 14; continue; }
                    if (el == 'O') { val += 15; continue; }
                    if (el == 'P') { val += 16; continue; }
                    if (el == 'Q') { val += 17; continue; }
                    if (el == 'R') { val += 18; continue; }
                    if (el == 'S') { val += 19; continue; }
                    if (el == 'T') { val += 20; continue; }
                    if (el == 'U') { val += 21; continue; }
                    if (el == 'V') { val += 22; continue; }
                    if (el == 'W') { val += 23; continue; }
                    if (el == 'X') { val += 24; continue; }
                    if (el == 'Y') { val += 25; continue; }
                    if (el == 'Z') { val += 26; continue; }
                }
                value[s] = val;
                //if (val > maxValue) maxValue = val;
            }

            //set max number of sequence ( tn = ½n(n+1) ) members
            

            //get seqence to array
            int[] seq = new int[21];

            int f = 0;
            for (int n = 1; n <= 21; n++)
            {
                int mem = (n * (n - 1)) / 2;
                seq[f] = mem;
                f++;
            }

            //final phase!

            int howMany = 0;
            foreach(int el in value)
            {
                foreach (int sq in seq) if (el == sq) ++howMany;
            }
            Clipboard.SetText(Convert.ToString(howMany));
        }
    }
}
