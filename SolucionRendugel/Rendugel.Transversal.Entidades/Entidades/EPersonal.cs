using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EPersonal
    {
        public int IdPersonal { get; set; }
        public int? IdIgedRegistro { get; set; }
        public Iged Iged { get; set; }
        public Persona Persona { get; set; }
        public TipoPersonal TipoPersona { get; set; }
    }
}
