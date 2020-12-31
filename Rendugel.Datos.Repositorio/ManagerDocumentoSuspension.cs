using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerDocumentoSuspension : IManagerDocumentoSuspension, IDisposable
    {
        
        public void Dispose()
        {
            return;
        }

        public DocumentoSuspension ObtenerDocumentoSuspensionPorId(int idDocumentoSuspension)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoSuspension.Where(x => x.IdDocumentoSuspension == idDocumentoSuspension).FirstOrDefault();
            }
        }

        public DocumentoSuspension ObtenerDocumentoSuspensionPorIdRegistroIdDocumento(int idRegistro, int idDocumento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoSuspension.Where(x => x.IdDocumento == idDocumento && x.IdRegistro == idRegistro && x.EsActivo == true && x.EsBorrado == false).FirstOrDefault();
            }
        }

        public int saveDocumentoSuspension(DocumentoSuspension documentoSuspension)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoSuspension.Add(documentoSuspension);
                _context.SaveChanges();
                return documentoSuspension.IdDocumentoSuspension;
            }
        }

        public void updateDocumentoSuspension(DocumentoSuspension documentoSuspension)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoSuspension.Update(documentoSuspension);
                _context.SaveChanges();
            }
        }

        public int actualizarDocumentoSuspension(DocumentoSuspension documentoSuspension)
        {
            throw new NotImplementedException();
        }
    }

}
