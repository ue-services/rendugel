using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoIged : IManagerTipoIged, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public ETipoIged ObtenerCDTipoIgedPorCodigo(int codTipoIged)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoIged
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoIged==codTipoIged)
                    .Select(x => new ETipoIged
                    {
                        IdTipoIged = x.IdTipoIged,
                        CodTipoIged = x.CodTipoIged,
                        DescTipoIged = x.DescTipoIged
                    })
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
