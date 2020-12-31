using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EIgedRegistroDefinitivoDetalle
    {
        public int IdIGEDRegistro { get; set; }
        public EUgelCompleta ugel { get; set; }
        public EEventoRegistral EventoRegistral { get; set; }
        public EIged Dre { get; set; }
        public string motivo { get; set; }

    }
}
