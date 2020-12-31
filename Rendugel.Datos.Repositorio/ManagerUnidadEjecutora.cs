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
    public class ManagerUnidadEjecutora : IManagerUnidadEjecutora, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public UnidadEjecutora ObtenerManagerUnidadEjecutoraPorId(int idUnidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.UnidadEjecutora
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdUnidadEjecutora == idUnidadEjecutora)
                    .FirstOrDefault();
                return item;
            }
        }

        public int saveManagerUnidadEjecutora(UnidadEjecutora unidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.UnidadEjecutora.Add(unidadEjecutora);
                _context.SaveChanges();
                return unidadEjecutora.IdUnidadEjecutora;
            }
        }

        public void updateManagerUnidadEjecutora(UnidadEjecutora unidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.UnidadEjecutora.Update(unidadEjecutora);
                _context.SaveChanges();
            }
        }
    }
}
