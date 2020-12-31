using Rendugel.Aplicacion.Interfaces;
using Rendugel.Dominio;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Aplicacion.Registro
{
    public class ConfiguracionAplicacion : IConfiguracionAplicacion
    {
        readonly ConfiguracionRepositorio configuracionRepositorio = new ConfiguracionRepositorio();
        public List<EBandeja> ObtenerBandejas()
        {
            return configuracionRepositorio.ObtenerBandejas();
        }
    }
}
