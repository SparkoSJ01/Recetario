using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Recetario
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ubicacion : ContentPage
    {
        double latitud;
        double longitud;
        public Ubicacion()
        {
            InitializeComponent();
            localizar();
        }
        private async void localizar()
        {
            var localizador = CrossGeolocator.Current;
            localizador.DesiredAccuracy = 50;
            if (localizador.IsGeolocationAvailable)
            {
                if (localizador.IsGeolocationEnabled)
                {
                    if (!localizador.IsListening)
                    {
                        await localizador.StartListeningAsync(TimeSpan.FromSeconds(1), 5);

                    }
                    localizador.PositionChanged += (cambia, args) =>
                    {
                        var loc = args.Position;
                        lat.Text = loc.Latitude.ToString();
                        latitud = double.Parse(lat.Text);
                        lon.Text = loc.Longitude.ToString();
                        longitud = double.Parse(lon.Text);
                    };
                }
            }
        }
        private async void mostrarMapa_Clicked(System.Object sender, System.EventArgs e)
        {
            MapLaunchOptions opciones = new MapLaunchOptions { Name = "Posición actual" };
            await Map.OpenAsync(latitud, longitud, opciones);
        }
    }
}
