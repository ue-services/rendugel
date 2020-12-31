using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EUgelCompleta
    {
        public int? IdIged { get; set; }
        public string CodIged { get; set; }
        public string NomIged { get; set; }
        public ETipoIged TipoIged { get; set; }
        public EEstadoIged EstadoIged { get; set; }
        public IEnumerable<EJurisdiccion> JurisdiccionUgel { get; set; }
        public IEnumerable<ELocalIged> localesIged { get; set; }
        public EPersonalExtend Director { get; set; }
        public IEnumerable<EPersonalExtend> PersonalIged { get; set; }
        public IEnumerable<EMedioContacto> MediosContactoIged { get; set; }
        public bool EsUeAutonoma { get; set; }
        public EUnidadEjecutora UnidadEjecutora { get; set; }
        public EUbigeo Ubigeo { get; set; }
    }
}
