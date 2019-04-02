using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] map = new int[9, 9] {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}};


            map = new int[9, 9] {{ 5, 3, 0, 0, 7, 0, 0, 0, 0},
                                 { 6, 0, 0, 1, 9, 5, 0, 0, 0},
                                 { 0, 9, 8, 0, 0, 0, 0, 6, 0},
                                 { 8, 0, 0, 0, 6, 0, 0, 0, 3},
                                 { 4, 0, 0, 8, 0, 3, 0, 0, 1},
                                 { 7, 0, 0, 0, 2, 0, 0, 0, 6},
                                 { 0, 6, 0, 0, 0, 0, 2, 8, 0},
                                 { 0, 0, 0, 4, 1, 9, 0, 0, 5},
                                 { 0, 0, 0, 0, 8, 0, 0, 7, 9} };
            EditTable(map);

            Console.WriteLine("Sending");
            ClientClass clint = new ClientClass();
            clint.Post(map);
            Console.WriteLine("Send");
            Console.ReadLine();
        }

        private static void EditTable(int[,] map)
        {
            while (true)
            {
                UiGridSetup(map);
                Console.WriteLine("Type (Exit) At any Point To Leave To Leave");
                int x = -5;
                while (x <= 0 || x >= 11)
                {
                    Console.WriteLine("Type in the y coordinate");
                    string text = Console.ReadLine();
                    if (text.ToLower() == "exit")
                    {
                        return;
                    }
                    x = Int32.Parse(text);
                }
                int y = -5;
                while (y <= 0 || y >= 11)
                {
                    Console.WriteLine("Type in the x coordinate");
                    string text = Console.ReadLine();
                    if (text.ToLower() == "exit")
                    {
                        return;
                    }
                    y = Int32.Parse(text);
                }
                int number = -5;
                while (number <= -1 || number >= 10)
                {
                    Console.WriteLine("Type in the number 0 to 9");
                    string text = Console.ReadLine();
                    if (text.ToLower() == "exit")
                    {
                        return;
                    }
                    number = Int32.Parse(text);
                }
                map[x - 1, y - 1] = number;
            }
        }

        public static void UiGridSetup(int[,] map)
        {
            Console.Clear();
            Console.WriteLine("------------------");
            for (int x = 0; x < 9; x++)
            {


                for (int y = 0; y < 9; y++)
                {
                    Console.Write("│" + map[x, y]);
                }
                Console.Write("│");
                Console.WriteLine();
                Console.WriteLine("------------------");
            }
        }
    }
}
