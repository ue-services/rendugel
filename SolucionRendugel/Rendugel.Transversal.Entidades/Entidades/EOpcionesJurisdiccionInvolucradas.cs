using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EOpcionesJurisdiccionInvolucradas
    {
        public IList<EIged> ListaUgel { get; set; }
        public IList<ENaturaleza> ListaNaturalezaC { get; set; }
        public IList<EEventoRegistral> ListaEventoRegistralC { get; set; }
    }
}
