using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdTipoDoc { get; set; }
        public int? CodTipoDoc { get; set; }
        public string DescTipoDoc { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
