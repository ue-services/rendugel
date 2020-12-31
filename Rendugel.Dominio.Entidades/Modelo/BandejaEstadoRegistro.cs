using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class BandejaEstadoRegistro
    {
        public int IdBandejaRegistro { get; set; }
        public int? CodBandejaRegistro { get; set; }
        public int? IdBandeja { get; set; }
        public int? IdEstadoRegistro { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Bandeja IdBandejaNavigation { get; set; }
        public virtual EstadoRegistro IdEstadoRegistroNavigation { get; set; }
    }
}
