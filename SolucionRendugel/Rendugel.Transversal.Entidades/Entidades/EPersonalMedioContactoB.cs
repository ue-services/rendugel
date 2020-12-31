using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EPersonalMedioContactoB
    {
        public int IdMedioContactoPersonal { get; set; }
        public string Medio { get; set; }
        public string Descripcion { get; set; }
        public ETipoMedioContacto TipoMedioContacto { get; set; }
    }
}
