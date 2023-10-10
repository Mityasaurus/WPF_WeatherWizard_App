using System;
using System.Collections.Generic;
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

namespace WPF_WeatherWizard_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Uri GetIconPath(string iconName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            Uri backgroundImageUri = new Uri(Path.Combine(solutionDirectory, $"UI/Source/Icons/{iconName}"));

            return backgroundImageUri;
        }

        private void ChangeBackground(bool day_night)
        {
            string backgroundName = "background-night.png";
            if(day_night)
            {
                backgroundName = "background-day.png";
            }

            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            Uri backgroundImageUri = new Uri(Path.Combine(solutionDirectory, $"UI/Source/Images/{backgroundName}"));

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(backgroundImageUri);

            this.Background = imageBrush;
        }

        private void SetImageSource(Image image, string iconName)
        {
            try
            {
                image.Source = new BitmapImage(GetIconPath(iconName));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeBackground(false);
            //SetImageSource(image, "feels-like.png");
            //SetImageSource(image, "humidity.png");
            SetImageSource(image, "wind.png");

            //////////////////////////////////////////

            //SetImageSource(imageMid, "sunny.png");
            //SetImageSource(imageMid, "clear.png");
            //SetImageSource(imageMid, "partly cloudy_d.png");
            //SetImageSource(imageMid, "partly cloudy_n.png");
            //SetImageSource(imageMid, "cloudy.png");
            //SetImageSource(imageMid, "overcast.png");
            //SetImageSource(imageMid, "patchy rain.png");
            //SetImageSource(imageMid, "heavy rain.png");
            //SetImageSource(imageMid, "thunder.png");
            //SetImageSource(imageMid, "snow_d.png");
            //SetImageSource(imageMid, "snow_n.png");
            SetImageSource(imageMid, "fog.png");
        }
    }
}
