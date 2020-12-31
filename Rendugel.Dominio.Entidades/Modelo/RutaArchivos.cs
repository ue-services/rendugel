using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class RutaArchivos
    {
        public int IdRuta { get; set; }
        public int? CodRuta { get; set; }
        public string Ruta { get; set; }
        public string DescRuta { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }
    }
}
