using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EOpcionesBandejaRequest
    {
        public List<ETipoRegistro> listaTipoRegistro { get; set; }
        public List<EEstadoRegistro> listaEstadoRegistro { get; set; }
    }
}
