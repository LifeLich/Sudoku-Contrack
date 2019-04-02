using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class Solver
    {
        private readonly Tuple<int,int> full = new Tuple<int, int>(9,9);
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

        private bool check3by3(int[,] grid, int number, int startcol, int startrow)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i + startrow, j + startcol] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool checkAll(int[,] grid, int number, int row, int column)
        {
            if (!checkrow(grid, number, row) && !checkcolumn(grid, number, column) && !check3by3(grid,number,column - column % 3, row - row % 3))
            {
                return true;
            }

            return false;
        }

        private Tuple<int, int> getBlank(int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        return new Tuple<int, int>(i,j);
                    }
                }
            }
            return full;
        }

        public bool solve(int[,] grid)
        {
            if (getBlank(grid) == full)
            {
                return true;
            }

            Tuple<int, int> coord = getBlank(grid);
            int row = coord.Item1;
            int column = coord.Item2;

            for (int i = 1; i <= 9; i++)
            {
                if (checkAll(grid, i, row, column))
                {
                    grid[row, column] = i;

                    if (solve(grid))
                    {
                        return true;
                    }

                    grid[row, column] = 0;
                }
            }

            return false;
        }
    }
}
