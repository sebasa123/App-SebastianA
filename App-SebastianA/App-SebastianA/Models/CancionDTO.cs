using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace App_SebastianA.Models
{
    public class CancionDTO
    {
        public RestRequest Request { get; set; }
        public int Idcan { get; set; }
        public int? CanXalbFk { get; set; }
        public int CanXgenFk { get; set; }
        public int CanXartFk { get; set; }
        public int? CanXbanFk { get; set; }
        public string NombreCan { get; set; }
        public int DuracionCan { get; set; }
        public bool EstadoCan { get; set; }
        public int CalificacionCan { get; set; }
        public virtual Album CanXalbFkNavigation { get; set; }
        public virtual Artista CanXartFkNavigation { get; set; }
        public virtual Banda CanXbanFkNavigation { get; set; }
        public virtual Genero CanXgenFkNavigation { get; set; }

        public async Task<CancionDTO> GetCancionData(string nombre)
        {
            try
            {
                string RouteSuffix = string.Format(
                    "Cancions/GetCancionData?NombreCan={0}", nombre);
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
                    var list = JsonConvert.DeserializeObject<List<CancionDTO>>(response.Content);
                    var item = list[0];
                    return item;
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






    }
}
