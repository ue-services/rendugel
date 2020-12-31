using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Iged
    {
        public Iged()
        {
            DependeciaUnidadEjecutora = new HashSet<DependeciaUnidadEjecutora>();
            HIged = new HashSet<HIged>();
            IgedBasicosIdDreNavigation = new HashSet<IgedBasicos>();
            IgedBasicosIdIgedNavigation = new HashSet<IgedBasicos>();
            IgedMedioContacto = new HashSet<IgedMedioContacto>();
            IgedRegistroDetalle = new HashSet<IgedRegistroDetalle>();
            JurisdiccionIged = new HashSet<JurisdiccionIged>();
            LocalIged = new HashSet<LocalIged>();
            Personal = new HashSet<Personal>();
        }

        public int IdIged { get; set; }
        public string CodIged { get; set; }
        public int? IdTipoIged { get; set; }
        public int? IdEstadoIged { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual EstadoIged IdEstadoIgedNavigation { get; set; }
        public virtual TipoIged IdTipoIgedNavigation { get; set; }
        public virtual ICollection<DependeciaUnidadEjecutora> DependeciaUnidadEjecutora { get; set; }
        public virtual ICollection<HIged> HIged { get; set; }
        public virtual ICollection<IgedBasicos> IgedBasicosIdDreNavigation { get; set; }
        public virtual ICollection<IgedBasicos> IgedBasicosIdIgedNavigation { get; set; }
        public virtual ICollection<IgedMedioContacto> IgedMedioContacto { get; set; }
        public virtual ICollection<IgedRegistroDetalle> IgedRegistroDetalle { get; set; }
        public virtual ICollection<JurisdiccionIged> JurisdiccionIged { get; set; }
        public virtual ICollection<LocalIged> LocalIged { get; set; }
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
