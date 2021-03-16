using System;

namespace HexBlazorLib
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public double TemperatureF { get; set; }

        public double TemperatureC
        {
            get
            {
                return Math.Round((TemperatureF - 32d) * (5d/9d),1);
            }
        }

    }
}
