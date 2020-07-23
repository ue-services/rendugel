using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoUbigeo
    {
        public TipoUbigeo()
        {
            Ubigeo = new HashSet<Ubigeo>();
        }

        public int IdTipoUbigeo { get; set; }
        public int? CodTipoUbigeo { get; set; }
        public string DescTipoUbigeo { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Ubigeo> Ubigeo { get; set; }
    }
}
