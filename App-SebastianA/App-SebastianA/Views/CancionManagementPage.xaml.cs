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
	public partial class CancionManagementPage : ContentPage
	{
		CancionViewModel viewModel;
		public CancionManagementPage ()
		{
			InitializeComponent ();
            LoadAlbumList();
            LoadArtistaList();
            LoadBandaList();
            LoadGeneroList();
            BindingContext = viewModel = new CancionViewModel();
        }

        private async void LoadAlbumList()
        {
            PckrAlb.ItemsSource = await viewModel.GetAlbum();
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
            Album SelectedAlbum = PckrAlb.SelectedItem as Album;
            Artista SelectedArtista = PckrArt.SelectedItem as Artista;
            Banda SelectedBanda = PckrBan.SelectedItem as Banda;
            Genero SelectedGenero = PckrGen.SelectedItem as Genero;
            bool R = await viewModel.AddCancion(TxtID.Text.Trim(), TxtNombre.Text.Trim(),
                TxtDuracion.Text.Trim(), TxtCalificacion.Text.Trim(), SelectedAlbum.Idalb,
                SelectedArtista.Idart, SelectedBanda.Idban, SelectedGenero.Idgen);

            if (R)
            {
                await DisplayAlert(": )", "Cancion agregada correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }
    }
}