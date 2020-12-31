using Rendugel.Datos.Repositorio;
using Rendugel.Dominio.Interfaces;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio
{
    public class ConfiguracionRepositorio : IConfiguracionRepositorio
    {
        public List<EBandeja> ObtenerBandejas()
        {
            ManagerBandeja managerBandeja = new ManagerBandeja();
            return managerBandeja.ObtenerBandejas();
        }
    }
}
