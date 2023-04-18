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
        public UserViewModel()
        {
            MyUsuario = new Usuario();
            MyUsuarioDTO = new UsuarioDTO();
            MyCodigoRec = new CodigoRecuperacion();
            MyTipo = new TipoUsuario();
            MyEmail = new Models.Email();
            MyLog = new LogMusica();
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

        public async Task<bool> AddUsuario(string pNombre, string pContra, int pID, bool pEstado)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.NombreUs = pNombre;
                MyUsuario.ContraUs = pContra;
                MyUsuario.Idus = pID;
                MyUsuario.EstadoUs = pEstado;
                bool R = await MyUsuario.AddUser();
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

        internal Task<bool> AddUsuario(string v1, string v2, string v3, int idtipoUs)
        {
            throw new NotImplementedException();
        }
    }
}
