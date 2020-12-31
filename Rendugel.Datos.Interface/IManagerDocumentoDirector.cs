using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDocumentoDirector
    {
        int saveDocumentoDirector(DocumentoDirector documento);

        void updateDocumentoDirector(DocumentoDirector documento);

        DocumentoDirector ObtenerDocumentoDirectorPorId(int idDocumento);
    }
}
