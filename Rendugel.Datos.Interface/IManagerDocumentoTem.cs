using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDocumentoTem
    {
        int saveDocumento(DocumentoTem documentoTem);

        void updateDocumento(DocumentoTem documentoTem);

        DocumentoTem ObtenerDocumentoPorId(int idDocumentoTem);
        DocumentoTem ObtenerDocumentoPorUsurioFinalidad(string usuario, string finalidad);
    }
}
