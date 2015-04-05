using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("1. Get one sample film");
            Console.WriteLine("2. Compare formats with all films");
            Console.Write("\nChoose an option: ");
            ConsoleKeyInfo console = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            switch (console.KeyChar)
            {
                case '1':
                    GetOneFilm();
                    break;

                case '2':
                    CompareFormats();
                    break;
                default:
                    Console.WriteLine("\n\nInvalid character");
                    Console.ReadKey();
                    break;
            } 
        }

        protected static void GetOneFilm()
        {
            HttpClient client = GetProtobufClient();
            HttpResponseMessage response = client.GetAsync("api/film/1").Result;

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                Film film = response.Content.ReadAsAsync<Film>(
                    new[] { new ProtoBufFormatter() }).Result;
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
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadKey();
        }

        protected static void CompareFormats()
        {
            HttpClient protobufClient = GetProtobufClient();
            Stopwatch protobufStopwatch = Stopwatch.StartNew();
            HttpResponseMessage protobufResponse = protobufClient.GetAsync("api/film").Result;
            if (protobufResponse.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                IList<Film> film = protobufResponse.Content.ReadAsAsync<IList<Film>>(
                    new[] { new ProtoBufFormatter() }).Result;
            }
            else
            {
                Console.WriteLine("Protobuf service failed. {0} ({1})", 
                                    (int)protobufResponse.StatusCode, 
                                    protobufResponse.ReasonPhrase);
            }
            protobufStopwatch.Stop();
            TimeSpan protobufTime = protobufStopwatch.Elapsed;
            Console.WriteLine("Protobuf time = {0}", protobufTime);

            
            HttpClient jsonClient = GetJSONClient();
            Stopwatch jsonStopwatch = Stopwatch.StartNew();
            HttpResponseMessage jsonResponse = jsonClient.GetAsync("api/film").Result;
            if (jsonResponse.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                IList<Film> film = jsonResponse.Content.ReadAsAsync<IList<Film>>().Result;
            }
            else
            {
                Console.WriteLine("JSON service failed. {0} ({1})",
                                    (int)jsonResponse.StatusCode,
                                    jsonResponse.ReasonPhrase);
            }
            jsonStopwatch.Stop();
            TimeSpan jsonTime = protobufStopwatch.Elapsed;
            Console.WriteLine("JSON time = {0}", jsonTime);
            Console.ReadKey();
            Console.ReadKey();
        }

        protected static HttpClient GetProtobufClient()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:49916/") };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            return client;
        }

        protected static HttpClient GetJSONClient()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:49916/") };
            return client;
        }
    }
}
