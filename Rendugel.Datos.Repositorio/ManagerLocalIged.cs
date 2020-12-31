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
    public class ManagerLocalIged : IManagerLocalIged, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public void saveListaLocalIged(List<LocalIged> listaLocalIged)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.LocalIged.AddRange(listaLocalIged);
                _context.SaveChanges();
            }
        }

        public int saveLocalIged(LocalIged localIged)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.LocalIged.Add(localIged);
                _context.SaveChanges();
                return localIged.IdLocalIged;
            }
        }

        public void updateLocalIged(LocalIged localIged)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.LocalIged.Update(localIged);
                _context.SaveChanges();
            }
        }

    }
}
