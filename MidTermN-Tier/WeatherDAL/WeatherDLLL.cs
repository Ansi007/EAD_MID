using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidTermN_TierBO;

namespace WeatherDAL
{
    public class WeatherDLLL
    {
       public void StoreWeather(WeatherBO b)
        {
            StreamWriter sw = new StreamWriter("MyFile.txt",append:true);
            string s = $"{b.Temperature},{b.Precipitation}," +
                $"{b.Humidity},{b.Wind},{b.FeelsLike}";
            sw.WriteLine(s);
            sw.Close();
        }

        public List<WeatherBO> RetrieveWeather()
        {
            StreamReader sr = new StreamReader("MyFile.txt");
            List<WeatherBO> list = new List<WeatherBO>();
            while (true)
            {
                string s = sr.ReadLine();
                if (s == null) break;
                WeatherBO b = new WeatherBO();
                string[] val = s.Split(',');
                b.Temperature = Convert.ToInt32(val[0]);
                b.Precipitation = Convert.ToInt32(val[1]);
                b.Humidity = Convert.ToInt32(val[2]);
                b.Wind = Convert.ToInt32(val[3]);
                b.FeelsLike = val[4];
                list.Add(b);
            }
            sr.Close();
            return list;
        }
    }
}
