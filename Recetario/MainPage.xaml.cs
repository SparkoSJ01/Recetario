using Recetario.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Recetario
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Desayunos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Desayunos());
        }

        private async void ComidaMexicana_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComidaMexicana());
        }

        private async void Cocteles_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cocteles());
        }

        private async void ComidaVegana_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComidaVegana());
        }

        private async void Postres_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Postres());
        }

        private async void PescadosMariscos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PescadosMariscos());
        }

        private async void Pasta_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pasta());
        }

        private async void AcercaDe_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AcercaDe());
        }
    }
}
