using System;
using System.IO;
using System.Linq;

namespace WPF_WeatherWizard_App.AppLayer.Providers
{
    public static class IconProvider
    {
        public static string GetWeatherIcon(string condition, bool isDay)
        {
            var matchingIcons = WeatherIconsConst.Icons.FirstOrDefault(pair => pair.Key.Contains(condition));

            string icon = matchingIcons.Value;

            if (icon == "snow.png")
            {
                return isDay ? "snow_d.png" : "snow_n.png";
            }
            if (icon == "partly-cloudy.png")
            {
                return isDay ? "partly-cloudy_d.png" : "partly-cloudy_n.png";
            }

            return icon;
        }

        public static Uri GetWeatherIconUri(string iconName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            Uri backgroundImageUri = new Uri(Path.Combine(solutionDirectory, $"UI/Source/Icons/{iconName}"));

            return backgroundImageUri;
        }

        public static string GetWeatherIconPath(string iconName)
        {
            return GetWeatherIconUri(iconName).AbsolutePath;
        }
    }
}
