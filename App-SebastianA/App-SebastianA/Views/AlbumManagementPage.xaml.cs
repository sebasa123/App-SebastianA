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
	public partial class AlbumManagementPage : ContentPage
	{
		AlbumViewModel viewModel;
		public AlbumManagementPage()
		{
			InitializeComponent();
            LoadArtistaList();
            LoadBandaList();
            LoadGeneroList();
            BindingContext = viewModel = new AlbumViewModel();
        }

        private async void LoadArtistaList()
        {
            PckrArt.ItemsSource = await viewModel.GetArtista();
        }
        private async void LoadBandaList()
        {
            PckrBan.ItemsSource = await viewModel.GetBanda();
        }
        private async void LoadGeneroList()
        {
            PckrGen.ItemsSource = await viewModel.GetGenero();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Artista SelectedArtista = PckrArt.SelectedItem as Artista;
            Banda SelectedBanda = PckrBan.SelectedItem as Banda;
            Genero SelectedGenero = PckrGen.SelectedItem as Genero;
            bool R = await viewModel.AddAlbum(TxtID.Text.Trim(), TxtNombre.Text.Trim(),
                TxtDuracion.Text.Trim(), TxtCalificacion.Text.Trim(),
                SelectedArtista.Idart, SelectedBanda.Idban, SelectedGenero.Idgen);
            if (R)
            {
                await DisplayAlert(": )", "Album agregado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }
    }
}