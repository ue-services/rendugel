using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoIged
    {
        public TipoIged()
        {
            EventoXTipoIged = new HashSet<EventoXTipoIged>();
            Iged = new HashSet<Iged>();
        }

        public int IdTipoIged { get; set; }
        public int? CodTipoIged { get; set; }
        public string DescTipoIged { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<EventoXTipoIged> EventoXTipoIged { get; set; }
        public virtual ICollection<Iged> Iged { get; set; }
    }
}
