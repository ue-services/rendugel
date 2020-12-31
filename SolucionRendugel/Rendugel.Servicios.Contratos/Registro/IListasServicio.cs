using Rendugel.Dominio.Entidades.Modelo;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Rendugel.Servicios.Contratos.Registro
{
    [ServiceContract]
    public interface IListasServicio
    {
        [WebGet(UriTemplate = "/TipoIgedSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoIged> ObtenerListaTipoIgedSP();

        [WebGet(UriTemplate = "/TipoIgedEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoIged> ObtenerListaTipoIgedEF();

        [WebGet(UriTemplate = "/NaturalezaActoAdministrativoSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoSP();

        [WebGet(UriTemplate = "/NaturalezaActoAdministrativoEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoEF();

        [WebGet(UriTemplate = "/EventoRegistralSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralSP();

        [WebGet(UriTemplate = "/EventoRegistralEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralEF();

        [WebGet(UriTemplate = "/TipoRegistroSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroSP();

        [WebGet(UriTemplate = "/TipoRegistroEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroEF();

        //No está implementado
        [WebGet(UriTemplate = "/UbigeoSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListasUbigeoSP();

        [WebGet(UriTemplate = "/UbigeoEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListasUbigeoEF();

        [WebGet(UriTemplate = "/LocalidadSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListaLocalidadSP();

        [WebGet(UriTemplate = "/LocalidadEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListaLocalidadEF();

        [WebGet(UriTemplate = "/TipoDocumentoSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoSP();

        [WebGet(UriTemplate = "/TipoDocumentoEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoEF();

        [WebGet(UriTemplate = "/UgelesSP", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Iged> ObtenerListaUgelesSP();

        [WebGet(UriTemplate = "/UgelesEF", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<Iged> ObtenerListaUgelesEF();

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaSP(int idNaturalea);

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaEF(int idNaturalea);
    }
}
