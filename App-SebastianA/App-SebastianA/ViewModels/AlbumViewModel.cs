using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace App_SebastianA.ViewModels
{
    public class AlbumViewModel : BaseViewModel
    {
        public Album MyAlb { get; set; }
        public Artista MyArt { get; set; }
        public Banda MyBan { get; set; }
        public Genero MyGen { get; set; }
        public AlbumViewModel()
        {
            MyAlb = new Album();
            MyArt = new Artista();
            MyBan = new Banda();
            MyGen = new Genero();
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
        public async Task<List<Banda>> GetBanda()
        {
            try
            {
                List<Banda> bandas = new List<Banda>();
                bandas = await MyBan.GetAllBandaList();
                if (bandas == null)
                {
                    return null;
                }
                else
                {
                    return bandas;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Genero>> GetGenero()
        {
            try
            {
                List<Genero> generos = new List<Genero>();
                generos = await MyGen.GetAllGeneroList();
                if (generos == null)
                {
                    return null;
                }
                else
                {
                    return generos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Task<bool> AddAlbum(string v1, string v2, string v3, string v4, int IDArt, int IDBan, int IDGen)
        {
            throw new NotImplementedException();
        }






    }
}
