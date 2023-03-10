using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recetario.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcercaDe : ContentPage
    {
        SeedRecetario enlace = new SeedRecetario();
        public AcercaDe()
        {
            InitializeComponent();
            proxy();
        }
        public void proxy()
        {
            webView.IsVisible = false;
            webView.Source = enlace.dominio + "AcercaDe.php";

        }
        async private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Indicador.IsRunning = true;
            Indicador.IsEnabled = true;


            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(15);

            try
            {
                var response = await httpClient.GetAsync(enlace.dominio + "AcercaDe.php");

                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error de conexion", "verifique por favor", "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                    webView.IsVisible = true;
            }
            catch (Exception error)
            {

                await DisplayAlert("Sin internet", "Intente más tarde", "OK");
                await DisplayAlert(error + "", "Intente más tarde", "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }
        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            lbl.IsVisible = false;
            Indicador.IsRunning = false;
            VistaOpaca.IsVisible = false;

        }
        private void Busqueda_SearchButtonPressed(object sender, EventArgs e)
        {
        }
    }
}