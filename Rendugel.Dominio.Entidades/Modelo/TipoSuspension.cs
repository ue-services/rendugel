using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoSuspension
    {
        public TipoSuspension()
        {
            OrigenSuspencionCancelacion = new HashSet<OrigenSuspencionCancelacion>();
        }

        public int IdTipoSuspension { get; set; }
        public int? CodTipoSuspension { get; set; }
        public string DescTipoSuspension { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<OrigenSuspencionCancelacion> OrigenSuspencionCancelacion { get; set; }
    }
}
