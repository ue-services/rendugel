using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDocumentoSuspension
    {
        int saveDocumentoSuspension(DocumentoSuspension documentoSuspension);

        void updateDocumentoSuspension(DocumentoSuspension documentoSuspension);

        DocumentoSuspension ObtenerDocumentoSuspensionPorId(int idDocumentoSuspension);

        DocumentoSuspension ObtenerDocumentoSuspensionPorIdRegistroIdDocumento(int idRegistro, int idDocumento);

        int actualizarDocumentoSuspension(DocumentoSuspension documentoSuspension);
    }
}
