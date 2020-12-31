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
    public class ManagerConfiguracionTipoSusp : IManagerConfiguracionTipoSusp, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public ClasificacionDocPorTipoSusCan ObtenerConfiguracionTipoSusp(int codTipoSuspCanc)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.ClasificacionDocPorTipoSusCan
                            join b in _context.TipoSuspensionCancelacion on a.IdTipoSuspCanc equals b.IdTipoSuspCanc
                            where b.CodTipoSuspCanc == codTipoSuspCanc
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).FirstOrDefault();
                return item;
            }
        }
    }
}
