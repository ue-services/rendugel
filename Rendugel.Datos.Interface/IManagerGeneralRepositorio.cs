using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System.Collections.Generic;

namespace Rendugel.Datos.Interfaces
{
    public interface IManagerGeneralRepositorio
    {
        IEnumerable<TipoIged> ObtenerListaTipoIged();
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativo();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistral();
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistro();
        IEnumerable<Ubigeo> ObtenerListasUbigeo();
        IEnumerable<Ubigeo> ObtenerListaLocalidad();
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumento();
        IEnumerable<Iged> ObtenerListaUgeles();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturaleza(int idNaturalea);

    }
}
