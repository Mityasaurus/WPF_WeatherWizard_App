using System;
using System.IO;
using WPF_WeatherWizard_App.AppLayer.Providers;

namespace WPF_WeatherWizard_App.AppLayer.Models
{
    public class Hour
    {
        public DateTime Time { get; set; }

        public decimal? TempC { get; set; }

        public decimal? TempF { get; set; }

        public string? Condition { get; set; }

        public int? ChanceOfRain { get; set; }

        public int? IsDay { get; set; }

        public string? ForecastImageURL
        {
            get
            {
                string icon = IconProvider.GetWeatherIcon(Condition, IsDay == 1 ? true : false);

                return IconProvider.GetWeatherIconPath(icon);
            }
        }
    }
}
