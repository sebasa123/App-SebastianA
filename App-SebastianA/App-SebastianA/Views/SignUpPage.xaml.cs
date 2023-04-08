using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_SebastianA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_SebastianA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        UserViewModel viewModel;
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddUsuario(TxtNombre.Text.Trim(), TxtContra.Text.Trim(),
                TxtID.Text.Trim(), PckrEstadoUsuario, SelectedTipoUsuario.IDTipoUs);

            if (R)
            {
                await DisplayAlert(": )", "Usuario agregado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }
    }
}