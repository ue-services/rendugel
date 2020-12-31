using Rendugel.Datos.Interface;
using System;
using Rendugel.Dominio.Entidades.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Modelo;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerSuspensionCancelacion : IManagerSuspensionCancelacion, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public int saveSuspensionCancelacion(SuspensionCancelación suspensionCancelación)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.SuspensionCancelación.Add(suspensionCancelación);
                _context.SaveChanges();
                return suspensionCancelación.IdSuspCanc;
            }
        }
    }
}
