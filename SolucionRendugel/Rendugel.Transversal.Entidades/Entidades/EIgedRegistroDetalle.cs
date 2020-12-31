using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EIgedRegistroDetalle
    {
        public int IdIgedRegistro { get; set; }        
        public bool? EsOrigen { get; set; }
        public string NomIged { get; set; }        
        //public string UsuCreacion { get; set; }
        //public DateTime? FechaCreacion { get; set; }
        //public string UsuActualizacion { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
        public EUgel Ugel { get; set; }
        public EUbigeo Ubigeo { get; set; }
        public ERegion region { get; set; }
        public EProvincia provincia { get; set; }
        public EDistrito distrito { get; set; }
        public ETipoIged TipoIged { get; set; }
        public EIged Dre { get; set; }
        public EEventoRegistral EventoRegistral { get; set; }
}
}
