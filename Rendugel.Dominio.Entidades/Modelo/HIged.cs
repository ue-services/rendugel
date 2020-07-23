using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class HIged
    {
        public int IdIgedHist { get; set; }
        public int? IdIged { get; set; }
        public int? IdIgedRegistro { get; set; }
        public string CodIged { get; set; }
        public string NomIged { get; set; }
        public int? IdTipoIged { get; set; }
        public int? CodTipoIged { get; set; }
        public string DescTipoIged { get; set; }
        public int? IdDre { get; set; }
        public string CodDre { get; set; }
        public string NomDre { get; set; }
        public int? IdEstadoIged { get; set; }
        public int? CodEstadoIged { get; set; }
        public string DescEstadoIged { get; set; }
        public string Ubigeo { get; set; }
        public string MediosContacto { get; set; }
        public string Personal { get; set; }
        public string Locales { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Iged IdIgedNavigation { get; set; }
        public virtual IgedRegistroDetalle IdIgedRegistroNavigation { get; set; }
    }
}
