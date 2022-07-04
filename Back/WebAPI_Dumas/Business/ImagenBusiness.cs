using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Dumas.Utils;

namespace WebAPI_Dumas.Business
{
    public class ImagenBusiness
    {
        public string ObtenerImagenes()
        {
            return new LlamadaAPIGatos().EjecutarLlamadaGET("images/search?limit=10");
        }

        public string MarcarImagenFavorito(string idImagen)
        {
            return new LlamadaAPIGatos().EjecutarLlamadaPOST("favourites", new { image_id = idImagen });
        }

        public string ObtenerFavoritos()
        {
            return new LlamadaAPIGatos().EjecutarLlamadaGET("favourites");
        }
    }
}