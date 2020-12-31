using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Personal
    {
        public Personal()
        {
            DocumentoDirector = new HashSet<DocumentoDirector>();
            PersonalMedioContacto = new HashSet<PersonalMedioContacto>();
        }

        public int IdPersonal { get; set; }
        public int? IdTipoPersonal { get; set; }
        public int? IdPersona { get; set; }
        public int? IdIged { get; set; }
        public int? IdRegistro { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdIgedNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual TipoPersonal IdTipoPersonalNavigation { get; set; }
        public virtual ICollection<DocumentoDirector> DocumentoDirector { get; set; }
        public virtual ICollection<PersonalMedioContacto> PersonalMedioContacto { get; set; }
    }
}
