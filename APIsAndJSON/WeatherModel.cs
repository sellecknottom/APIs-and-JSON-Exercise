using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class WeatherModel
    {
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Temp main { get; set; }
        public Clouds clouds { get; set; }
        public string name { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }


    public class Temp
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int humidity { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }


}
