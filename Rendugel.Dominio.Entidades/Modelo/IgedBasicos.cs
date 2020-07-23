using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class IgedBasicos
    {
        public int IdIgedBasicos { get; set; }
        public int? IdIged { get; set; }
        public string NomIged { get; set; }
        public int? IdUbigeo { get; set; }
        public int? IdDre { get; set; }
        public bool? EsUeAutonoma { get; set; }
        public int? IdIgedRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdDreNavigation { get; set; }
        public virtual Iged IdIgedNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNavigation { get; set; }
    }
}
