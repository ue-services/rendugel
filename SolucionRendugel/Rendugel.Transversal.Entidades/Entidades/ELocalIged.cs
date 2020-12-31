using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ELocalIged
    {
        public int IdLocalIged { get; set; }
        public string DireccionLocal { get; set; }
        //public int? IdIgedRegistro { get; set; }
        public EIged Iged { get; set; }
        public ETipoLocal TipoLocal { get; set; }
        public ETipoPropiedad TipoPropiedad { get; set; }
    }
}
