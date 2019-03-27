using System;

namespace SudokuContrack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] map = new int[9, 9] { 
                {0,1,2,3,4,5,6,7,8}, 
                {1,0,6,4,5,6,7,8,9},
                {2,5,0,4,5,6,7,8,9},
                {3,5,6,0,5,6,7,8,9},
                {4,5,6,4,0,6,7,8,9},
                {5,5,6,4,5,0,7,8,9},
                {6,5,6,4,5,6,0,8,9},
                {7,5,6,4,5,6,7,0,9},
                {8,5,6,4,5,6,7,8,0}};
            
            UiSetup(map);
            Console.ReadLine();
        }

        private static void UiSetup(int[,] map)
        {
            Console.WriteLine("------------------");
            for (int x = 0; x < 9; x++)
            {
                
                
                for (int y = 0; y < 9; y++)
                {
                    Console.Write("│" + map[x,y]);
                }
                Console.Write("│");
                Console.WriteLine();
                Console.WriteLine("------------------");
            }
        }
    }
}
