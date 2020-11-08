using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chap10labyrinthcode
{
    class Program
    {

        static int[,] displaygraph = new int[5, 7];
        static int row = 0;
        static int colume = 0;

        static void MenuOption()
        {
            Console.WriteLine("Game is Start to play it follow the options");
            do
            {
                Console.WriteLine("1-GoUp 2-GoRight 3-GoDown 4-Goleft");
                int options = int.Parse(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        if (row >= 0 && displaygraph[row, colume] != -1)
                        {

                            row--;
                            GameRun(row, colume);
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        break;

                    case 2:
                        if ((colume >= 0) && (displaygraph[row, colume] != -1))
                        {


                            displaygraph[row, colume++] = 1;
                            GameRun(row, colume);
                        }
                        else
                        {
                            Console.WriteLine("Invalid");
                        }

                        break;

                    case 3:
                        if (row >= 0 && displaygraph[row, colume] != -1) row++;
                        else Console.WriteLine("Invalid");
                        break;

                    case 4:
                        if (colume >= 0 && displaygraph[row, colume] != -1) colume--;
                        break;

                    default:
                        Console.WriteLine("Wrong Option select again");
                        break;
                } // switch end
            } while (true);
        } // Menuoption end

        static void GameRun(int row, int colume)
        {

            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= colume; j++)
                {
                    if (displaygraph[i, j] == displaygraph[row, colume])
                    {
                        Console.Write(displaygraph[i, j] == 1 ? "0" : " ");
                    }

                }
                Console.WriteLine();
            }


            //Console.WriteLine("{0}",displaygraph[row,colume]);
        }

        static void GameDisplayMatrix()
        {
            int[,] displaygraph = new int[5, 7];

            --displaygraph[0, 3];
            --displaygraph[1, 0];
            --displaygraph[1, 1];
            --displaygraph[1, 3];
            --displaygraph[3, 1];
            --displaygraph[3, 2];
            --displaygraph[3, 3];
            --displaygraph[3, 4];
            --displaygraph[3, 5];
            --displaygraph[1, 5];
            MenuOption();

            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < colume; j++)
            //    {

            //        if (displaygraph[i, j] == -1)
            //        {
            //            Console.Write("|0");
            //        }

            //        Console.Write(j < colume - 1 ? "| " : "| |");

            //    }
            //    Console.WriteLine();
            //}

        }

        static char[,] lab = {
                                 {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                 {'*', '*', ' ', '*', ' ', '*', ' '},
                                 {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                 {' ', '*', '*', '*', '*', '*', ' '},
                                 {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
                             };
        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;

        static void FindPath_BookSolution(int row, int colume, char direction)
        {
            if (colume < 0 || row < 0 || colume >= lab.GetLength(1) || row >= lab.GetLength(0))
            {
                // we are out of path
                return;
            }

            path[position] = direction;
            position++;

            if (lab[row, colume] == 'e')
            {
                PrintPath(path, 1, position - 1);
            }
            //if (lab[row, colume] != ' ')
            //{
            //    // current cell is not free
            //    position--;
            //    return;
            //}
            if (lab[row, colume] == ' ')
            {
                lab[row, colume] = 's';

                FindPath_BookSolution(row, colume - 1, 'L'); // left
                FindPath_BookSolution(row - 1, colume, 'U'); // up
                FindPath_BookSolution(row + 1, colume, 'D'); // down
                FindPath_BookSolution(row, colume + 1, 'R'); // right

                lab[row, colume] = ' ';
            }
            position--;
        }
        static void PrintPath(char[] path, int startpos, int endpos)
        {
            for (int pos = startpos; pos <= endpos; pos++)
            {
                Console.Write(path[pos]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            //MenuOption();
            FindPath_BookSolution(0, 0, 'S');
        }
    }
}
