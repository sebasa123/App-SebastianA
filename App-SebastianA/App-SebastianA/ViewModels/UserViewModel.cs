using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace App_SebastianA.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public Usuario MyUsuario { get; set; }
        public UsuarioDTO MyUsuarioDTO { get; set; }
        public CodigoRecuperacion MyCodigoRec { get; set; }
        public TipoUsuario MyTipo { get; set; }
        public Models.Email MyEmail { get; set; }
        public LogMusica MyLog { get; set; }
        public Cancion MyCancion { get; set; }
        public Album MyAlbum { get; set; }
        public Genero MyGenero { get; set; }
        public Artista MyArtista { get; set; }
        public Banda MyBanda { get; set; }
        public UserViewModel()
        {
            MyUsuario = new Usuario();
            MyUsuarioDTO = new UsuarioDTO();
            MyCodigoRec = new CodigoRecuperacion();
            MyTipo = new TipoUsuario();
            MyEmail = new Models.Email();
            MyLog = new LogMusica();
            MyCancion = new Cancion();
            MyAlbum = new Album();
            MyGenero = new Genero();
            MyArtista = new Artista();
            MyBanda = new Banda();
        }
        public async Task<UsuarioDTO> GetUsuarioData(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario = await MyUsuarioDTO.GetUsuarioData(pNombre);
                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<ObservableCollection<LogMusica>> GetLogMusicaList(int pUserID)
        {

            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<LogMusica> list =
                    new ObservableCollection<LogMusica>();
                MyLog.IdusFk = pUserID;
                list = await MyLog.GetLogMusicaListByUser();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> UsuarioAccessValidation(string pNombre, string pContra)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.NombreUs = pNombre;
                MyUsuario.ContraUs = pContra;
                bool R = await MyUsuario.ValidateLogin();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<TipoUsuario>> GetTipoUsuario()
        {
            try
            {
                List<TipoUsuario> tipos = new List<TipoUsuario>();
                tipos = await MyTipo.GetAllTipoUsuarioList();
                if (tipos == null)
                {
                    return null;
                }
                else
                {
                    return tipos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Usuario>> GetUsuarioNombre(string Nombre)
        {
            try
            {
                List<Usuario> nombre = new List<Usuario>();
                nombre = await MyUsuario.GetAllUserNameList(Nombre);
                if (nombre == null)
                {
                    return null;
                }
                else
                {
                    return nombre;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddUsuario(string pNombre, string pContra)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.NombreUs = pNombre;
                MyUsuario.ContraUs = pContra;
                bool R = await MyUsuario.AddUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddCancion(string pNombreCan,
            int pDuracion, int pCalificacion, int pAlbum, 
            int pArtista, int pBanda, int pGenero)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCancion.NombreCan = pNombreCan;
                MyCancion.DuracionCan = pDuracion;
                MyCancion.CalificacionCan = pCalificacion;
                MyCancion.CanXalbFk = pAlbum;
                MyCancion.CanXartFk = pArtista;
                MyCancion.CanXbanFk = pBanda;
                MyCancion.CanXgenFk = pGenero;
                bool R = await MyCancion.AddCancion();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddAlbum(string pNombreAlb, int pDuracion,
            int pCalificacion, int pArtista, int pBanda,
            int pGenero)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyAlbum.NombreAlb = pNombreAlb;
                MyAlbum.DuracionAlb = pDuracion;
                MyAlbum.CalificacionAlb = pCalificacion;
                MyAlbum.AlbXartFk = pArtista;
                MyAlbum.AlbXbanFk = pBanda;
                MyAlbum.AlbXgenFk = pGenero;
                bool R = await MyAlbum.AddAlbum();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddArtista(string pNombre, string pDesc)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyArtista.NombreArt = pNombre;
                MyArtista.DescripcionArt = pDesc;
                bool R = await MyArtista.AddArtista();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddBanda(string pNombre,
            string pDesc, int pArtista)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyBanda.NombreBan = pNombre;
                MyBanda.DescripcionBan = pDesc;
                MyBanda.BanXartFk = pArtista;
                bool R = await MyBanda.AddBanda();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddGenero(string pNombre, 
            string pDesc)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyGenero.NombreGen = pNombre;
                MyGenero.DescripcionGen = pDesc;
                bool R = await MyGenero.AddGenero();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddLog(string pDesc, int pAlbum, 
            int pArtista, int pBanda, int pCancion, int pGenero, int pUsuario = 1, DateTime pFecha = default)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyLog.DescLog = pDesc;
                MyLog.IdalbFk = pAlbum;
                MyLog.IdartFk = pArtista;
                MyLog.IdbanFk = pBanda;
                MyLog.IdcanFk = pCancion;
                MyLog.IdgenFk = pGenero;
                MyLog.IdusFk = pUsuario;
                MyLog.FechaLog = pFecha;
                bool R = await MyLog.AddLog();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<Album>> GetAlbum()
        {
            try
            {
                List<Album> albums = new List<Album>();
                albums = await MyAlbum.GetAllAlbumList();
                if (albums == null)
                {
                    return null;
                }
                else
                {
                    return albums;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Cancion>> GetCancion()
        {
            try
            {
                List<Cancion> cancion = new List<Cancion>();
                cancion = await MyCancion.GetAllCancionList();
                if (cancion == null)
                {
                    return null;
                }
                else
                {
                    return cancion;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Artista>> GetArtista()
        {
            try
            {
                List<Artista> art = new List<Artista>();
                art = await MyArtista.GetAllArtistaList();
                if (art == null)
                {
                    return null;
                }
                else
                {
                    return art;
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
                List<Banda> banda = new List<Banda>();
                banda = await MyBanda.GetAllBandaList();
                if (banda == null)
                {
                    return null;
                }
                else
                {
                    return banda;
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
                List<Genero> gen = new List<Genero>();
                gen = await MyGenero.GetAllGeneroList();
                if (gen == null)
                {
                    return null;
                }
                else
                {
                    return gen;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        public async Task<bool> AddRecoveryCode(string pEmail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCodigoRec.CorreoElec = pEmail;
                string RecoveryCode = "ABC123";
                //var rand = new Random();
                //var Let = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                //var Num = ("123456789");
                //string randLet = "";
                //for (int i = 0; i < 3; i++)
                //{
                //    int o = rand.Next(26);
                //    randLet += Let[o];
                //}
                //string randNum = "";
                //for (int i = 0; i < 3; i++)
                //{
                //    int o = rand.Next(9);
                //    randNum += Num[o];
                //}
                //string RecoveryCode = randLet + randNum;
                MyCodigoRec.Codigo = RecoveryCode;
                MyCodigoRec.Idcod = 0;
                bool R = await MyCodigoRec.AddRecoveryCode();
                if (R)
                {
                    MyEmail.SendTo = pEmail;
                    MyEmail.Subject = "Codigo de recuperacion para la app";
                    MyEmail.Message = string.Format(
                        "El codigo es: {0}", RecoveryCode);
                    R = MyEmail.SendEmail();
                }
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> RecoveryCodeValidation(string pEmail, string pRecoveryCode)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCodigoRec.CorreoElec = pEmail;
                MyCodigoRec.Codigo = pRecoveryCode;
                bool R = await MyCodigoRec.ValidateRecoveryCode();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> UpdateUsuario(UsuarioDTO pUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyUsuario.AddUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        //public Task<bool> AddUsuario(string v1, string v2, string v3, int idtipoUs)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
