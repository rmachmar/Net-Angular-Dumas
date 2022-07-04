using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Dumas.DAL;

namespace WebAPI_Dumas.Business
{
    public class GatoBusiness
    {
        public string ObtenerGatos()
        {
            return JsonConvert.SerializeObject(new GatosDAL().ConsultaGatosBD());
        }

        public string ObtenerGato(int id)
        {
            return JsonConvert.SerializeObject(new GatosDAL().ConsultaGatoBD(id));
        }

        public void CrearGato(Gato gato)
        {
            new GatosDAL().CrearGatoBD(gato);
        }

        public void ActualizarGato(Gato gato)
        {
            new GatosDAL().ActualizarGatoBD(gato.Id, gato);
        }

        public void EliminarGato(int id)
        {
            new GatosDAL().EliminarGatoBD(id);
        }
    }
}