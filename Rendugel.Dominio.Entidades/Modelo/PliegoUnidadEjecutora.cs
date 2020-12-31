using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class PliegoUnidadEjecutora
    {
        public PliegoUnidadEjecutora()
        {
            UnidadEjecutora = new HashSet<UnidadEjecutora>();
        }

        public int IdPliegoUnidadEjecutora { get; set; }
        public string CodPliegoUnidadEjecutora { get; set; }
        public string DescPliegoUnidadEjecutora { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<UnidadEjecutora> UnidadEjecutora { get; set; }
    }
}
