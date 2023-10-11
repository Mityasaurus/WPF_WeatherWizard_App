using System;
using System.Collections.Generic;
using WPF_WeatherWizard_App.AppLayer.Providers;

namespace WPF_WeatherWizard_App.AppLayer.Models
{
    public class Day
    {
        public DateTime Date { get; set; }

        public decimal? MaxTempC { get; set; }

        public decimal? MinTempC { get; set; }

        public decimal? MaxTempF { get; set; }

        public decimal? MinTempF { get; set; }

        public string? Condition { get; set; }

        public List<Hour>? Hours { get; set; }

        public string? ForecastImageURL
        {
            get
            {
                string icon = IconProvider.GetWeatherIcon(Condition, true);

                return IconProvider.GetWeatherIconPath(icon);
            }
        }
    }
}
