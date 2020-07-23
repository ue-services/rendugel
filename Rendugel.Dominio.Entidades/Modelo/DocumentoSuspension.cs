using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class DocumentoSuspension
    {
        public int IdDocumentoSuspension { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdSuspCanc { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual SuspensionCancelación IdSuspCancNavigation { get; set; }
    }
}
