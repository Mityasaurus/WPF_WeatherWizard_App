using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_WeatherWizard_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class WeatherInfo
    {
        public string Location { get; set; }
        public Current CurrentInfo { get; set; }

        public List< ForecastItem> ForecastItems { get; set; }

    }
    public class Current
    {
        public string DateTime { get; set; }
        public string CurrentImageURL { get; set; }
        public string CurrentTemp { get; set; }
        public string CurrentFeelsLike { get; set; }
        public string CurrentHumidity { get; set; }
        public string CurrentWind { get; set; }
        public string CurrentCondition { get; set; }
        public List<TimeForecastItem> TimeForecast { get; set; }
    }

    public class TimeForecastItem
    {
        public string Time { get; set; }
        public string ForecastImageURL { get; set; }
        public string Temp { get; set; }
        public string Wind { get; set; }
        public string ChanceOfRain { get; set; }
        public string Condition { get; set; }
    }

    public class ForecastItem
    {
        public string ForecastDay { get; set; }
        public string ForecastImageURL { get; set; }
        public string ForecastMinTemp { get; set; }
        public string ForecastMaxTemp { get; set; }
        public string ForecastCondition { get; set; }

        public List<TimeForecastItem> TimeForecast { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {

            List<TimeForecastItem> timeForecastItems = new List<TimeForecastItem>
            {
                new TimeForecastItem
                {
                    Time = "2:00",
                    ForecastImageURL = "icon",
                    Temp = "25",
                    Wind = "10",
                    ChanceOfRain = "30%",
                    Condition = "Sunny"
                },
                new TimeForecastItem
                {
                    Time = "7:00",
                    ForecastImageURL = "icon",
                    Temp = "28",
                    Wind = "15",
                    ChanceOfRain = "20%",
                    Condition = "Cloudy"
                },
                new TimeForecastItem
                {
                    Time = "12:00",
                    ForecastImageURL = "icon",
                    Temp = "28",
                    Wind = "15",
                    ChanceOfRain = "20%",
                    Condition = "Cloudy"
                },
                new TimeForecastItem
                {
                    Time = "17:00",
                    ForecastImageURL = "icon",
                    Temp = "25",
                    Wind = "16",
                    ChanceOfRain = "25%",
                    Condition = "Cloudy"
                },
                new TimeForecastItem
                {
                    Time = "22:00",
                    ForecastImageURL = "icon",
                    Temp = "21",
                    Wind = "15",
                    ChanceOfRain = "40%",
                    Condition = "Cloudy"
                },
            };

            

            List<ForecastItem> forecastItems = new List<ForecastItem>
            {
                new ForecastItem
                {
                    ForecastDay = "Monday",
                    ForecastImageURL = "icon",
                    ForecastMinTemp = "20",
                    ForecastMaxTemp = "30",
                    ForecastCondition = "Sunny",
                },
                new ForecastItem
                {
                    ForecastDay = "Tuesday",
                    ForecastImageURL = "icon",
                    ForecastMinTemp = "18",
                    ForecastMaxTemp = "28",
                    ForecastCondition = "Cloudy"
                },
                new ForecastItem
                {
                    ForecastDay = "Wednesday",
                    ForecastImageURL = "icon",
                    ForecastMinTemp = "18",
                    ForecastMaxTemp = "28",
                    ForecastCondition = "Cloudy"
                },
            };

           


            Current current = new Current()
            {
                DateTime = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToShortTimeString(),
                CurrentImageURL = "icon",
                CurrentTemp = "25",
                CurrentFeelsLike = "23",
                CurrentHumidity = "85",
                CurrentWind = "23",
                CurrentCondition = "Sunny",
                TimeForecast = timeForecastItems

            };

            WeatherInfo info = new WeatherInfo()
            {
                Location = "Kiyv",
                CurrentInfo = current,
                ForecastItems = forecastItems
            };

            DataContext = info;

            lv_TimeForecastForDay.ItemsSource = timeForecastItems;

            lv_Forecast.ItemsSource = forecastItems;
        }


    }


}
