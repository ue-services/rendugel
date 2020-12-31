using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EPersonalExtend
    {
        public int IdPersonal { get; set; }
        public string NomPersona { get; set; }
        public string AppPersona { get; set; }
        public string ApmPersona { get; set; }
        public string DniPersona { get; set; }
        public ETipoPersonal tipoPersonal { get; set; }
        public EPersonalMedioContactoB Celular { get; set; }
        public EPersonalMedioContactoB Telefono { get; set; }
        public EPersonalMedioContactoB Email { get; set; }
        //public EIged Iged { get; set; }
        public EDocumento documentoResolutivo { get; set; }
    }
}
