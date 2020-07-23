using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class RutaArchivos
    {
        public RutaArchivos()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdRuta { get; set; }
        public int? CodRuta { get; set; }
        public string Ruta { get; set; }
        public string DescRuta { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
