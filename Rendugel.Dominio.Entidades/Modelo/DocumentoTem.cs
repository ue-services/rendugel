using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class DocumentoTem
    {
        public int IdDocumentoTem { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public string Finalidad { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }
    }
}
