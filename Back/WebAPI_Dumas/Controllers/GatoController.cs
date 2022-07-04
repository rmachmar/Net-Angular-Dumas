using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_Dumas.Business;

namespace WebAPI_Dumas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GatoController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ObtenerGatos()
        {
            try
            {
                var listaGatos = new GatoBusiness().ObtenerGatos();
                return Request.CreateResponse(HttpStatusCode.OK, listaGatos);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage ObtenerGato(int id)
        {
            try
            {
                var gato = new GatoBusiness().ObtenerGato(id);
                return Request.CreateResponse(HttpStatusCode.OK, gato);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage CrearGato([FromBody] Gato gato)
        {
            try
            {
                new GatoBusiness().CrearGato(gato);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage ActualizarGato([FromBody] Gato gato)
        {
            try
            {
                new GatoBusiness().ActualizarGato(gato);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage EliminarGato(int id)
        {
            try
            {
                new GatoBusiness().EliminarGato(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}