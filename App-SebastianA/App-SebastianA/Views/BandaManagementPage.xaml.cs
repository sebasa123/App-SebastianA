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
	public partial class BandaManagementPage : ContentPage
	{
		UserViewModel viewModel;
		public BandaManagementPage()
		{
			InitializeComponent();
            LoadArtistaList();
            BindingContext = viewModel = new UserViewModel();
        }
        private async void LoadArtistaList()
        {
            PckrArt.ItemsSource = await viewModel.GetArtista();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Artista SelectedArtista = PckrArt.SelectedItem as Artista;
            bool R = await viewModel.AddBanda(TxtNombre.Text.Trim(),
                TxtDesc.Text.Trim(), SelectedArtista.Idart);

            if (R)
            {
                await DisplayAlert(": )", "Banda agregada correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}