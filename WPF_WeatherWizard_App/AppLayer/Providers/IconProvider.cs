using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace WPF_WeatherWizard_App.AppLayer.Providers;

public class IconProvider
{
    private static Dictionary<string, string> _icons = new Dictionary<string, string>()
    {
        { "Sunny", "sunny.png" },
        { "Clear", "clear.png" },
        { "Partly cloudy", "partly-cloudy.png" },
        { "Cloudy", "cloudy.png" },
        { "Overcast", "overcast.png" },
        { "Mist", "cloudy.png" },
        { "Patchy rain possible", "patchy-rain.png" },
        { "Patchy snow possible", "snow.png" },
        { "Patchy sleet possible", "patchy-rain.png" },
        { "Patchy freezing drizzle possible", "patchy-rain.png" },
        { "Thundery outbreaks possible", "thunder.png" },
        { "Blowing snow", "wind.png" },
        { "Blizzard", "wind.png" },
        { "Fog", "fog.png" },
        { "Freezing fog", "fog.png" },
        { "Patchy light drizzle", "patchy-rain.png" },
        { "Light drizzle", "patchy-rain.png" },
        { "Freezing drizzle", "patchy-rain.png" },
        { "Heavy freezing drizzle", "heavy-rain.png" },
        { "Patchy light rain", "patchy-rain.png" },
        { "Light rain", "patchy-rain.png" },
        { "Moderate rain at times", "patchy-rain.png" },
        { "Moderate rain", "patchy-rain.png" },
        { "Heavy rain at times", "heavy-rain.png" },
        { "Heavy rain", "heavy-rain.png" },
        { "Light freezing rain", "patchy-rain.png" },
        { "Moderate or heavy freezing rain", "heavy-rain.png" },
        { "Light sleet", "patchy-rain.png" },
        { "Moderate or heavy sleet", "heavy-rain.png" },
        { "Patchy light snow", "snow.png" },
        { "Light snow", "snow.png" },
        { "Patchy moderate snow", "snow.png" },
        { "Moderate snow", "snow.png" },
        { "Patchy heavy snow", "snow.png" },
        { "Heavy snow", "snow.png" },
        { "Ice pellets", "snow.png" },
        { "Light rain shower", "patchy-rain.png" },
        { "Moderate or heavy rain shower", "heavy-rain.png" },
        { "Torrential rain shower", "heavy-rain.png" },
        { "Light sleet showers", "patchy-rain.png" },
        { "Moderate or heavy sleet showers", "heavy-rain.png" },
        { "Light snow showers", "snow.png" },
        { "Moderate or heavy snow showers", "snow.png" },
        { "Light showers of ice pellets", "snow.png" },
        { "Moderate or heavy showers of ice pellets", "snow.png" },
        { "Patchy light rain with thunder", "patchy-rain.png" },
        { "Moderate or heavy rain with thunder", "heavy-rain.png" },
        { "Patchy light snow with thunder", "snow.png" },
        { "Moderate or heavy snow with thunder", "snow.png" },
    };
    
    public static string GetWeatherIcon(string condition, bool isDay)
    {
        string icon = _icons[condition];
        if (icon == "snow.png") return isDay ? "snow_d.png" : "snow_n.png";
        if (icon == "partly-cloudy.png") return isDay ? "partly-cloudy_d.png" : "partly-cloudy_n.png";
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

    public static void SetImageSource(Image image, string iconName)
    {
        try
        {
            image.Source = new BitmapImage(GetWeatherIconUri(iconName));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}