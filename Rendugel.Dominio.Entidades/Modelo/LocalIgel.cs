using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class LocalIgel
    {
        public int IdLocalIged { get; set; }
        public int? IdTipoLocal { get; set; }
        public int? IdTipoPropiedad { get; set; }
        public int? IdIged { get; set; }
        public string DireccionLocal { get; set; }
        public int? IdRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdIgedNavigation { get; set; }
        public virtual TipoLocal IdTipoLocalNavigation { get; set; }
        public virtual TipoPropiedad IdTipoPropiedadNavigation { get; set; }
    }
}
