using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerTipoLocal
    {
        IEnumerable<ETipoLocal> ObtenerListaTiposLocal();
    }
}
