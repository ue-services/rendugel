using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TerminoPertenenciaJurisdiccion
    {
        public TerminoPertenenciaJurisdiccion()
        {
            JurisdiccionIged = new HashSet<JurisdiccionIged>();
        }

        public int IdTerminoPertenencia { get; set; }
        public int? CodTerminoPertenencia { get; set; }
        public string DescTerminoPertenencia { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<JurisdiccionIged> JurisdiccionIged { get; set; }
    }
}
