using Rendugel.Transversal.Entidades;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Rendugel.Transversal.Entidades.Entidades;

namespace Rendugel.Servicios.Contratos.Registro
{
    [ServiceContract]
    public interface IComunRegistroServicios
    {
        [WebInvoke(
            Method ="POST",
            //BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Upload"),]
        [OperationContract]
        string Upload(Stream data);
        //string Upload(HttpContent content);
        //HttpResponseMessage Upload(HttpContent content);

        [WebInvoke(UriTemplate = "/OpcionesRegistro", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        EOpcionesRegistro ObtenerOpcionesRegistro(EOpcionesRequest eOpcionesRequest);

        [WebGet(UriTemplate = "/OpcionesUbigeo/{IdDre}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre);

        [WebInvoke(UriTemplate = "/OpcionesJurisdiccionInvolucradas", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        EOpcionesJurisdiccionInvolucradas ObtenerOpcionesJurisdiccionInvolucradas(EParametrosRegistroRequest parRegistrorequest);

        [WebInvoke(UriTemplate = "/ObtenerListaUgelesInvolucradasPorUgel", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IList<EIged> ObtenerListaUgelesInvolucradasPorUgel(EIged ugel);

        [WebGet(UriTemplate = "/listaDre", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<EIged> ObtenerDre();

        [WebGet(UriTemplate = "/ObtenerListaCDTipoDocumento", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento();

        [WebGet(UriTemplate = "/ObtenerListaUgelesPorDre/{codDre}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre);

        [WebInvoke(UriTemplate = "/ObtenerCCPPPorDistrito", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito);

        [WebInvoke(UriTemplate = "/SaveRegistroProvisional", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest);

        [WebInvoke(UriTemplate = "/SuspenderRegistroProvisional", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseService SuspenderRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest);

        [WebInvoke(UriTemplate = "/CancelarRegistroProvisional", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseService CancelarRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest);

        [WebInvoke(UriTemplate = "/PasarADefinitivo", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseService pasarADefinitivo(ERegistroDefinitivo registroDefinitivo);

        [WebGet(UriTemplate = "/ObtenerListasComponentes", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ListasComponentesResponse ObtenerListasComponentes();

        [WebGet(UriTemplate = "/ObtenerListasComponentesSuspension", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension();

        [WebGet(UriTemplate = "/ObtenerRegistrosProvisionales", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales();

        [WebGet(UriTemplate = "/ObtenerRegistrosProvisionales2", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        RegistrosProvisionalesResponse ObtenerRegistrosProvisionales2();

        [WebInvoke(UriTemplate = "/ObtenerRegistrosProvisionalesPoTipoEstado", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(EOpcionesBandejaRequest opcionesBandejaRequest);

        [WebInvoke(UriTemplate = "/ObtenerRegistrosPorBandeja", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja eBandeja);


        [WebInvoke(UriTemplate = "/obtenerRegistroDetallePorIdRegistro", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro);

        [WebInvoke(UriTemplate = "/obtenerJurisdiccionUgelPorListaUgeles", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel);

        [WebInvoke(UriTemplate = "/obtenerJurisdiccionUgelPorIdUgel", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel);

        [WebInvoke(UriTemplate = "/ElimarRegistro", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ResponseService ElimarRegistro(int idRegistro);

        [WebGet(UriTemplate = "/ObtenerBandejas", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<EBandeja> ObtenerBandejas();
    }
}
