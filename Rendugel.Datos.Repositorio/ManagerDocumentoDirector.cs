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
    public class ManagerDocumentoDirector : IManagerDocumentoDirector, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public DocumentoDirector ObtenerDocumentoDirectorPorId(int id)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoDirector.Where(x => x.IdDocumentoDirector == id).FirstOrDefault();
            }
        }

        public int saveDocumentoDirector(DocumentoDirector documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoDirector.Add(documento);
                _context.SaveChanges();
                return documento.IdDocumentoDirector;
            }
        }

        public void updateDocumentoDirector(DocumentoDirector documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoDirector.Update(documento);
                _context.SaveChanges();
            }
        }
    }
}
