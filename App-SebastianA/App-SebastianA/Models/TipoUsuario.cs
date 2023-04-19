using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace App_SebastianA.Models
{
    public class TipoUsuario
    {
        public RestRequest Request { get; set; }
        public int IdtipoUs { get; set; }
        public string DescTipoUs { get; set; }

        public async Task<List<TipoUsuario>> GetAllTipoUsuarioList()
        {
            try
            {
                string RouteSuffix = string.Format("TipoUsuarios");
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
                    var Tiposlista = JsonConvert.DeserializeObject<List<TipoUsuario>>(response.Content);
                    return Tiposlista;
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
