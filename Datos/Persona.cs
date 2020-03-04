using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Persona
    {
        public List<Modelos.PersonaDgv> MostrarTodos()
        {
            DbEntities db = new DbEntities();
            //var lista = (from p in db.Personas.Include("Pais")
            //             select p).ToList();
            List<Modelos.PersonaDgv> lista = (from p in db.Personas
                                              join pa in db.Paises
                                              on p.Id_Pais equals pa.Id
                                              select new PersonaDgv
                                              {
                                                  Id = p.Id,
                                                  Nombre = p.Nombre,
                                                  Fecha_Nacimiento = p.Fecha_Nacimiento,
                                                  Id_Pais = p.Id_Pais,
                                                  Credito_Maximo = p.Credito_Maximo,
                                                  Descripcion = pa.Descripcion
                                              }).ToList();

            return lista;
        }

        public void Agregar(Modelos.Persona pPersona)
        {
            DbEntities db = new DbEntities();
            db.Personas.Add(pPersona);
            db.SaveChanges();

        }

        public void Modificar(int pId, Modelos.Persona pPersona)
        {
            DbEntities db = new DbEntities();
            var pers = db.Personas.Find(pId);
            pers.Nombre = pPersona.Nombre;
            pers.Fecha_Nacimiento = pPersona.Fecha_Nacimiento;
            pers.Id_Pais = pPersona.Id_Pais;
            pers.Credito_Maximo = pPersona.Credito_Maximo;
            db.SaveChanges();
        }

        public void Eliminar(int pId)
        {
            DbEntities db = new DbEntities();
            var pers = db.Personas.Find(pId);
            db.Personas.Remove(pers);
            db.SaveChanges();
        }

        public Modelos.Persona MostrarUno(int pId)
        {
            DbEntities db = new DbEntities();
            var pers = db.Personas.Find(pId);
            return pers;
        }


    }
}
