using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoPersonal
    {
        public TipoPersonal()
        {
            Personal = new HashSet<Personal>();
        }

        public int IdTipoPersonal { get; set; }
        public int? CodTipoPersonal { get; set; }
        public string DescTipoPersonal { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Personal> Personal { get; set; }
    }
}
