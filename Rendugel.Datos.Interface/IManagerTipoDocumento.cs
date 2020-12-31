using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerTipoDocumento
    {
        /// <summary>
        ///La inclusión CD en el nombre de la función indica "Codigo, Descripción",
        /// es decir, para el caso, obtener código y descripción de "TipoRegistro"
        /// </summary>
        ETipoDocumento ObtenerCDTipoDocumentoPorCodigo(int CodTipoDoc);
        IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento();
    }
}
