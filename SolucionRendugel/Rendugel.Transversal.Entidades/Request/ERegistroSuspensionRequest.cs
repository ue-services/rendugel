using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ERegistroSuspensionRequest
    {
        public int IdRegistro { get; set; }
        public ESuspencionCancelacion suspencionCancelacion { get; set; }
        public EDocumento DocumentoDeSustento { get; set; }
    }
}
