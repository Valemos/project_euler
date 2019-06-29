using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace eu81_pathSum2ways
{
    class Program
    {
        static int[,] grid;

        static void drawGrid()
        {
                int lines = grid.Length / grid.GetLength(0);
                int elems = grid.GetLength(0);

                Console.Clear();

                for (int x = 0;x < lines - 70; x++)
                {
                    for (int y = 0;y < elems - 70;y++)
                    {
                        int len = grid[x, y].ToString().Length;
                        if (len == 6)
                        {
                            Console.Write(grid[x,y] + " ");
                        }
                        else
                        {
                            Console.Write(grid[x,y]);
                            for (int i = 0; i < 7-len; i++)
                                Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(300);
        }

        [STAThread]
        static void Main(string[] args)
        {
            string matrixPath = "p081_matrix.txt";
            grid = readInput(matrixPath);
            int gridSize = grid.GetLength(0);
            

            //calculate the solution for bottom and right
            
            for (int i = gridSize - 2; i >= 0; i--)
            {
                grid[gridSize - 1, i] += grid[gridSize - 1, i + 1];
                grid[i, gridSize - 1] += grid[i + 1, gridSize - 1];
                drawGrid();
            }
            
            for (int i = gridSize - 2; i >= 0; i--)
            {
                for (int j = gridSize - 2; j >= 0; j--)
                {
                    grid[i, j] += Math.Min(grid[i + 1, j], grid[i, j + 1]);
                    drawGrid();
                }
            }
            Clipboard.SetText(grid[0,0].ToString());
            Console.WriteLine(grid[0, 0].ToString());
            Console.ReadKey();
        }

        private static int[,] readInput(string filename)
        {
            int[,] mtx = new int[80, 80];

            FileStream fstrm = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fstrm);

            for (int x = 0; !sr.EndOfStream; x++)
            {
                string[] line = sr.ReadLine().Split(',');

                for (int y = 0; y < line.Length; y++)
                {
                    mtx[x, y] = Convert.ToInt32(line[y]);
                }
            }
            return mtx;
        }
    }
}
