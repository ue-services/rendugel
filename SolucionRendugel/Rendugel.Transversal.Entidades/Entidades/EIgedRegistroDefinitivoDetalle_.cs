using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EIgedRegistroDefinitivoDetalle_
    {
        public int IdIgedRegistro { get; set; }
        public bool EsOrigen { get; set; }
        public EEventoRegistral EventoRegistral { get; set; }
        public EIged Ugel { get; set; }
        public EJurisdiccion JurisdiccionIged { get; set; }
    }
}
