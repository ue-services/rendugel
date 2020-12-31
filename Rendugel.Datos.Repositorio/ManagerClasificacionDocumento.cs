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
    public class ManagerClasificacionDocumento : IManagerClasificacionDocumento, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public ClasificacionDocumento ObtenerClasificacionDocumentoPorCodigo(int CodClasificacion)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.ClasificacionDocumento
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodClasificacionDoc == CodClasificacion)                    
                    .FirstOrDefault();
                return item;
            }
        }

        
    }
}
