using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class DocumentoRegistro
    {
        public int IdDocumentoRegistro { get; set; }
        public int? IdRegistro { get; set; }
        public int? IdDocumento { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? EsActivo { get; set; }
        public int? EsBorrado { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual Registro IdRegistroNavigation { get; set; }
    }
}
