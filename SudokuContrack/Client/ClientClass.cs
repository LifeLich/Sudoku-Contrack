using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
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
            var response = await client.GetAsync("https://localhost:44341/api/Sudoku/" + postData);

            string text = await response.Content.ReadAsStringAsync();

            Console.WriteLine(text);

        }
    }
}
