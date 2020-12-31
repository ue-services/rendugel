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
    public class ManagerBandeja : IManagerBandeja, IDisposable
    {
        public void Dispose()
        {
           return;
        }

        public List<EBandeja> ObtenerBandejas()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Bandeja
                    .Where(x => x.EsActivo == true & x.EsBorrado == false)
                    .Select(x=> new EBandeja
                    { 
                        IdBandeja = x.IdBandeja, 
                        CodBandeja = x.CodBandeja,
                        Descripcion = x.Descripcion
                    })
                    .ToList();
                return item;
            }
        }
    }
}
