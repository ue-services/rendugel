using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class JurisdiccionIged
    {
        public int IdJurisdiccion { get; set; }
        public int? IdIged { get; set; }
        public int? IdTerminoPertenencia { get; set; }
        public int? IdTerminoCantidad { get; set; }
        public int? IdUbigeo { get; set; }
        public int? IdRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdIgedNavigation { get; set; }
        public virtual TerminoCantidadJurisdiccion IdTerminoCantidadNavigation { get; set; }
        public virtual TerminoPertenenciaJurisdiccion IdTerminoPertenenciaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNavigation { get; set; }
    }
}
