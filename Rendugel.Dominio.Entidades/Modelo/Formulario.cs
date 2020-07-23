using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Formulario
    {
        public Formulario()
        {
            Configuracion = new HashSet<Configuracion>();
        }

        public int IdFormulario { get; set; }
        public int? CodFormulario { get; set; }
        public string DescFormulario { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Configuracion> Configuracion { get; set; }
    }
}
