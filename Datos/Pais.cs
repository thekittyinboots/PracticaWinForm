using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public  class Pais
    {
        public List<Modelos.Pais> MostrarPaises()
        {
            DbEntities db = new DbEntities();
            var paises = (from pa in db.Paises
                          select pa).ToList();
            return paises;
        }
    }
}
