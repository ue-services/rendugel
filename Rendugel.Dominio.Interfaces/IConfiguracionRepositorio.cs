using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio.Interfaces
{
    public interface IConfiguracionRepositorio
    {
        List<EBandeja> ObtenerBandejas();
    }
}
