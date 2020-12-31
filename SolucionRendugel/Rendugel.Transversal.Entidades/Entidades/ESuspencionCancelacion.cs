using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ESuspencionCancelacion
    {
        public int IdSuspCanc { get; set; }
        //public int IdRegistro { get; set; }
        //public int? IdOrigenSuspCanc { get; set; }        //public int? IdTipoSuspCanc { get; set; }
        public EOrigenSuspencionCancelacion origenSuspencionCancelacion { get; set; }
        public ETipoSuspensionCancelacion tipoSuspensionCancelacion { get; set; }        
        public DateTime? FechaSuspension { get; set; }
        public string MotivoSuspension { get; set; }
    }
}
