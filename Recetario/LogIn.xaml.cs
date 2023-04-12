using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Recetario.Modelo;

namespace Recetario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogIn : ContentPage
	{
        SeedRecetario enlace = new SeedRecetario();
        public LogIn ()
		{
			InitializeComponent ();
		}

        async private void btnentrar_Clicked(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios
            {
                Correo = txtcorreo.Text,
                password = txtpass.Text
            };
            Uri ruta = new Uri(enlace.dominio + "Login.php");
            var cliente = new HttpClient();
            var json = JsonConvert.SerializeObject(usu);
            var contenidoJson = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await cliente.PostAsync(ruta, contenidoJson);

            try
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var contenido = await res.Content.ReadAsStringAsync();
                    txtres.Text = contenido;

                    Usuarios tmp = JsonConvert.DeserializeObject<Usuarios>(contenido);
                    if (tmp.respuesta == "OK")
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Datos Erroneos", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error de conexión", "Verifique su conexión", "OK");
                }

            }
            catch (Exception error)
            {
                await DisplayAlert("Aviso", "Intente mas tarde", "OK");
            }

        }

    }

}
