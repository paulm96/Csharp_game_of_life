using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class GameofLife
    {
        private int[,] array;
        private int[,] tmp;
        private int counter;
        public GameofLife(int size)
        {
        array = new int[size, size];
        tmp = new int[size, size];
        counter = 0;
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = rnd.Next(0, 2);
                    //tmp[i,j] = array[i,j];
                }
            }
        }

        public void displayBoard()
        {
            for (int i = 0; i < tmp.GetLength(0); ++i)
            {
                for (int j = 0; j < tmp.GetLength(1); ++j)
                {
                    if(array[i,j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    System.Console.Write(array[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write(" ");

                }
                System.Console.WriteLine();

            }
        }

        public void DropTheResult()
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    try
                    {
                        if (array[i - 1, j - 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i - 1, j] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i - 1, j + 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i, j - 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i, j + 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i + 1, j - 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i + 1, j] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (array[i + 1, j + 1] == 1)
                            ++counter;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }

                    //Console.Write(counter);

                    if ((counter < 2 || counter > 3) && array[i, j] == 1)
                        tmp[i, j] = 0;
                    if (counter < 4 && counter > 1 && array[i, j] == 1)
                        tmp[i, j] = 1;
                    if (counter == 3 && array[i, j] == 0)
                        tmp[i, j] = 1;
                    if (counter != 3 && array[i, j] == 0)
                        tmp[i, j] = 0;

                    counter = 0;
                }
            }
        }

        public void updateChanges()
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = tmp[i, j];

                }
            }
        }

        public void runTheGame()
        {
            while (true)
            {
                this.displayBoard();

                System.Console.Write("Press any key to next generation...");
                System.Console.ReadLine();
                Console.Clear();

                this.DropTheResult();
                this.updateChanges();

            }
        }

    }
}
