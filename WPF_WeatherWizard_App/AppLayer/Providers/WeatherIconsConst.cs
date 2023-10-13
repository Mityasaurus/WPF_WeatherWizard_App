using System.Collections.Generic;

namespace WPF_WeatherWizard_App.AppLayer.Providers
{
    public static class WeatherIconsConst
    {
        public static readonly Dictionary<List<string>, string> Icons = new Dictionary<List<string>, string>
        {
            { new List<string> {"Sunny" }, "sunny.png" },
            { new List<string> { "Clear" }, "clear.png" },
            { new List<string> {"Partly cloudy" }, "partly-cloudy.png" },
            { new List<string> { "Cloudy", "Mist" }, "cloudy.png" },
            { new List<string> {"Overcast" }, "overcast.png" },
            { new List<string> {"Patchy rain possible", "Patchy sleet possible", "Patchy freezing drizzle possible",
                "Patchy light drizzle", "Light drizzle", "Freezing drizzle", "Patchy light rain",
                "Moderate rain at times", "Light rain", "Moderate rain", "Light freezing rain",
                "Light sleet", "Light rain shower", "Light sleet showers", "Patchy light rain with thunder",
                "Thundery outbreaks possible" }, "patchy-rain.png" },
            { new List<string> { "Patchy snow possible", "Blowing snow", "Blizzard" }, "snow.png" },
            { new List<string> { "Fog", "Freezing fog" }, "fog.png" },
            { new List<string> { "Heavy freezing drizzle", "Heavy rain at times", "Heavy rain", "Moderate or heavy freezing rain",
                "Moderate or heavy sleet", "Moderate or heavy rain shower", "Torrential rain shower",
                "Moderate or heavy sleet showers" }, "heavy-rain.png" },
            { new List<string> { "Patchy light snow", "Light snow", "Patchy moderate snow", "Moderate snow", "Patchy heavy snow",
                "Heavy snow", "Ice pellets", "Light snow showers", "Moderate or heavy snow showers",
                "Light showers of ice pellets", "Patchy light snow with thunder", "Moderate or heavy snow with thunder" }, "snow.png" }
        };
    }
}
