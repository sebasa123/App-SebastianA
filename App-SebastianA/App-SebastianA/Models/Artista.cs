using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace App_SebastianA.Models
{
    public class Artista
    {
        public RestRequest Request { get; set; }
        public Artista() { }
        public int Idart { get; set; }
        public string NombreArt { get; set; }
        public string DescripcionArt { get; set; }
        public bool EstadoArt { get; set; }
        public bool TipoArt { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Banda> Banda { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
        public async Task<bool> AddAlbum()
        {
            try
            {
                string RouteSuffix = string.Format("Banda");
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
