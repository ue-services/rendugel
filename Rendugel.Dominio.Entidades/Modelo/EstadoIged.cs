using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EstadoIged
    {
        public EstadoIged()
        {
            Iged = new HashSet<Iged>();
        }

        public int IdEstadoIged { get; set; }
        public int? CodEstadoIged { get; set; }
        public string DescEstadoIged { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Iged> Iged { get; set; }
    }
}
