using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_SebastianA.ViewModels;

namespace App_SebastianA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordRecoveryPage : ContentPage
    {
        UserViewModel viewModel;
        public PasswordRecoveryPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnEnviarCodigo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                bool R = await viewModel.AddRecoveryCode(TxtEmail.Text.Trim());
                if (true)
                {
                    TxtEmail.IsEnabled = false;
                    await DisplayAlert(": )", "El codigo fue enviado", "OK");
                }
            }
        }
    }
}