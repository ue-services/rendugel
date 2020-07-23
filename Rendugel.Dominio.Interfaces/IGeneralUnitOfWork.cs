using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio.Interfaces
{
    public interface IGeneralUnitOfWork
    {
        IEnumerable<TipoIged> ObtenerListaTipoIged();
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativo();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistral();
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistro();
        IEnumerable<Ubigeo> ObtenerListasUbigeo();
        IEnumerable<Ubigeo> ObtenerListaLocalidad();
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumento();
        IEnumerable<Iged> ObtenerListaUgeles();
    }
}
