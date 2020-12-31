using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EOpcionesJurisdiccionPertenencia
    {
        public EIged Ugel { get; set; }
        public ERegion Region { get; set; }
        public IList<EProvincia> ListaProvincias { get; set; }
        public IList<EDistrito> ListaDistritos { get; set; }
        public IList<ECentroPoblado> ListaCentroPoblado { get; set; }
    }
}
