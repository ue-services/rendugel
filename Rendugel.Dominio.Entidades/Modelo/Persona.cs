using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Persona
    {
        public Persona()
        {
            Personal = new HashSet<Personal>();
        }

        public int IdPersona { get; set; }
        public string NomPersona { get; set; }
        public string AppPersona { get; set; }
        public string ApmPersona { get; set; }
        public string DniPersona { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Personal> Personal { get; set; }
    }
}
