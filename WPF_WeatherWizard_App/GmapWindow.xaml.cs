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

            // Инициализация карты
            gmapControl.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmapControl.Position = new PointLatLng(0, 0); // Начальное положение карты
            gmapControl.MapProvider = GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            gmapControl.MinZoom = 3; //минимальный зум
            gmapControl.MaxZoom = 16; //максимальный зум
            gmapControl.Zoom = 5; // какой используется зум при открытии
            gmapControl.Position = new PointLatLng(49.5397, 31.4960); // точка в центре карты при открытии (центр России)
            gmapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gmapControl.CanDragMap = true; // перетаскивание карты мышью
            //gmapControl.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gmapControl.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gmapControl.ShowTileGridLines = false; //показывать или скрывать тайлы

            // Обработчик события для щелчка мышью на карте
            gmapControl.MouseDoubleClick += GmapControl_MouseClick;
        }

        private void GmapControl_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng point = gmapControl.FromLocalToLatLng((int)e.GetPosition(gmapControl).X, (int)e.GetPosition(gmapControl).Y);
            Lat = point.Lat;
            Lng = point.Lng;
            this.Close();
        }
    }
}
