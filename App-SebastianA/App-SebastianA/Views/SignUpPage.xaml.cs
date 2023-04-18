using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_SebastianA.Models;
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
            LoadTipoUsuarioList();
        }

        private async void LoadTipoUsuarioList() 
        {
            PckrTipoUsuario.ItemsSource = await viewModel.GetTipoUsuario();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            TipoUsuario SelectedTipoUsuario = PckrTipoUsuario.SelectedItem as TipoUsuario;
            bool R = await viewModel.AddUsuario(TxtNombre.Text.Trim(), TxtContra.Text.Trim(),
                TxtID.Text.Trim(), SelectedTipoUsuario.IdtipoUs);

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

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}