using System.ComponentModel;
using App_SebastianA.ViewModels;
using Xamarin.Forms;

namespace App_SebastianA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}