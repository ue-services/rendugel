using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDocumento
    {
        int saveDocumento(Documento documento);

        void updateDocumento(Documento documento);

        Documento ObtenerDocumentoPorId(int idDocumento);

    }
}
