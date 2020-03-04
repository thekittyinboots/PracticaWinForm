using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   public  class PersonaDgv
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public int Id_Pais { get; set; }
        public decimal Credito_Maximo { get; set; }

        public string Descripcion { get; set; }
    }
}
