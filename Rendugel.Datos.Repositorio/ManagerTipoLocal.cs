using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoLocal : IManagerTipoLocal, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<ETipoLocal> ObtenerListaTiposLocal()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoLocal
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new ETipoLocal
                    {
                        IdTipoLocal = x.IdTipoLocal,
                        CodTipoLocal = x.CodTipoLocal,
                        DescTipoLocal = x.DescTipoLocal
                    })
                    .ToList();
                return items;
            }
        }
    }
}
