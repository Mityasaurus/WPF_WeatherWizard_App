namespace WPF_WeatherWizard_App.API_CORE.Engines;

public interface IApi
{
    public string GetForecast(string city, int days = 4, bool aqi = false, bool alerts = false);

    public string GetForecast(double lat, double lng, int days = 4, bool aqi = false, bool alerts = false);
}