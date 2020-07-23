using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class OrigenSuspencionCancelacion
    {
        public OrigenSuspencionCancelacion()
        {
            SuspensionCancelación = new HashSet<SuspensionCancelación>();
        }

        public int IdOrigenSuspCanc { get; set; }
        public int? CodTipoSuspCanc { get; set; }
        public int? IdTipoSuspension { get; set; }
        public string DescTipoSuspCanc { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual TipoSuspension IdTipoSuspensionNavigation { get; set; }
        public virtual ICollection<SuspensionCancelación> SuspensionCancelación { get; set; }
    }
}
