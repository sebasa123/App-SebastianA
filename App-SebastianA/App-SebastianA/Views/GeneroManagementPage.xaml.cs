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
	public partial class GeneroManagementPage : ContentPage
	{
		GeneroViewModel viewModel;
		public GeneroManagementPage()
		{
			InitializeComponent();
		}

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
			bool R = await viewModel.AddGenero(TxtID.Text.Trim(),
				TxtNombre.Text.Trim(), TxtDesc.Text.Trim());
			if (R)
			{
                await DisplayAlert(": )", "Genero agregado correctamente", "OK");
                await Navigation.PopAsync();
            }
			else
			{
                await DisplayAlert(": /", "Algo salio mal", "OK");
            }
        }
    }
}