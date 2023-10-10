using System.Collections.Generic;

namespace WPF_WeatherWizard_App.APP.Models
{
    public class WeatherInfo
    {
        public Location Location { get; set; }

        public decimal? CurrentTempC { get; set; }

        public decimal? CurrentTempF { get; set; }

        public int? IsDay { get; set; }

        public string? Condition { get; set; }

        public decimal? WindKph { get; set; }

        public decimal? FeelsLikeC { get; set; }

        public int? Humidity { get; set; }

        public List<Day>? Days { get; set; }
    }
}
