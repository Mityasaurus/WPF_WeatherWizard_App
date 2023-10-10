using System;
using System.Collections.Generic;

namespace WPF_WeatherWizard_App.APP.Models
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

    }
}
