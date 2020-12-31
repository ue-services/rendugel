using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EIgedMedioContacto
    {
        public int IdMedioContactoIged { get; set; }
        public string Medio { get; set; }
        public string Descripcion { get; set; }
        //public int? IdIgedRegistro { get; set; }
        public Iged Iged { get; set; }
        public TipoMedioContacto TipoMedioContacto { get; set; }
    }
}
