using System;

namespace WPF_WeatherWizard_App.APP.Models
{
    public class Hour
    {
        public DateTime Time { get; set; }

        public decimal? TempC { get; set; }

        public decimal? TempF { get; set; }

        public string? condition { get; set; }

        public int? ChanceOfRain { get; set; }
    }
}
