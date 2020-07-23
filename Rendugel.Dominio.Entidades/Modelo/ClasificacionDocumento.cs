using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class ClasificacionDocumento
    {
        public ClasificacionDocumento()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdClasificacionDoc { get; set; }
        public int? CodClasificacionDoc { get; set; }
        public string DescClasificacionDoc { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
