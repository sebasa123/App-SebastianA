using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace App_SebastianA.ViewModels
{
    public class GeneroViewModel : BaseViewModel
    {
        public Genero MyGen { get; set; }
        public GeneroViewModel()
        {
            MyGen = new Genero();
        }

        internal Task<bool> AddGenero(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

    }
}
