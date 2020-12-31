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
    public class ManagerDocumentoTem: IManagerDocumentoTem, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public DocumentoTem ObtenerDocumentoPorId(int idDocumentoTem)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoTem.Where(x => x.IdDocumentoTem == idDocumentoTem).FirstOrDefault();
            }
        }

        public DocumentoTem ObtenerDocumentoPorUsurioFinalidad(string usuario, string finalidad)
        {
            //DocumentoTem docuemntoTem = new DocumentoTem();

           using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                 return _context.DocumentoTem.Where(x => x.UsuCreacion == usuario
                                                    && x.Finalidad == finalidad
                                                    && x.EsActivo == true
                                                    && x.EsBorrado == false).FirstOrDefault();
               // if (r != null)
               // {
               //     docuemntoTem = r;
               // }
            }
            //return docuemntoTem;
        }

        public int saveDocumento(DocumentoTem documentoTem)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoTem.Add(documentoTem);
                _context.SaveChanges();
                return documentoTem.IdDocumentoTem;
            }
        }

        public void updateDocumento(DocumentoTem documentoTem)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoTem.Update(documentoTem);
                _context.SaveChanges();
            }
        }
    }
}
