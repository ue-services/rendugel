using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EventoRegistral
    {
        public EventoRegistral()
        {
            EventoXTipoIged = new HashSet<EventoXTipoIged>();
            EventosDesencadenadosIdEventoColateralNavigation = new HashSet<EventosDesencadenados>();
            EventosDesencadenadosIdEventoOriginalNavigation = new HashSet<EventosDesencadenados>();
            IgedRegistroDetalle = new HashSet<IgedRegistroDetalle>();
        }

        public int IdEventoRegistral { get; set; }
        public int? CodEvento { get; set; }
        public string DescEvento { get; set; }
        public int? IdNaturaleza { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual NaturalezaEvento IdNaturalezaNavigation { get; set; }
        public virtual ICollection<EventoXTipoIged> EventoXTipoIged { get; set; }
        public virtual ICollection<EventosDesencadenados> EventosDesencadenadosIdEventoColateralNavigation { get; set; }
        public virtual ICollection<EventosDesencadenados> EventosDesencadenadosIdEventoOriginalNavigation { get; set; }
        public virtual ICollection<IgedRegistroDetalle> IgedRegistroDetalle { get; set; }
    }
}
