using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoMedioContacto : IManagerTipoMedioContacto, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<ETipoMedioContacto> ObtenerListaTiposMedioContactoDatosDirector()
        {
            int codWeb = 4;

            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoMedio != codWeb)
                    .Select(x => new ETipoMedioContacto
                    {
                        IdTipoMedioContacto = x.IdTipoMedioContacto,
                        CodTipoMedio = x.CodTipoMedio,
                        DescTipoMedio = x.DescTipoMedio
                    })
                    .ToList();
                return items;

            }
        }

        public IEnumerable<ETipoMedioContacto> ObtenerListaTiposMedioContactoDatosGenerales()
        {
            using (var _context = new rendugelDBContext())
            {
                var items = _context.TipoMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x => new ETipoMedioContacto
                    {
                        IdTipoMedioContacto = x.IdTipoMedioContacto,
                        CodTipoMedio = x.CodTipoMedio,
                        DescTipoMedio = x.DescTipoMedio
                    })
                    .ToList();
                return items;

            }
        }

        public ETipoMedioContacto ObtenerMedioContactoPorCodigo(int codigo)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoMedio == codigo)
                    .Select(x => new ETipoMedioContacto
                    {
                        IdTipoMedioContacto = x.IdTipoMedioContacto,
                        CodTipoMedio = x.CodTipoMedio,
                        DescTipoMedio = x.DescTipoMedio
                    })
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
