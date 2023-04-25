﻿using System;
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
    public partial class UsuarioManagementPage : ContentPage
    {
        UserViewModel vm;
        public UsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            bool R = await vm.AddUsuario(TxtNombre.Text.Trim(), TxtContrasenna.Text.Trim());
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