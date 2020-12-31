using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class ListasComponentesResponse
    {
        public IEnumerable<ETipoMedioContacto> TiposMedioDatosGenerales { get; set; }
        public IEnumerable<ETipoMedioContacto> TiposMedioDatosDirector { get; set; }
        public ETipoMedioContacto TipoMedioCelular { get; set; }
        public ETipoMedioContacto TipoMedioTelefono { get; set; }
        public ETipoMedioContacto TipoMedioEmail { get; set; }
        public IEnumerable<ETipoPersonal> TiposPersonalDatosPersonal { get; set; }
        public ETipoPersonal TipoPersonalDirector { get; set; }
        public IEnumerable<ETipoLocal> TiposLocal { get; set; }
        public IEnumerable<ETipoPropiedad> TiposPropiedad { get; set; }
        public IEnumerable<ETipoDocumento> TiposDocumento { get; set; }
        public IEnumerable<EPliegoUnidadEjecutora> PliegosUnidadEjecutora { get; set; }       
        
    }
}
