using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ERegistroBandeja
    {
        public int IdRegistro { get; set; }
        public string CodRegistro { get; set; }
        //public int? IdDocResolutivo { get; set; }
        public string Estado { get; set; }
        public int? CodTipoRegistro { get; set; }
        //public DateTime? FechAsiento { get; set; }
        public string UsuCreacion { get; set; }
        //public DateTime? FechaCreacion { get; set; }
        //public string UsuActualizacion { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
        public EEstadoRegistro EstadoRegistro { get; set; }
        public ETipoRegistro TipoRegistro { get; set; }
        public  EDocumento DocumentoResolutivo { get; set; }
        public IEnumerable<EIgedRegistroDetalle> ListaDetalle { get; set; } 
        public EAcciones Acciones { get; set; }

    }
}
