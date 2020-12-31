using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoPersonal : IManagerTipoPersonal, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<ETipoPersonal> ObtenerListaTiposPersonalDatosPersonal()        {

            int codDirector = 1;
            
            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoPersonal
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoPersonal != codDirector)
                    .Select(x => new ETipoPersonal
                    {
                        IdTipoPersonal = x.IdTipoPersonal,
                        CodTipoPersonal = x.CodTipoPersonal,
                        DescTipoPersonal = x.DescTipoPersonal
                    })
                    .ToList();
                return items;
            }
        }

        public ETipoPersonal ObtenerTipoPersonalPorCodigo(int codigo)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoPersonal
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoPersonal == codigo)
                    .Select(x => new ETipoPersonal
                    {
                        IdTipoPersonal = x.IdTipoPersonal,
                        CodTipoPersonal = x.CodTipoPersonal,
                        DescTipoPersonal = x.DescTipoPersonal
                    })
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
