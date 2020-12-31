using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EOpcionesUbigeo
    {
        public ERegion Region { get; set; }
        public IList<EProvincia> ListaProvincias { get; set; }
        public IList<EDistrito> ListaDistritos { get; set; }
    }
}
