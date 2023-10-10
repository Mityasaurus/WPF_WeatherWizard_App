using System;

namespace WPF_WeatherWizard_App.AppLayer.Models
{
    public class Location
    {
        public string Name { get; set; }

        public string? Country { get; set; }

        public DateTime? LocalTime { get; set; }
    }
}
