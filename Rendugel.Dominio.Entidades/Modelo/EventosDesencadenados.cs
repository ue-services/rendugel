using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class EventosDesencadenados
    {
        public int IdEventoDesencadenado { get; set; }
        public int? IdEventoOriginal { get; set; }
        public int? IdEventoColateral { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual EventoRegistral IdEventoColateralNavigation { get; set; }
        public virtual EventoRegistral IdEventoOriginalNavigation { get; set; }
    }
}
