using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EDocumento
    {
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombreArchivo { get; set; }
        public EDocumentoTem Temporal { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaPublicacion { get; set; }         
        public string Ruta { get; set; }
        public EClasificacionDocumento ClasificacionDocumento { get; set; }
        //public virtual ERutaArchivos RutaArchivos { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        //public ETipoFuncionDocumento TipoFuncionDocumento { get; set; } 
        //public ERutaArchivos Ruta { get; set; }
    }
}
