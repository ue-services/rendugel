using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class SuspensionCancelación
    {
        public SuspensionCancelación()
        {
            DocumentoSuspension = new HashSet<DocumentoSuspension>();
        }

        public int IdSuspCanc { get; set; }
        public int IdRegistro { get; set; }
        public int? IdOrigenSuspCanc { get; set; }
        public DateTime? FechaSuspension { get; set; }
        public string MotivoSuspension { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual OrigenSuspencionCancelacion IdOrigenSuspCancNavigation { get; set; }
        public virtual Registro IdRegistroNavigation { get; set; }
        public virtual ICollection<DocumentoSuspension> DocumentoSuspension { get; set; }
    }
}
