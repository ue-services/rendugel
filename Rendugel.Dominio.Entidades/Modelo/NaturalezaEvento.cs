using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class NaturalezaEvento
    {
        public NaturalezaEvento()
        {
            EventoRegistral = new HashSet<EventoRegistral>();
        }

        public int IdNaturaleza { get; set; }
        public int? CodNaturaleza { get; set; }
        public string DescNaturaleza { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<EventoRegistral> EventoRegistral { get; set; }
    }
}
