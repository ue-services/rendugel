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
    public class ManagerTipoSuspensionCancelacion : IManagerTipoSuspensionCancelacion, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public TipoSuspensionCancelacion ObtenerTipoSuspCancPorCodigo(int codTipoSuspCanc)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoSuspensionCancelacion
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoSuspCanc == codTipoSuspCanc)
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
