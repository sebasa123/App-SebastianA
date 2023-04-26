using System;
using App_SebastianA.Services;
using App_SebastianA.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_SebastianA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppLoginPage());
            //MainPage = new NavigationPage(new OptionsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
