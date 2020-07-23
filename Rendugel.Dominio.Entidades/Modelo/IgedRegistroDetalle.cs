using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class IgedRegistroDetalle
    {
        public IgedRegistroDetalle()
        {
            HIged = new HashSet<HIged>();
        }

        public int IdIgedRegistro { get; set; }
        public int? IdRegistro { get; set; }
        public int? IdIged { get; set; }
        public int? IdEventoRegistral { get; set; }
        public bool? EsOrigen { get; set; }
        public string NomIged { get; set; }
        public int? IdUbigeoIged { get; set; }
        public int? IdTipoIged { get; set; }
        public int? IdDre { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual EventoRegistral IdEventoRegistralNavigation { get; set; }
        public virtual Iged IdIgedNavigation { get; set; }
        public virtual Registro IdRegistroNavigation { get; set; }
        public virtual ICollection<HIged> HIged { get; set; }
    }
}
