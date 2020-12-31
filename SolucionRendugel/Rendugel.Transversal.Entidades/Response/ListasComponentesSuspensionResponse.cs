using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ListasComponentesSuspensionResponse
    {
        public IEnumerable<EOrigenSuspencionCancelacion> OrigenesSuspCanc { get; set; }
        public IEnumerable<ETipoDocumento> TiposDocumento { get; set; }
    }
}
