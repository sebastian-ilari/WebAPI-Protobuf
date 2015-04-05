using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Model;
using WebApiContrib.Formatting;

namespace WebClientProtobuf
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:49916/") };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-protobuf"));

            HttpResponseMessage response = client.GetAsync("api/film/1").Result; 
            
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                Film film = response.Content.ReadAsAsync<Film>(
                    new[] { new ProtoBufFormatter()}).Result;
                Console.WriteLine("Id = {0}\r\n" +
                                  "Brand = {1}\r\n" +
                                  "Model = {2}\r\n" +
                                  "Color = {3}\r\n" +
                                  "Frames = {4}\r\n" +
                                  "Size = {5}mm\r\n", 
                                  film.Id,
                                  film.Brand,
                                  film.Model,
                                  film.Color,
                                  film.Frames,
                                  film.Size);               
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Console.ReadLine();
        }        
    }
}
