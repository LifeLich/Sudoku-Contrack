using System;
using System.Collections.Generic;
using System.Net;
using System.Text;  // for class Encoding
using System.IO;    // for StreamReader


namespace Client
{
    class ClientClass
    {
        public void Post(int[,] map)
        {
            string postData = "";
            for (int x = 0; x < 9; x++)
            {
                postData += "|";
                for (int y = 0; y < 9; y++)
                {
                    postData += "{X" + x + "Y" + y + "value" + map[x, y]+"}";
                }
            }
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }
    }
}
