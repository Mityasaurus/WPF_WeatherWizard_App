using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WPF_WeatherWizard_App.API_CORE.Engines
{
    public static class IpAddressHelper
    {
        public static string GetIp()
        {
            var client = new HttpClient();

            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.ipify.org/"));
            var content = response.Result.Content.ReadAsStringAsync();
            return content.Result;
        }

        public static string GetLocationFromIp(string ip, string token)
        {
            var client = new HttpClient();

            var response = client.SendAsync(new HttpRequestMessage(
                HttpMethod.Get,
                $"https://ipinfo.io/{ip}?token={token}"
                ));
            var content = response.Result.Content.ReadAsStringAsync();
            return content.Result;
        }
    }
}
