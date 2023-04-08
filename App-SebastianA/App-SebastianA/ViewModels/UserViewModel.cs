using System;
using System.Collections.Generic;
using System.Text;
using App_SebastianA.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App_SebastianA.ViewModels
{
    public class UserViewModel : BaseViewModel
    { 
        public Usuario MyUsuario { get; set; }
        public UsuarioDTO MyUsuarioDTO { get; set; }
        //public RecoveryCode MyRecoveryCode { get; set; }
        //public TipoUsuario MyTipo { get; set; }
        public Models.Email MyEmail { get; set; }
        public UserViewModel()
        {
            MyUsuario = new Usuario();
            MyUsuarioDTO = new UsuarioDTO();
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
        public async Task<bool> AddUsuario(string pNombre, string pContra,int  pID, bool pEstado)
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

        //public async Task<bool> AddRecoveryCode(string pEmail)
        //{
        //    if (IsBusy) return false;
        //    IsBusy = true;
        //    try
        //    {
        //        //MyRecoveryCode.Email = pEmail;
        //        //string RecoveryCode = "ABC123";
        //        var rand = new Random();
        //        var Let = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        //        var Num = ("123456789");
        //        string randLet = "";
        //        for (int i = 0; i < 3; i++)
        //        {
        //            int o = rand.Next(26);
        //            randLet += Let[o];
        //        }
        //        string randNum = "";
        //        for (int i = 0; i < 3; i++)
        //        {
        //            int o = rand.Next(9);
        //            randNum += Num[o];
        //        }
        //        string RecoveryCode = randLet + randNum;
        //        MyRecoveryCode.RecoveryCode1 = RecoveryCode;
        //        MyRecoveryCode.RecoveryCodeId = 0;
        //        bool R = await MyRecoveryCode.AddRecoveryCode();
        //        if (R)
        //        {
        //            MyEmail.SendTo = pEmail;
        //            MyEmail.Subject = "AutoAppo password recovery code";
        //            MyEmail.Message = string.Format(
        //                "Your recovery code is: {0}", RecoveryCode);
        //            R = MyEmail.SendEmail();
        //        }
        //        return R;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public async Task<bool> RecoveryCodeValidation(string pEmail, string pRecoveryCode)
        //{
        //    if (IsBusy) return false;
        //    IsBusy = true;
        //    try
        //    {
        //        MyRecoveryCode.Email = pEmail;
        //        MyRecoveryCode.RecoveryCode1 = pRecoveryCode;
        //        bool R = await MyRecoveryCode.ValidateRecoveryCode();
        //        return R;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}


    }
}
