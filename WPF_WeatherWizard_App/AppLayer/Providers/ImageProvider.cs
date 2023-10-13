using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_WeatherWizard_App.AppLayer.Providers
{
    public static class ImageProvider
    {
        public static void SetImageSource(Image image, string iconName)
        {
            try
            {
                image.Source = new BitmapImage(IconProvider.GetWeatherIconUri(iconName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
