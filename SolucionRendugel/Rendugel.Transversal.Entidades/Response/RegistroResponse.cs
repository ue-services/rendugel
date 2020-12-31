using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class RegistroResponse
    {
        public EIged Dre { get; set; }
        public ETipoIged TipoIged { get; set; }
        public EEventoRegistral EventoRegistral { get; set; }
        public ETipoRegistro TipoRegistro { get; set; }
        public EUbigeo Ubigeo { get; set; }
        public EDocumento DocumentoResolutivo { get; set; }
         public string NombreUgel { get; set; }
        public string CodUgel { get; set; }
  
    }
}
