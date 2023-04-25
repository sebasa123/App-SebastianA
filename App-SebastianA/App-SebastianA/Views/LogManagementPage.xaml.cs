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
	public partial class LogManagementPage : ContentPage
	{
        UserViewModel viewModel;
        public LogManagementPage()
		{
            InitializeComponent();
            LoadCancionList();
            LoadAlbumList();
            LoadArtistaList();
            LoadBandaList();
            LoadGeneroList();
            BindingContext = viewModel = new UserViewModel();
		}

        private async void LoadCancionList()
        {
            PckrCan.ItemsSource = await viewModel.GetCancion();
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

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Cancion SelectedCancion = PckrCan.SelectedItem as Cancion;
            Album SelectedAlbum = PckrAlb.SelectedItem as Album;
            Artista SelectedArtista = PckrArt.SelectedItem as Artista;
            Banda SelectedBanda = PckrBan.SelectedItem as Banda;
            Genero SelectedGenero = PckrGen.SelectedItem as Genero;
            bool R = await viewModel.AddLog(TxtDesc.Text.Trim(),
                SelectedCancion.Idcan, SelectedAlbum.Idalb,
                SelectedArtista.Idart, SelectedBanda.Idban, SelectedGenero.Idgen);

            if (R)
            {
                await DisplayAlert(": )", "Log agregado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }
    }
}