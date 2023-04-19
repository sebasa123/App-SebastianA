using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace App_SebastianA.ViewModels
{
    public class ArtistaViewModel : BaseViewModel
    {
        public Artista MyArt { get; set; }
        public ArtistaViewModel()
        {
            MyArt = new Artista();
        }

        internal Task<bool> AddArtista(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
