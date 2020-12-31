using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EUgel
    {
        public int? IdIged { get; set; }
        public string CodIged { get; set; }
        public string NomIged { get; set; }
        public ETipoIged TipoIged { get; set; }
        public EEstadoIged EstadoIged { get; set; }
    }
}
