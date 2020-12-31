using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class UnidadEjecutora
    {
        public UnidadEjecutora()
        {
            DependeciaUnidadEjecutora = new HashSet<DependeciaUnidadEjecutora>();
            IgedBasicos = new HashSet<IgedBasicos>();
        }

        public int IdUnidadEjecutora { get; set; }
        public string CodUnidadEjecutora { get; set; }
        public string DescUnidadEjecutora { get; set; }
        public int? IdPliegoUnidadEjecutora { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual PliegoUnidadEjecutora IdPliegoUnidadEjecutoraNavigation { get; set; }
        public virtual ICollection<DependeciaUnidadEjecutora> DependeciaUnidadEjecutora { get; set; }
        public virtual ICollection<IgedBasicos> IgedBasicos { get; set; }
    }
}
