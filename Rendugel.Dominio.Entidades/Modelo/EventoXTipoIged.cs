using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EventoXTipoIged
    {
        public int IdEventoTipoIged { get; set; }
        public int? IdNaturaleza { get; set; }
        public int? IdTipoIged { get; set; }
        public int? IdTipoRegistro { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual NaturalezaEvento IdNaturalezaNavigation { get; set; }
        public virtual TipoIged IdTipoIgedNavigation { get; set; }
        public virtual TipoRegistro IdTipoRegistroNavigation { get; set; }
    }
}
