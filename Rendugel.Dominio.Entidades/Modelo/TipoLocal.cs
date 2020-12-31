using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoLocal
    {
        public TipoLocal()
        {
            LocalIged = new HashSet<LocalIged>();
        }

        public int IdTipoLocal { get; set; }
        public int? CodTipoLocal { get; set; }
        public bool? Activo { get; set; }
        public string DescTipoLocal { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<LocalIged> LocalIged { get; set; }
    }
}
