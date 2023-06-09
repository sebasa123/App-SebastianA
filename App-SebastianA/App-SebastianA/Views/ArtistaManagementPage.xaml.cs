﻿using System;
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
	public partial class ArtistaManagementPage : ContentPage
	{
		UserViewModel viewModel;
		public ArtistaManagementPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new UserViewModel();
		}

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddArtista(TxtNombre.Text.Trim(),
                TxtDesc.Text.Trim());

            if (R)
            {
                await DisplayAlert(": )", "Artista agregado correctamente", "OK");
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