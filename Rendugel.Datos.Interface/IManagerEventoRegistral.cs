using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerEventoRegistral
    {
        /// <summary>
        ///La inclusión CD en el nombre de la función indica "Codigo, Descripción",
        /// es decir, para el caso, optener código y descripción de "EventoRegistral"
        /// </summary>
        EEventoRegistral ObtenerCDEventoRegistralPorCodigo(int codEvento);
        IEnumerable<EEventoRegistral> ObtenerEventosColaterales(int codEvento);
        IEnumerable<EEventoRegistral> ObtenerEventoRegistralPorConfiguracion(int codTipoRegistro, int codTipoIGED);
    }
}
