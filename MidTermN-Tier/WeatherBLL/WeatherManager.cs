using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidTermN_TierBO;
using WeatherDAL;

namespace WeatherBLL
{
    public class WeatherManager
    {
        public void SaveWeather(WeatherBO b)
        {
            if(b.Temperature < 20)
            {
                b.FeelsLike = "Cold";
            }
            else if(b.Temperature > 20)
            {
                b.FeelsLike = "Hot";
            }
            WeatherDLLL dll = new WeatherDLLL();
            dll.StoreWeather(b);
        }

        public List<WeatherBO> RetrieveWeathers()
        {
            WeatherDLLL dll = new WeatherDLLL();
            return dll.RetrieveWeather();
        }
    }
}
