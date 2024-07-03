using Microsoft.Extensions.Configuration;

namespace APIsAndJSON
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            OpenWeatherMapAPI api = new OpenWeatherMapAPI(client);
            api.Action();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            RonVSKanyeAPI.Convo();


        }
    }
}
