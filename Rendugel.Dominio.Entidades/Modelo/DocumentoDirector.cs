using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class DocumentoDirector
    {
        public int IdDocumentoDirector { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdPersonal { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual Personal IdPersonalNavigation { get; set; }
    }
}
