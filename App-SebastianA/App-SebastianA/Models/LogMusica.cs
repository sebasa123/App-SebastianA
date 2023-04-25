using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace App_SebastianA.Models
{
    public class LogMusica
    {
        public RestRequest Request { get; set; }
        public int Idlog { get; set; }
        public string DescLog { get; set; }
        public DateTime FechaLog { get; set; }
        public int IdalbFk { get; set; }
        public int IdartFk { get; set; }
        public int IdbanFk { get; set; }
        public int IdcanFk { get; set; }
        public int IdgenFk { get; set; }
        public int IdusFk { get; set; }

        public virtual Album IdalbFkNavigation { get; set; }
        public virtual Artista IdartFkNavigation { get; set; }
        public virtual Banda IdbanFkNavigation { get; set; }
        public virtual Cancion IdcanFkNavigation { get; set; }
        public virtual Genero IdgenFkNavigation { get; set; }
        public virtual Usuario IdusFkNavigation { get; set; }

        public async Task<ObservableCollection<LogMusica>> GetLogMusicaListByUser()
        {
            try
            {
                string RouteSuffix = string.Format(
                    "LogMusicas/GetLogMusicaListByUser?pUserID={0}", this.IdusFk);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var LogLista = JsonConvert.DeserializeObject<ObservableCollection<LogMusica>>(response.Content);
                    return LogLista;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                throw;
            }
        }

        public async Task<bool> AddLog()
        {
            try
            {
                string RouteSuffix = string.Format("LogMusicas");
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }






    }
}
