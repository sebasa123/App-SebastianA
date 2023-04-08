using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace App_SebastianA.Models
{
    public class Cancion
    {
        public RestRequest Request { get; set; }
        public Cancion() { }
        public int Idcan { get; set; }
        public int? CanXalbFk { get; set; }
        public int CanXgenFk { get; set; }
        public int CanXartFk { get; set; }
        public int? CanXbanFk { get; set; }
        public string NombreCan { get; set; }
        public int DuracionCan { get; set; }
        public bool EstadoCan { get; set; }
        public int CalificacionCan { get; set; }
        //public virtual Album CanXalbFkNavigation { get; set; }
        //public virtual Artista CanXartFkNavigation { get; set; }
        //public virtual Banda CanXbanFkNavigation { get; set; }
        public virtual Genero CanXgenFkNavigation { get; set; }

        public async Task<bool> AddCancion()
        {
            try
            {
                string RouteSuffix = string.Format("Cancion");
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
