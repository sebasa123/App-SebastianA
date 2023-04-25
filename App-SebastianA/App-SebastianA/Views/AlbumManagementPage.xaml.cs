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
        UserViewModel vm;
		public AlbumManagementPage()
		{
			InitializeComponent();
            LoadArtistaList();
            LoadBandaList();
            LoadGeneroList();
            BindingContext = vm = new UserViewModel();
        }

        private async void LoadArtistaList()
        {
            PckrArt.ItemsSource = await vm.GetArtista();
        }
        private async void LoadBandaList()
        {
            PckrBan.ItemsSource = await vm.GetBanda();
        }
        private async void LoadGeneroList()
        {
            PckrGen.ItemsSource = await vm.GetGenero();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Artista SelectedArtista = PckrArt.SelectedItem as Artista;
            Banda SelectedBanda = PckrBan.SelectedItem as Banda;
            Genero SelectedGenero = PckrGen.SelectedItem as Genero;
            int Duracion = int.Parse(TxtDuracion.Text.Trim());
            int Calificacion = int.Parse(TxtCalificacion.Text.Trim());
            bool R = await vm.AddAlbum(TxtNombre.Text.Trim(),
                Duracion, Calificacion, SelectedArtista.Idart, 
                SelectedBanda.Idban, SelectedGenero.Idgen);
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

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}