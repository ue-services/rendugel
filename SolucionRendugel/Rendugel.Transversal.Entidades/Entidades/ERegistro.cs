using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades.Entidades
{
    public class ERegistro
    {
        public int IdRegistro { get; set; }
        public string CodRegistro { get; set; }
        public DateTime fechCreacion { get; set; }
        public DateTime fechModificacion { get; set; }
        public DateTime fechAsiento { get; set; }
        public DateTime IdTipoRegistro { get; set; }
    }
}
