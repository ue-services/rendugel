using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerOrigenSuspCanc : IManagerOrigenSuspCanc, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<EOrigenSuspencionCancelacion> ObtenerListaOrigenSuspCanc()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.OrigenSuspencionCancelacion
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new EOrigenSuspencionCancelacion
                    {
                        IdOrigenSuspCanc = x.IdOrigenSuspCanc,
                        CodTipoSuspCanc = x.CodTipoSuspCanc,
                        Descripcion = x.Descripcion
                    })
                    .ToList();
                return items;
            }
        }

        public OrigenSuspencionCancelacion ObtenerOrigenSuspCancPorCodigo(int codOrigen)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.OrigenSuspencionCancelacion
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoSuspCanc == codOrigen)                    
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
