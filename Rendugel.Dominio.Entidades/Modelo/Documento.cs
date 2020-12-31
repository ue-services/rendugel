using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Documento
    {
        public Documento()
        {
            DocumentoDirector = new HashSet<DocumentoDirector>();
            DocumentoRegistro = new HashSet<DocumentoRegistro>();
            DocumentoSuspension = new HashSet<DocumentoSuspension>();
        }

        public int IdDocumento { get; set; }
        public int? IdClasificacionDoc { get; set; }
        public int? IdTipoDoc { get; set; }
        public string NroDocumento { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? Temporal { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ClasificacionDocumento IdClasificacionDocNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocNavigation { get; set; }
        public virtual ICollection<DocumentoDirector> DocumentoDirector { get; set; }
        public virtual ICollection<DocumentoRegistro> DocumentoRegistro { get; set; }
        public virtual ICollection<DocumentoSuspension> DocumentoSuspension { get; set; }
    }
}
