using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ResponseService
    {
        public bool? ResultValid { get; set; }
        public string MensajePrincipal { get; set; }
        public string[] Mensajes { get; set; }
        public int? idRegistro { get; set; }
        public string Llave { get; set; }

    }
}
