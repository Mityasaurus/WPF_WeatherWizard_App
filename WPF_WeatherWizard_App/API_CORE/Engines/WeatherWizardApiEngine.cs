using System;
using System.Net.Http;

namespace WPF_WeatherWizard_App.API_CORE.Engines;

public class WeatherWizardApiEngine : IApi
{
    private HttpClient _client { get; set; }
    private string _baseAddress = "http://api.weatherapi.com/v1/forecast.json?key=3e21b608b818455ea86165609230810";
    private string _apiKey = "3e21b608b818455ea86165609230810";

    public WeatherWizardApiEngine()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(_baseAddress);
    }
    
    public string GetForecast(string city, int days = 4, bool aqi = false, bool alerts = false) // aqi - air quality
    {
        var response = _client.SendAsync(
            new HttpRequestMessage(HttpMethod.Get, 
                _baseAddress + $"&q={city}&days={days}&aqi={aqi}&alerts={alerts}"
                ));
        var content = response.Result.Content.ReadAsStringAsync();
        return content.Result;
    }
}