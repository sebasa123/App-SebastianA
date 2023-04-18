using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_SebastianA.ViewModels;
using Acr.UserDialogs;

namespace App_SebastianA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        UserViewModel viewModel;
        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }
        private  async void BtnLogIn_Clicked(object sender, EventArgs e)
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtContra.Text != null && !string.IsNullOrEmpty(TxtContra.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Revisando acceso del usuario");
                    await Task.Delay(2000);
                    string nombre = TxtNombre.Text.Trim();
                    string contra = TxtContra.Text.Trim();
                    R = await viewModel.UsuarioAccessValidation(nombre, contra);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await DisplayAlert("Error de validacion", "Se requiere ingresar el nombre y contrasenna:", "OK");
                return;
            }
            if (R)
            {
                GlobalObjects.LocalUsuario = await viewModel.GetUsuarioData(TxtNombre.Text.Trim());
                await Navigation.PushAsync(new OptionsPage());
                return;
            }
            else
            {
                await DisplayAlert("Validation failed", "Access denied", "OK");
                return;
            }
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void SwVerContra_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwVerContra.IsToggled)
            {
                TxtContra.IsPassword = false;
            }
            else
            {
                TxtContra.IsPassword = true;
            }
        }

        private async void LblPasswordRecovery_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordRecoveryPage());
        }
    }
}