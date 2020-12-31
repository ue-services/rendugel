using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EParametrosRegistroRequest
    {
        public ETipoIged tipoIged { get; set; }
        public EIged dre { get; set; }
        public EIged ugel { get; set; }
        public EEventoRegistral eventoRegistral { get; set; }
        public ETipoRegistro tipoRegistro { get; set; }
    }
}
