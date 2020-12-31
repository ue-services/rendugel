using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerDocumento : IManagerDocumento, IDisposable
    {

        public void Dispose()
        {
            return;
        }

        public Documento ObtenerDocumentoPorId(int idDocumento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.Documento.Where(x=> x.IdDocumento == idDocumento).FirstOrDefault();
            }
        }

        public int saveDocumento(Documento documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Documento.Add(documento);
                _context.SaveChanges();
                return documento.IdDocumento;
            }
        }

        public void updateDocumento(Documento documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Documento.Update(documento);
                _context.SaveChanges();
            }
        }

    }
}
