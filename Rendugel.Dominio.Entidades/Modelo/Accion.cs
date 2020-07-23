using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Accion
    {
        public Accion()
        {
            Configuracion = new HashSet<Configuracion>();
        }

        public int IdAccion { get; set; }
        public int? CodAccion { get; set; }
        public string DescAccion { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Configuracion> Configuracion { get; set; }
    }
}
