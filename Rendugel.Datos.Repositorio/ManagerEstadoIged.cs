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
    public class ManagerEstadoIged : IManagerEstadoIged, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public EstadoIged ObtenerEstadoIgedPorCodigo(int codEstadoIged)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.EstadoIged
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodEstadoIged == codEstadoIged)
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
