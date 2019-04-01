using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class Solver
    {
        private bool checkrow(int[,] grid, int number, int row)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkcolumn(int[,] grid, int number, int column)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, column] == number)
                {
                    return true;
                }
            }

            return false;
        }

        private bool check3by3(int[,] grid, int number)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool checkAll(int[,] grid, int number, int row, int column)
        {
            if (checkrow(grid, number, row) && checkcolumn(grid, number, column))
            {
                for (int i = 0; i < 9; i++)
                {
                    int[,] smallgrid = new int[3, 3];

                }
            }

            return false;
        }
    }
}
