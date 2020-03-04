using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Persona
    {
        Datos.Persona objDatos = new Datos.Persona();

        public List<Modelos.PersonaDgv> MostrarTodos()
        {
            return objDatos.MostrarTodos();
        }

        public void Agregar(Modelos.Persona pPersona)
        {
            objDatos.Agregar(pPersona);
        }

        public void Modificar(int pId, Modelos.Persona pPersona)
        {
            objDatos.Modificar(pId, pPersona);

        }

        public void Eliminar(int pId)
        {
            objDatos.Eliminar(pId);
        }

        public Modelos.Persona MostrarUno(int pInt)
        {
            return objDatos.MostrarUno(pInt);
        }
    }
}
