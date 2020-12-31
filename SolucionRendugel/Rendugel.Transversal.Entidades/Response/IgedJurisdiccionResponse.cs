using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class IgedJurisdiccionResponse
    {
        //public EUgel Ugel { get; set; }
        public EIged Ugel { get; set; }
        public IEnumerable<EJurisdiccion> JurisdiccionUgel { get; set; }
    }
}
