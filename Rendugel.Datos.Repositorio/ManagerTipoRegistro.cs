using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerTipoRegistro : IManagerTipoRegistro, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public ETipoRegistro ObtenerCDTipoRegistroPorCodigo(int codTipoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoRegistro
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodTipoRegistro==codTipoRegistro)
                    .Select(x => new ETipoRegistro
                    {
                        IdTipoRegistro = x.IdTipoRegistro,
                        CodTipoRegistro = x.CodTipoRegistro,
                        DescTipoRegistro = x.DescTipoRegistro
                    })
                    .FirstOrDefault();
                return item;
            }
        }
    }
}
