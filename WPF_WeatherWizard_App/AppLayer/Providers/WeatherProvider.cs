using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WPF_WeatherWizard_App.API_CORE.Engines;
using WPF_WeatherWizard_App.AppLayer.Models;

namespace WPF_WeatherWizard_App.AppLayer.Providers
{
    internal class WeatherProvider
    {
        private readonly WeatherWizardApiEngine engine;

        public WeatherProvider()
        {
            engine = new WeatherWizardApiEngine();
        }

        public WeatherInfo GetWeatherInfo(string city)
        {
            string json = engine.GetForecast(city);

            JObject jObject = JObject.Parse(json);

            WeatherInfo weatherInfo = new WeatherInfo();

            SetLocation(weatherInfo, jObject);
            SetCurrentData(weatherInfo, jObject);

            return weatherInfo;
        }

        private void SetLocation(WeatherInfo weatherInfo, JObject jObject)
        {
            JToken token = jObject["location"];

            if (token == null)
                return;

            Location location = new Location();

            location.Name = token.Value<string>("name");
            location.Country = token.Value<string>("country");
            location.LocalTime = token.Value<DateTime>("localtime");

            weatherInfo.Location = location;
        }

        private void SetCurrentData(WeatherInfo weatherInfo, JObject jObject)
        {
            JToken token = jObject["current"];

            if (token == null)
                return;

            weatherInfo.CurrentTempC = token.Value<decimal>("temp_c");
            weatherInfo.CurrentTempF = token.Value<decimal>("temp_f");
            weatherInfo.IsDay = token.Value<int>("is_day");
            weatherInfo.Condition = token["condition"]?.Value<string>("text");
            weatherInfo.WindKph = token.Value<decimal>("wind_kph");
            weatherInfo.Humidity = token.Value<int>("humidity");
            weatherInfo.FeelsLikeC = token.Value<decimal>("feelslike_c");
            SetDays(weatherInfo, jObject);
        }

        private void SetDays(WeatherInfo weatherInfo, JObject jObject)
        {
            JToken forecast = jObject["forecast"]["forecastday"];
            JArray forecastTokens = forecast as JArray;

            if (forecastTokens == null)
                return;

            List<Day> days = new List<Day>();

            foreach (var token in forecastTokens)
            {
                var dayToken = token["day"];

                if (dayToken != null)
                {
                    Day day = CreateDayFromJson(token);
                    days.Add(day);
                }
            }

            weatherInfo.Days = days;
        }

        private Day CreateDayFromJson(JToken token)
        {
            var dayToken = token["day"];

            return new Day
            {
                Date = token.Value<DateTime>("date"),
                MaxTempC = dayToken.Value<decimal>("maxtemp_c"),
                MaxTempF = dayToken.Value<decimal>("maxtemp_f"),
                MinTempC = dayToken.Value<decimal>("mintemp_c"),
                MinTempF = dayToken.Value<decimal>("mintemp_f"),
                Condition = dayToken["condition"]?.Value<string>("text"),
                Hours = CreateHoursFromJson(token["hour"])
            };
        }

        private List<Hour> CreateHoursFromJson(JToken token)
        {
            JArray hourTokens = token as JArray;

            if (hourTokens == null)
                return new List<Hour>();

            List<Hour> hours = new List<Hour>();
            int interval = 5;

            foreach (var hourToken in hourTokens)
            {
                if (hourToken != null)
                {
                    DateTime time = hourToken.Value<DateTime>("time");

                    if ((time.Hour - 2) % interval == 0)
                    {
                        Hour hour = new Hour
                        {
                            Time = time,
                            TempC = hourToken.Value<decimal>("temp_c"),
                            TempF = hourToken.Value<decimal>("temp_f"),
                            Condition = hourToken["condition"]?.Value<string>("text"),
                            ChanceOfRain = hourToken.Value<int>("chance_of_rain"),
                            IsDay = hourToken.Value<int>("is_day")
                        };
                        hours.Add(hour);
                    }
                }
            }

            return hours;
        }

    }
}
