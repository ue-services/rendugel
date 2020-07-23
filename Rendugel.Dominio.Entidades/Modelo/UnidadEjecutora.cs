using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class UnidadEjecutora
    {
        public UnidadEjecutora()
        {
            DependeciaUnidadEjecutora = new HashSet<DependeciaUnidadEjecutora>();
        }

        public int IdUnidadEjecutora { get; set; }
        public int? CodUnidadEjecutora { get; set; }
        public string DescUnidadEjecutora { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<DependeciaUnidadEjecutora> DependeciaUnidadEjecutora { get; set; }
    }
}
