using Newtonsoft.Json.Linq;
using WPF_WeatherWizard_App.API_CORE.Engines;

namespace WPF_WeatherWizard_App.AppLayer.Providers
{
    public class LocationProvider
    {
        private static string ipInfoToken = "6a9340f2dd7e31";

        public static string GetCurrentLocation()
        {
            var locationJson = IpAddressHelper.GetLocationFromIp(IpAddressHelper.GetIp(), ipInfoToken);

            JObject location = JObject.Parse(locationJson);

            return location != null ? location.Value<string>("city") : null;
        }
    }
}
