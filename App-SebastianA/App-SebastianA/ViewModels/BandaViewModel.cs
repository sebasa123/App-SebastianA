using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace App_SebastianA.ViewModels
{
    public class BandaViewModel : BaseViewModel
    {
        public Banda MyBan { get; set; }
        public Artista MyArt { get; set; }
        public BandaViewModel()
        {
            MyBan = new Banda();
            MyArt = new Artista();
        }

        public async Task<List<Artista>> GetArtista()
        {
            try
            {
                List<Artista> artistas = new List<Artista>();
                artistas = await MyArt.GetAllArtistaList();
                if (artistas == null)
                {
                    return null;
                }
                else
                {
                    return artistas;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Task<bool> AddBanda(string v1, string v2, string v3, int IDArt)
        {
            throw new NotImplementedException();
        }




    }
}
