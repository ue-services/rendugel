using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class IgedMedioContacto
    {
        public int IdMedioContactoIged { get; set; }
        public int? IdTipoMedioContacto { get; set; }
        public int? IdIged { get; set; }
        public string Medio { get; set; }
        public string Descripcion { get; set; }
        public int? IdRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdIgedNavigation { get; set; }
        public virtual TipoMedioContacto IdTipoMedioContactoNavigation { get; set; }
    }
}
