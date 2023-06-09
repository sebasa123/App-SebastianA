﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace App_SebastianA.Models
{
    public class Banda
    {
        public RestRequest Request { get; set; }
        public Banda() { }
        public int Idban { get; set; }
        public int BanXartFk { get; set; }
        public string NombreBan { get; set; }
        public string DescripcionBan { get; set; }
        public bool EstadoBan { get; set; }

        public virtual Artista BanXartFkNavigation { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }

        public async Task<bool> AddBanda()
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

        public async Task<List<Banda>> GetAllBandaList()
        {
            try
            {
                string RouteSuffix = string.Format("Bandas");
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
                    var BandaLista = JsonConvert.DeserializeObject<List<Banda>>(response.Content);
                    return BandaLista;
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
