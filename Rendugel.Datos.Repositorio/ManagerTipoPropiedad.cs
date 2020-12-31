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
    public class ManagerTipoPropiedad : IManagerTipoPropiedad, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<ETipoPropiedad> ObtenerListaTiposPropiedad()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoPropiedad
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new ETipoPropiedad
                    {
                        IdTipoPropiedad = x.IdTipoPropiedad,
                        CodTipoPropiedad = x.CodTipoPropiedad,
                        DescTipoPropiedad = x.DescTipoPropiedad
                    })
                    .ToList();
                return items;
            }
        }
    }
}
