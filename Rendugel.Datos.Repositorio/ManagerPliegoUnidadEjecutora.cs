using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerPliegoUnidadEjecutora : IManagerPliegoUnidadEjecutora, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<EPliegoUnidadEjecutora> ObtenerListaPliegoUnidadEjecutora()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.PliegoUnidadEjecutora
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new EPliegoUnidadEjecutora
                    {
                        IdPliegoUnidadEjecutora = x.IdPliegoUnidadEjecutora,
                        CodPliegoUnidadEjecutora = x.CodPliegoUnidadEjecutora,
                        DescPliegoUnidadEjecutora = x.DescPliegoUnidadEjecutora
                    })
                    .ToList();
                return items;
            }
        }
    }
}
