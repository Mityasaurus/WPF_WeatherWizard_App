
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF_WeatherWizard_App.AppLayer.Models;
using WPF_WeatherWizard_App.AppLayer.Providers;

namespace WPF_WeatherWizard_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private WeatherInfo info;
        private WeatherProvider weatherProvider;

        private string currentCity;
        public MainWindow()
        {
            InitializeComponent();

            weatherProvider = new WeatherProvider();
            currentCity = "Kyiv";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWeather(weatherProvider.GetWeatherInfo(currentCity));
        }

        private void UpdateWeather(WeatherInfo weatherInfo)
        {
            info = weatherInfo;
            DataContext = null;
            DataContext = info;

            ChangeBackground(info.IsDay == 1 ? true : false);

            string iconName = IconProvider.GetWeatherIcon(info.Condition, info.IsDay == 1 ? true : false);
            IconProvider.SetImageSource(im_curCondition, iconName);

            IconProvider.SetImageSource(im_curFeelsLike, "feels-like.png");
            IconProvider.SetImageSource(im_curHumidity, "humidity.png");
            IconProvider.SetImageSource(im_curWind, "wind.png");

            lv_TimeForecastForDay.ItemsSource = null;
            lv_TimeForecastForDay.ItemsSource = info.Days[0].Hours;

            lv_Forecast.ItemsSource = null;
            lv_Forecast.ItemsSource = info.Days;
        }

        private void ChangeBackground(bool day_night)
        {
            string backgroundName = "background-night.png";
            if (day_night)
            {
                backgroundName = "background-day.png";
            }

            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            Uri backgroundImageUri = new Uri(Path.Combine(solutionDirectory, $"UI/Source/Images/{backgroundName}"));

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(backgroundImageUri);

            this.Background = imageBrush;
        }

        private void lv_Forecast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lv_Forecast.SelectedIndex;


            if (selectedIndex >= 0)
            {

                lv_TimeForecastForDay.ItemsSource = info.Days[selectedIndex].Hours;
            }
        }

        private void btn_Сelsius_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            tb_curTemprature.Text = info.CurrentTempC.ToString();
        }

        private void btn_Fahrenheit_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            tb_curTemprature.Text = info.CurrentTempF.ToString();
        }

        private void lv_TimeForecastForDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lv_TimeForecastForDay.SelectedIndex = -1;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string cityToSearch = tb_Search.Text;

            WeatherInfo tmp = weatherProvider.GetWeatherInfo(cityToSearch);
            if(!string.IsNullOrWhiteSpace(tmp.Condition))
            {
                UpdateWeather(tmp);
            }
        }

        private void tb_Search_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(tb_Search.Text == "Enter city")
            {
                tb_Search.Text = "";
            }
        }

        private void tb_Search_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(tb_Search.Text == "")
            {
                tb_Search.Text = "Enter city";
            }
        }
    }
}
