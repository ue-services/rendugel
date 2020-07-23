using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Aplicacion.Interfaces
{
    public interface IListasAplicacion
    {
        IEnumerable<TipoIged> ObtenerListaTipoIgedSP();
        IEnumerable<TipoIged> ObtenerListaTipoIgedEF();
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoSP();
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoEF();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralSP();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralEF();
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroSP();
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroEF();
        IEnumerable<Ubigeo> ObtenerListasUbigeoSP();
        IEnumerable<Ubigeo> ObtenerListasUbigeoEF();
        IEnumerable<Ubigeo> ObtenerListaLocalidadSP();
        IEnumerable<Ubigeo> ObtenerListaLocalidadEF();
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoSP();
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoEF();
        IEnumerable<Iged> ObtenerListaUgelesSP();
        IEnumerable<Iged> ObtenerListaUgelesEF();
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaSP(int idNaturalea);
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaEF(int idNaturalea);
    }
}
