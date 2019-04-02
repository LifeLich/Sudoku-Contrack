using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Linq;

namespace Client
{
    class ClientClass
    {
        private static readonly HttpClient client = new HttpClient();
        public void Post(int[,] map)
        {
            string postData = "";
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    postData += map[x, y]+"";
                }
            }
            PostDataAsync(postData);
        }

        public async void PostDataAsync(string postData)
        {
            var response = await client.GetAsync("https://localhost:44318/api/Sudoku/" + postData);

            string text = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("not possible");
            }
            else
            {
                Program.UiGridSetup(stringToMap(text));
            }
            
        }

        private static int[,] stringToMap(string textMap)
        {
            int[,] map = new int[9, 9];

            List<char> datalist = new List<char>();
            datalist.AddRange(textMap);

            var result = datalist.Select(c => c.ToString()).ToList();

            int num = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    map[x, y] = Convert.ToInt32(result[num]);
                    num++;
                }
            }

            return map;
        }
    }
}
