using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_Dumas.Business;

namespace WebAPI_Dumas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImagenController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ObtenerImagenes()
        {
            try
            {
                var listaImagenes = new ImagenBusiness().ObtenerImagenes();
                return Request.CreateResponse(HttpStatusCode.OK, listaImagenes);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage MarcarImagenFavorito([FromBody] string id)
        {
            try
            {
                new ImagenBusiness().MarcarImagenFavorito(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage ObtenerFavoritos()
        {
            try
            {
                var listadoFavoritos = new ImagenBusiness().ObtenerFavoritos();
                return Request.CreateResponse(HttpStatusCode.OK, listadoFavoritos);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}