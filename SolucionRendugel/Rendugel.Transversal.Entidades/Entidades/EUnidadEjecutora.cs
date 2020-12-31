using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EUnidadEjecutora
    {
        public int IdUnidadEjecutora { get; set; }
        public string CodUnidadEjecutora { get; set; }
        public string DescUnidadEjecutora { get; set; }
        public EPliegoUnidadEjecutora PliegoUnidadEjecutora { get; set; }
    }
}
