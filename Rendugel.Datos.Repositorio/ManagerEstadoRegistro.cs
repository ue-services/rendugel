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
    public class ManagerEstadoRegistro : IManagerEstadoRegistro, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public EstadoRegistro ObtenerEstadoRegistroPorCodigo(int codEstadoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.EstadoRegistro
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodEstadoRegistro == codEstadoRegistro)
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
