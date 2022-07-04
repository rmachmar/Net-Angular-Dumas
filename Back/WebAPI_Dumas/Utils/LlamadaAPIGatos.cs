using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebAPI_Dumas.Utils
{
    public class LlamadaAPIGatos
    {
        private const string apikey = "3bc5df58-5435-4ba2-89cc-66450fcb5177";
        private const string urlBase = "https://api.thecatapi.com/v1/";


        public string EjecutarLlamadaGET(string url)
        {
            try
            {
                string resultado = string.Empty;
                var request = (HttpWebRequest)WebRequest.Create(urlBase + url);
                request.Headers.Add("x-api-key", apikey);

                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    resultado = reader.ReadToEnd();
                }

                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string EjecutarLlamadaPOST(string url, object obj)
        {
            try
            {
                string resultado = string.Empty;
                var request = (HttpWebRequest)WebRequest.Create(urlBase + url);
                request.Headers.Add("x-api-key", apikey);
                request.Method = "POST";
                request.ContentType = "application/json";

                string jsonOrder = JsonConvert.SerializeObject(obj);
                var data = Encoding.UTF8.GetBytes(jsonOrder);
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }



                WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    resultado = reader.ReadToEnd();
                }

                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}