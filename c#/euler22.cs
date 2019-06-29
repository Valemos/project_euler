using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


/*

Using names.txt , a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?
*/


namespace euler22
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            FileStream fstream = new FileStream("names.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fstream);

            string fcontent = sr.ReadToEnd();
            string[] mtx1 = fcontent.Split('"', ',');

            int len = (mtx1.Length) / 3;

            string[] name = new string[len];

            //rewrite mtx1
            int v = 0;
            for (int m = 1; m < mtx1.Length; m += 3)
            {
                name[v] = mtx1[m];
                v++;
            }
            
                int loop = 0;
            //put names in alphabetical order
                while (loop <= len)
                {
                    for (int l = 0; l < len - 1; l++)
                    {
                        if (name[l].CompareTo(name[l + 1]) > 0)
                        {
                            string prevName = name[l];

                            name[l] = name[l + 1];
                            name[l + 1] = prevName;
                        }
                    }
                loop++;
                };

            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                //when counting value of name multiply them on their position and sum
                int value = 0;
                //get a value for each letter and sum them
                foreach (char el in name[i])
                {
                    if (el == 'A') { value += 1; continue; }
                    if (el == 'B') { value += 2; continue; }
                    if (el == 'C') { value += 3; continue; }
                    if (el == 'D') { value += 4; continue; }
                    if (el == 'E') { value += 5; continue; }
                    if (el == 'F') { value += 6; continue; }
                    if (el == 'G') { value += 7; continue; }
                    if (el == 'H') { value += 8; continue; }
                    if (el == 'I') { value += 9; continue; }
                    if (el == 'J') { value += 10; continue; }
                    if (el == 'K') { value += 11; continue; }
                    if (el == 'L') { value += 12; continue; }
                    if (el == 'M') { value += 13; continue; }
                    if (el == 'N') { value += 14; continue; }
                    if (el == 'O') { value += 15; continue; }
                    if (el == 'P') { value += 16; continue; }
                    if (el == 'Q') { value += 17; continue; }
                    if (el == 'R') { value += 18; continue; }
                    if (el == 'S') { value += 19; continue; }
                    if (el == 'T') { value += 20; continue; }
                    if (el == 'U') { value += 21; continue; }
                    if (el == 'V') { value += 22; continue; }
                    if (el == 'W') { value += 23; continue; }
                    if (el == 'X') { value += 24; continue; }
                    if (el == 'Y') { value += 25; continue; }
                    if (el == 'Z') { value += 26; continue; }
                }

                sum += (value * i);
                i++;
            }
            Clipboard.SetText(Convert.ToString(sum));
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
