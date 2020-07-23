using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoRegistro
    {
        public TipoRegistro()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdTipoRegistro { get; set; }
        public int? CodTipoRegistro { get; set; }
        public string DescTipoRegistro { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
