using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    [DataContract]
    public class EOpcionesRegistro
    {
        [DataMember]
        public IList<EIged> ListaDRE { get; set; }
        //[DataMember]
        //public IList<EIged> ListaUGEL { get; set; }
        [DataMember]
        public IList<ETipoIged> ListaTipoIged { get; set; }
        [DataMember]
        public IList<ENaturaleza> ListaNaturaleza { get; set; }
        [DataMember]
        public IList<EEventoRegistral> ListaEventoRegistral { get; set; }
        [DataMember]
        public IList<ETipoRegistro> ListaTipoRegistro { get; set; }


    }
}
