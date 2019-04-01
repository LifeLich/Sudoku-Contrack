using System;
using System.Collections.Generic;
using System.Net.Http;
namespace Client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
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

            EditTable(map);

            Console.WriteLine("Sending");
            Post();
            Console.WriteLine("Send");
            Console.ReadLine();
        }

        private static void Post()
        {
            var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            //var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            //var responseString = await response.Content.ReadAsStringAsync();
        }

        private static void EditTable(int[,] map)
        {
            while (true)
            {
                Console.WriteLine("Type Exit At any Point To Leave To Leave");
                UiGridSetup(map);
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

        private static void UiGridSetup(int[,] map)
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
