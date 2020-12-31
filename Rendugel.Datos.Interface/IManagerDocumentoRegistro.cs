using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDocumentoRegistro
    {
        int saveDocumentoRegistro(DocumentoRegistro documentoRegistro);

        void updateDocumentoRegistro(DocumentoRegistro documentoRegistro);

        DocumentoRegistro ObtenerDocumentoRegistroPorId(int idDocumentoRegistro);

        DocumentoRegistro ObtenerDocumentoRegistroPorIdRegistroIdDocumento(int idRegistro, int idDocumento);

        int actualizarDocumentoRegistro(DocumentoRegistro documentoRegistro);
    }
}
