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
using System.Windows.Threading;
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
        private bool IsCelsius = true;
        private int selectedDayIndex = -1;

        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            weatherProvider = new WeatherProvider();
            currentCity = "Kyiv";

            IconProvider.SetImageSource(im_curFeelsLike, "feels-like.png");
            IconProvider.SetImageSource(im_curHumidity, "humidity.png");
            IconProvider.SetImageSource(im_curWind, "wind.png");

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateWeather(weatherProvider.GetWeatherInfo(currentCity));

            if (selectedDayIndex >= 0)
            {
                lv_TimeForecastForDay.ItemsSource = info.Days[selectedDayIndex].Hours;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWeather(weatherProvider.GetWeatherInfo(currentCity));
        }

        private void UpdateWeather(WeatherInfo weatherInfo)
        {
            info = weatherInfo;
            currentCity = weatherInfo.Location.Name;
            DataContext = null;
            DataContext = info;

            lv_TimeForecastForDay.ItemsSource = null;
            lv_TimeForecastForDay.ItemsSource = info.Days[0].Hours;

            lv_Forecast.ItemsSource = null;
            lv_Forecast.ItemsSource = info.Days;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (IsCelsius)
            {
                tb_curTemprature.Text = info.CurrentTempC.ToString();
            }
            else
            {
                tb_curTemprature.Text = info.CurrentTempF.ToString();
            }

            UpdateDesign();
        }

        private void UpdateDesign()
        {
            ChangeBackground(info.IsDay == 1 ? true : false);

            string iconName = IconProvider.GetWeatherIcon(info.Condition, info.IsDay == 1 ? true : false);
            IconProvider.SetImageSource(im_curCondition, iconName);

            if (info.IsDay == 1)
            {
                Application.Current.Resources["btnSearchBackgroundBrush"] = new SolidColorBrush(GetColorFromHex("#17249a"));
                Application.Current.Resources["btnSearchForegroundBrush"] = new SolidColorBrush(Colors.White);
                Application.Current.Resources["btnSearchMouseOverBackgroundBrush"] = new SolidColorBrush(GetColorFromHex("#1828b9"));

                Application.Current.Resources["tbSearchBackgroundBrush"] = new SolidColorBrush(Colors.White);
                Application.Current.Resources["tbSearchForegroundBrush"] = new SolidColorBrush(Colors.Black);
            }
            else
            {
                Application.Current.Resources["btnSearchBackgroundBrush"] = new SolidColorBrush(Colors.Lavender);
                Application.Current.Resources["btnSearchForegroundBrush"] = new SolidColorBrush(GetColorFromHex("#2e3a6f"));
                Application.Current.Resources["btnSearchMouseOverBackgroundBrush"] = new SolidColorBrush(GetColorFromHex("#f7f7ff"));

                Application.Current.Resources["tbSearchBackgroundBrush"] = new SolidColorBrush(GetColorFromHex("#273161"));
                Application.Current.Resources["tbSearchForegroundBrush"] = new SolidColorBrush(Colors.White);
            }
        }

        private Color GetColorFromHex(string hexColor)
        {
            Color color;

            try
            {
                color = Color.FromRgb(
                    byte.Parse(hexColor.Substring(1, 2), NumberStyles.HexNumber),
                    byte.Parse(hexColor.Substring(3, 2), NumberStyles.HexNumber),
                    byte.Parse(hexColor.Substring(5, 2), NumberStyles.HexNumber)
                );
            }
            catch
            {
                color = Colors.White;
            }

            return color;
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
                selectedDayIndex = selectedIndex;
            }
        }

        private void btn_Сelsius_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            tb_curTemprature.Text = info.CurrentTempC.ToString();
            IsCelsius = true;
        }

        private void btn_Fahrenheit_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            tb_curTemprature.Text = info.CurrentTempF.ToString();
            IsCelsius = false;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (tb_Search.Text == "Enter city")
            {
                return;
            }

            string cityToSearch = tb_Search.Text;

            WeatherInfo tmp = weatherProvider.GetWeatherInfo(cityToSearch);
            if (!string.IsNullOrWhiteSpace(tmp.Condition))
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && tb_Search.IsKeyboardFocused)
            {
                Search();
            }
        }
    }
}
