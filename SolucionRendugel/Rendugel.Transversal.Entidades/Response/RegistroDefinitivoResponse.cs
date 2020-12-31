using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class RegistroDefinitivoResponse
    {
        public int IdRegistro { get; set; }
        public IEnumerable<EIgedRegistroDefinitivoDetalle_> DetalleDerivados { get; set; }
        public IEnumerable<EMedioContacto> MediosContactoIged { get; set; }       
        public IEnumerable<EPersonalExtend> PersonalIged { get; set; }
        public IEnumerable<ELocalIged> localesIged { get; set; }
        public EUnidadEjecutora UnidadEjecutora { get; set; }
        public IEnumerable<EJurisdiccion> JurisdiccionUgel { get; set; }        
        public EDocumento DocumentoResolutivoDirector { get; set; }
        bool EsUEAutonoma { get; set; }
    }
}
