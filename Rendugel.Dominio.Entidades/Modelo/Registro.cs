using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Registro
    {
        public Registro()
        {
            DocumentoRegistro = new HashSet<DocumentoRegistro>();
            DocumentoSuspension = new HashSet<DocumentoSuspension>();
            IgedRegistroDetalle = new HashSet<IgedRegistroDetalle>();
            SuspensionCancelación = new HashSet<SuspensionCancelación>();
        }

        public int IdRegistro { get; set; }
        public string CodRegistro { get; set; }
        public DateTime? FechCreacion { get; set; }
        public DateTime? FechModificacion { get; set; }
        public DateTime? FechAsiento { get; set; }
        public int? IdTipoRegistro { get; set; }
        public int? IdEstadoRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual EstadoRegistro IdEstadoRegistroNavigation { get; set; }
        public virtual TipoRegistro IdTipoRegistroNavigation { get; set; }
        public virtual ICollection<DocumentoRegistro> DocumentoRegistro { get; set; }
        public virtual ICollection<DocumentoSuspension> DocumentoSuspension { get; set; }
        public virtual ICollection<IgedRegistroDetalle> IgedRegistroDetalle { get; set; }
        public virtual ICollection<SuspensionCancelación> SuspensionCancelación { get; set; }
    }
}
