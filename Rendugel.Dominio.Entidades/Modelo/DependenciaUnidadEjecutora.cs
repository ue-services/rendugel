using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class DependenciaUnidadEjecutora
    {
        public int IdIgedEjecutora { get; set; }
        public int? IdIged { get; set; }
        public int? IdUnidadEjecutora { get; set; }
        public bool? Autonoma { get; set; }
        public int? IdIgedRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }
    }
}
