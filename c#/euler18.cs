using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

//and euler 67
namespace euler18
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int[,] nums = readInput("p067_triangle.txt");

            /*
                3
                7 4
                2 4 6
                8 5 9 3    start line
             */

            for (int i = lines-2;i>=0;i--)//line counter
            {
                for(int l = 0; ; l++)//elements in line
                {
                    if (nums[i, l] == 0) break;

                    nums[i, l] += Math.Max(nums[i+1,l],nums[i+1,l+1]);
                }
            }

            Clipboard.SetText(Convert.ToString(nums[0,0]));
        }

        static int lines = 0;
        static private int[,] readInput(string filename)
        {
            string line;
            string[] linePieces;
            

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
            {
                lines++;
            }

            int[,] inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }
            r.Close();
            return inputTriangle;
        }
    }
}
