using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EventoXTipoIged
    {
        public int IdEventoTipoIged { get; set; }
        public int? IdEventoRegistral { get; set; }
        public int? IdTipoIged { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual EventoRegistral IdEventoRegistralNavigation { get; set; }
        public virtual TipoIged IdTipoIgedNavigation { get; set; }
    }
}
