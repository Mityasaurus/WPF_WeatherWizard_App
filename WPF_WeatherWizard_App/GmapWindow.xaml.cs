using GMap.NET;
using GMap.NET.MapProviders;
using System.Windows;
using System.Windows.Input;

namespace WPF_WeatherWizard_App
{
    public partial class GmapWindow : Window
    {
        public double Lat { get; private set; }
        public double Lng { get; private set; }
        public GmapWindow()
        {
            InitializeComponent();

            gmapControl.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmapControl.Position = new PointLatLng(0, 0);
            gmapControl.MapProvider = GoogleMapProvider.Instance;
            gmapControl.MinZoom = 3;
            gmapControl.MaxZoom = 16;
            gmapControl.Zoom = 5;
            gmapControl.Position = new PointLatLng(49.5397, 31.4960);
            gmapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gmapControl.CanDragMap = true;
            gmapControl.ShowCenter = false;
            gmapControl.ShowTileGridLines = false;

            gmapControl.MouseDoubleClick += GmapControl_MouseClick;
        }

        private void GmapControl_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng point = gmapControl.FromLocalToLatLng((int)e.GetPosition(gmapControl).X, (int)e.GetPosition(gmapControl).Y);
            Lat = point.Lat;
            Lng = point.Lng;
            this.DialogResult = true;
            this.Close();
        }
    }
}
