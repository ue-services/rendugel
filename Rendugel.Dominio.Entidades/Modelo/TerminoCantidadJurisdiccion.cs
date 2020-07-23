using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TerminoCantidadJurisdiccion
    {
        public TerminoCantidadJurisdiccion()
        {
            JurisdiccionIged = new HashSet<JurisdiccionIged>();
        }

        public int IdTerminoCantidad { get; set; }
        public int? CodTerminoCantidad { get; set; }
        public string DescTerminoCantidad { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<JurisdiccionIged> JurisdiccionIged { get; set; }
    }
}
