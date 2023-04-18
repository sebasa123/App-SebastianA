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
    public partial class MyLogListPage : ContentPage
    {
        UserViewModel vm;
        public MyLogListPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadLogs(GlobalObjects.LocalUsuario.Idus);
        }

        private async void LoadLogs(int pUserID)
        {
            LstLogMusLista.ItemsSource = await vm.GetLogMusicaList(pUserID);
        }
    }
}