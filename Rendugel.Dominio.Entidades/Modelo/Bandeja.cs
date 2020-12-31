using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Bandeja
    {
        public Bandeja()
        {
            BandejaEstadoRegistro = new HashSet<BandejaEstadoRegistro>();
        }

        public int IdBandeja { get; set; }
        public int? CodBandeja { get; set; }
        public string Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<BandejaEstadoRegistro> BandejaEstadoRegistro { get; set; }
    }
}
