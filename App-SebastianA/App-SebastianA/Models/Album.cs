using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace App_SebastianA.Models
{
    public class Album
    {
        public RestRequest Request { get; set; }
        public Album() { }
        public int Idalb { get; set; }
        public int AlbXgenFk { get; set; }
        public int AlbXartFk { get; set; }
        public int? AlbXbanFk { get; set; }
        public string NombreAlb { get; set; }
        public int DuracionAlb { get; set; }
        public DateTime FechaAlb { get; set; }
        public bool EstadoAlb { get; set; }
        public int CalificacionAlb { get; set; }

        public virtual Artista AlbXartFkNavigation { get; set; }
        public virtual Banda AlbXbanFkNavigation { get; set; }
        public virtual Genero AlbXgenFkNavigation { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
        public async Task<bool> AddAlbum()
        {
            try
            {
                string RouteSuffix = string.Format("Album");
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

        public async Task<List<Album>> GetAllAlbumList()
        {
            try
            {
                string RouteSuffix = string.Format("Albums");
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
                    var AlbumLista = JsonConvert.DeserializeObject<List<Album>>(response.Content);
                    return AlbumLista;
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
