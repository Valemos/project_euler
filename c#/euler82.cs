using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace eu82_pathSum3ways
{
    class Program
    {
        static int gridLines = 0;

        static int minArg = 0;

        [STAThread]
        static void Main(string[] args)
        {
            int[,] grid = readInput("p082_matrix.txt");
            int gridSize = grid.GetLength(0); //adapted to array's indexes

            int sum = 0;
            int prevSum = 0;
            int x = 0;
            int y = 0;


            //find the way for x = 0 ; 0<x<80
            for (; x < gridLines; x++)
            {

                do
                {
                    if (x > 0 && x < gridLines)
                    {
                        prevSum += min(grid[x - 1, y], grid[x + 1, y], grid[x, y + 1]);
                        switch (minArg)
                        {
                            case 1://grid[x-1,y]
                                x--;
                                break;
                            case 2://grid[x+1,y]
                                x++;
                                break;
                            case 3://grid[x,y+1]
                                y++;
                                break;
                        }
                    }
                    else if (x == 0)
                    {
                        prevSum += Math.Min(grid[x, y + 1], grid[x + 1, y]);
                        switch (minArg)
                        {
                            case 1://grid[x,y+1]
                                y++;
                                break;
                            case 2://grid[x-1,y]
                                x--;
                                break;
                        }
                    }
                    else if (x == gridLines)
                    {
                        prevSum += Math.Min(grid[x, y + 1], grid[x - 1, y]);
                        switch (minArg)
                        {
                            case 1://grid[x,y+1]
                                y++;
                                break;
                            case 2://grid[x-1,y]
                                x++;
                                break;
                        }
                    }
                } while (y < gridSize);

                sum = min(sum, prevSum);
            }
            Clipboard.SetText(sum.ToString());
            /*
            
         if#2    4x y   5y+1   3   6   7   6
         if#1    5x-1   7   2   3   5   4
         if#3    1   3   1   5   6   7

             */
        }

        static int min(params int[] arg)
        {
            int min = 0;
            for (int i = 0;i<arg.Length;i++)
            {
                min = Math.Min(min, arg[i]);
            }

            for(int i = 0; i < arg.Length; i++)
            {
                if (min == arg[i]) minArg = i+1;
            }

            return min;
        }

        static private int[,] readInput(string filename)
        {
            FileStream fstrm = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fstrm);

            int lines;
            for (lines = 0; !sr.EndOfStream; lines++)
            {
                sr.ReadLine();
            }
            


            gridLines = lines;

            int[,] mtx = new int[lines, 80];

            for (int x = 0; !sr.EndOfStream; x++)
            {
                string[] line = sr.ReadLine().Split(',');

                for (int y = 0; y < 80; y++)
                {
                    mtx[x, y] = Convert.ToInt32(line[y]);
                }
            }
            return mtx;
        }
    }
}
