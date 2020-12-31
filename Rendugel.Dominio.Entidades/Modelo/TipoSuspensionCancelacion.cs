using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoSuspensionCancelacion
    {
        public TipoSuspensionCancelacion()
        {
            ClasificacionDocPorTipoSusCan = new HashSet<ClasificacionDocPorTipoSusCan>();
            SuspensionCancelación = new HashSet<SuspensionCancelación>();
        }

        public int IdTipoSuspCanc { get; set; }
        public int? CodTipoSuspCanc { get; set; }
        public string DescTipoSuspCanc { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<ClasificacionDocPorTipoSusCan> ClasificacionDocPorTipoSusCan { get; set; }
        public virtual ICollection<SuspensionCancelación> SuspensionCancelación { get; set; }
    }
}
