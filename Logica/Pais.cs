using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Pais
    {
        Datos.Pais objDatos = new Datos.Pais();

        public List<Modelos.Pais> MostrarPaises()
        {
            return objDatos.MostrarPaises();
        }

    }
}
