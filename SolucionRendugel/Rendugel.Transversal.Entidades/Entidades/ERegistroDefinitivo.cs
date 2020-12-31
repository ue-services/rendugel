using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ERegistroDefinitivo
    {
        public int IdRegistro { get; set; }

        public EIgedRegistroDefinitivoDetalle RegistroDetallePrincipal { get; set; }
        public ICollection<EIgedRegistroDefinitivoDetalle>  RegistroDetalleDerivados { get; set; }
        public EDocumento DocumentoResolutivo { get; set; }
        //public ICollection<EDocumento> DocumentosAdicionales { get; set; }
        public EEstadoRegistro EstadoRegistro { get; set; }
        public ETipoRegistro TipoRegistro { get; set; }
        public string usuario { get; set; }
        public DateTime fecha { get; set; }
        //public DateTime FechaCreacion { get; set; }
        //public DateTime FechaAsiento { get; set; }

    }
}
