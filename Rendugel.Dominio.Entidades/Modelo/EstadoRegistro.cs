using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EstadoRegistro
    {
        public EstadoRegistro()
        {
            Configuracion = new HashSet<Configuracion>();
            Registro = new HashSet<Registro>();
        }

        public int IdEstadoRegistro { get; set; }
        public int? CodEstadoRegistro { get; set; }
        public string DescEstadoRegistro { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Configuracion> Configuracion { get; set; }
        public virtual ICollection<Registro> Registro { get; set; }
    }
}
