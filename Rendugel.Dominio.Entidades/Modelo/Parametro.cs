using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public int? CodParametro { get; set; }
        public string DescParamentro { get; set; }
        public string ValorString { get; set; }
        public int? ValorInt { get; set; }
        public double? ValorDecimal { get; set; }
        public DateTime? ValorFecha { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }
    }
}
