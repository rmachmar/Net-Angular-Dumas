using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Dumas.DAL
{
    public class GatosDAL
    {
        public List<Gato> ConsultaGatosBD()
        {
            return new BDGatosEntities().Gato.ToList();
        }

        public Gato ConsultaGatoBD(int id)
        {
            return new BDGatosEntities().Gato.Find(id);
        }

        public Gato CrearGatoBD(Gato gato)
        {
            BDGatosEntities entities = new BDGatosEntities();
            entities.Gato.Add(gato);
            entities.SaveChanges();

            return gato;
        }

        public Gato ActualizarGatoBD(int id, Gato gato) 
        {
            BDGatosEntities entities = new BDGatosEntities();
            var consulta = entities.Gato.Find(id);
            consulta.Nombre = gato.Nombre;
            consulta.Raza = gato.Raza;
            consulta.Edad = gato.Edad;
            consulta.Foto = gato.Foto;
            entities.SaveChanges();

            return gato;
        }

        public void EliminarGatoBD(int id)
        {
            BDGatosEntities entities = new BDGatosEntities();
            var consulta = entities.Gato.Find(id);
            entities.Gato.Remove(consulta);
            entities.SaveChanges();
        }
    }
}