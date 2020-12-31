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
    public class ManagerDocumentoRegistro : IManagerDocumentoRegistro, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public DocumentoRegistro ObtenerDocumentoRegistroPorId(int idDocumentoRegistro)
        {
            using(var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoRegistro.Where(x => x.IdDocumentoRegistro == idDocumentoRegistro).FirstOrDefault();
            }
        }

        public DocumentoRegistro ObtenerDocumentoRegistroPorIdRegistroIdDocumento(int idRegistro, int idDocumento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.DocumentoRegistro.Where(x => x.IdDocumento == idDocumento && x.IdRegistro == idRegistro && x.EsActivo== true && x.EsBorrado==false).FirstOrDefault();
            }
        }


        public int actualizarDocumentoRegistro(DocumentoRegistro documentoRegistro)
        {
            DateTime fechaHoy = DateTime.Now;
 //           string usuario = "40615837";
            List<DocumentoRegistro> listaDoumentoRegistroAnt = new List<DocumentoRegistro>();
            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        listaDoumentoRegistroAnt = (from a in _context.DocumentoRegistro
                                                    join b in _context.Documento on a.IdDocumento equals b.IdDocumento
                                                    join c in _context.ClasificacionDocumento on b.IdClasificacionDoc equals c.IdClasificacionDoc
                                       where a.IdRegistro == documentoRegistro.IdRegistro 
                                               & c.CodClasificacionDoc == 1 //resolutivo ... enumerados
                                               & a.EsActivo == true & a.EsBorrado == false
                                               & b.EsActivo == true & b.EsBorrado == false
                                               & c.EsActivo == true & c.EsBorrado == false
                                       select new DocumentoRegistro
                                       {
                                           IdDocumentoRegistro = a.IdDocumentoRegistro,
                                           IdDocumento = a.IdDocumento,
                                           IdRegistro = a.IdRegistro,
                                           FechaCreacion = a.FechaCreacion,
                                           FechaActualizacion = fechaHoy,
                                           UsuCreacion = a.UsuCreacion,
                                           UsuActualizacion = documentoRegistro.UsuActualizacion,
                                           EsActivo = false,
                                           EsBorrado = true
                                       }
                                       ).ToList();

                        if (listaDoumentoRegistroAnt != null && listaDoumentoRegistroAnt.Count>0)
                        {
                            _context.DocumentoRegistro.UpdateRange(listaDoumentoRegistroAnt);
                            _context.SaveChanges();
                        }                        

                        _context.DocumentoRegistro.Add(documentoRegistro);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
                return documentoRegistro.IdDocumentoRegistro;
            }
        }


        public int saveDocumentoRegistro(DocumentoRegistro documentoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoRegistro.Add(documentoRegistro);
                _context.SaveChanges();
                return documentoRegistro.IdDocumentoRegistro;
            }
        }

        public void updateDocumentoRegistro(DocumentoRegistro documentoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoRegistro.Update(documentoRegistro);
                _context.SaveChanges();
            }
        }
    }
}
