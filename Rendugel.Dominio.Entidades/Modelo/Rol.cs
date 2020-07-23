using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Rol
    {
        public Rol()
        {
            Configuracion = new HashSet<Configuracion>();
        }

        public int IdRol { get; set; }
        public int? CodRol { get; set; }
        public string DescRol { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Configuracion> Configuracion { get; set; }
    }
}
