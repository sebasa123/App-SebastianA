using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App_SebastianA.Models
{
    public class CodigoRecuperacion
    {
        public RestRequest Request { get; set; }
        public int Idcod { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaCod { get; set; }
        public bool EstadoCod { get; set; }
        public string CorreoElec { get; set; }

        public async Task<bool> ValidateRecoveryCode()
        {
            try
            {
                string RouteSuffix = string.Format(
                    "CodigoRecuperacion/ValidateCode?pEmail={0}&pRecoveryCode={1}",
                    this.CorreoElec, this.Codigo);
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

        public async Task<bool> AddRecoveryCode()
        {
            try
            {
                string RouteSuffix = string.Format("CodigoRecupercions");
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
