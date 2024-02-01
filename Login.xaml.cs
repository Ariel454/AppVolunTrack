using AppVolunTrack.Models;
using Newtonsoft.Json;

namespace AppVolunTrack;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    public async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string user = UserNameEntry.Text;
        string pass = passwordEntry.Text;


        using (var client = new HttpClient())
        {
            var url = "https://localhost:3001/Usuario/ListarUsuarios";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
                Usuario usuario = listaUsuarios.FirstOrDefault(u => u.NombreUsuario == user && u.Contrasenia == pass);
                if (usuario != null)
                {
                    //await Navigation.PushAsync(new MainPage(usuario));
                    await Task.Delay(1000); // Esperar un momento
                    await DisplayAlert("Mensaje", "Ingreso exitoso", "OK");

                }
                else
                {
                    // Credenciales inv�lidas, mostrar mensaje de error
                    await DisplayAlert("Alerta", "Credenciales inv�lidas", "OK");
                }
            }
        }
    }


}