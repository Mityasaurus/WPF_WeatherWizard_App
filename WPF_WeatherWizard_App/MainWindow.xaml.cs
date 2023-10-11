
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
        WeatherProvider weatherProvider;
        public MainWindow()
        {
            InitializeComponent();
            DefaultSet();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void DefaultSet()
        {
            weatherProvider = new WeatherProvider();
            info = weatherProvider.GetWeatherInfo("Kyiv");
            //info = weatherProvider.GetWeatherInfo("Los-Angeles");
            DataContext = info;


            ChangeBackground(info.IsDay == 1 ? true : false);

            IconProvider.SetImageSource(im_curCondition, $"{info.Condition}.png");

            IconProvider.SetImageSource(im_curFeelsLike, "feels-like.png");
            IconProvider.SetImageSource(im_curHumidity, "humidity.png");
            IconProvider.SetImageSource(im_curWind, "wind.png");


            lv_TimeForecastForDay.ItemsSource = info.Days[0].Hours;
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
    }


}
