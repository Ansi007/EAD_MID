using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidTermN_TierBO;
using WeatherBLL;
namespace WeatherPL
{
    public class WeatherView
    {
        public void SaveWeatherDetails()
        {
            WeatherBO b = new WeatherBO();
            Console.Write("Give Temperature: ");
            b.Temperature = int.Parse(Console.ReadLine());
            Console.Write("Give Precipitation: ");
            b.Precipitation = int.Parse(Console.ReadLine());
            Console.Write("Give Humidity: ");
            b.Humidity = int.Parse(Console.ReadLine());
            Console.Write("Give Wind: ");
            b.Wind = int.Parse(Console.ReadLine());
            WeatherManager w = new WeatherManager();
            w.SaveWeather(b);
        }

        public void PrintWeatherDetails()
        {
            WeatherManager w = new WeatherManager();
            List<WeatherBO> weather = w.RetrieveWeathers();
            foreach (WeatherBO b in weather)
            {
                string s = $"{b.Temperature},{b.Precipitation}," +
                    $"{b.Humidity},{b.Wind},{b.FeelsLike}";
                Console.WriteLine(s);
            }
        }
    }
}
