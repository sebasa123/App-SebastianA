using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_SebastianA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
        }
        private async void BtnCancionManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CancionManagementPage());
        }
        private async void BtnAlbumesManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlbumManagementPage());
        }
        private async void BtnArtistasManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtistaManagementPage());
        }
        private async void BtnBandasManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BandaManagementPage());
        }
        private async void BtnGeneroManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeneroManagementPage());
        }
        private async void BtnLogMusicaManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogManagementPage());
        }
        private async void BtnVerLogsManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyLogListPage());
        }

        private async void BtnUsuarioManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioManagementPage());
        }

    }
}