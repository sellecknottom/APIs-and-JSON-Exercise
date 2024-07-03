using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private HttpClient _client;
        public RonVSKanyeAPI(HttpClient client)
        {
            _client = client;
        }

        public string RonWords() //Ron Swanson quotes
        {
            string ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = _client.GetStringAsync(ronUrl).Result;
            var ronQuote = JArray.Parse(ronResponse);

            return ronQuote[0].ToString();
        }
        public string KanyeWords() //Kanye West quotes
        {
            string kanyeUrl = "https://api.kanye.rest/";
            var kanyeResponse = _client.GetStringAsync(kanyeUrl).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse);
            return kanyeQuote["quote"].ToString();

            
        }
        public static void Convo()
        {
            HttpClient client = new HttpClient();
            RonVSKanyeAPI api = new RonVSKanyeAPI(client);

            string ronQuote = api.RonWords();
            string kanyeQuote = api.KanyeWords();

            Console.WriteLine($"Kanye: {kanyeQuote}");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine($"Ron: \"{kanyeQuote}?\" \n{ronQuote}");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(4000);

            for (int i = 0; i < 5; i++)
            {
                ronQuote = api.RonWords();
                kanyeQuote = api.KanyeWords();

                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine();
                Thread.Sleep(2000);
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine();
                Thread.Sleep(4000);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Kanye: ....");
            Console.WriteLine();
            Thread.Sleep(5000);
            Console.WriteLine($"Ron: I'm Ron %*$#ing Swanson.");
        }
    }
}
