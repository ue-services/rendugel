using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoDocumento : IManagerTipoDocumento, IDisposable
    {
        public void Dispose()
        {
            return;
        }
        public ETipoDocumento ObtenerCDTipoDocumentoPorCodigo(int codTipoDoc)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoDocumento
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoDoc == codTipoDoc)
                    .Select(x => new ETipoDocumento
                    {
                        IdTipoDoc = x.IdTipoDoc,
                        CodTipoDoc = x.CodTipoDoc,
                        DescTipoDoc = x.DescTipoDoc
                    })
                    .FirstOrDefault();
                return item;
            }
        }

        public IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoDocumento
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new ETipoDocumento
                    {
                        IdTipoDoc = x.IdTipoDoc,
                        CodTipoDoc = x.CodTipoDoc,
                        DescTipoDoc = x.DescTipoDoc
                    })
                    .ToList();
                return items;
            }

        }
    }
}
