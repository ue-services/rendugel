using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class ClasificacionDocPorTipoSusCan
    {
        public ClasificacionDocPorTipoSusCan()
        {
            Configuracion = new HashSet<Configuracion>();
        }

        public int IdConfigTipo { get; set; }
        public int? CodConfigTipo { get; set; }
        public int? IdTipoSuspCanc { get; set; }
        public int? IdClasificacionDoc { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ClasificacionDocumento IdClasificacionDocNavigation { get; set; }
        public virtual TipoSuspensionCancelacion IdTipoSuspCancNavigation { get; set; }
        public virtual ICollection<Configuracion> Configuracion { get; set; }
    }
}
