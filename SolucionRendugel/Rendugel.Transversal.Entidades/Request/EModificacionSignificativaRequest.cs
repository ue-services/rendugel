using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EModificacionSignificativaRequest
    {
        public List<EEventoRegistral> listaEventoRegistral { get; set; }

        public ERegistroDefinitivo registroDefinitivo { get; set; }
    }
}
