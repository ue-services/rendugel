using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using Rendugel.Transversal.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio.Interfaces
{
    public interface IComunRegistroRepositorio
    {
        IEnumerable<EIged> ObtenerListaCDIgedPorCodTipoIged(int codTipoIged);
        ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorCodigo(int codNaturaleza);
        ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorEvento(int codEvento);
        EEventoRegistral ObtenerCDEventoRegistralPorCodigo(int codEvento);
        ETipoIged ObtenerCDTipoIgedPorCodigo(int codTipoIged);
        ETipoRegistro ObtenerCDTipoRegistroPorCodigo(int codTipoRegistro);
        ETipoDocumento ObtenerCDTipoDocumentoPorCodigo(int codTipoDoc);
        ERegion ObtenerRegionPorDre(int IdDre);
        IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento();
        IEnumerable<EProvincia> ObtenerProvinciasPorRegion(string codUbigeoRegion);
        IEnumerable<EDistrito> ObtenerDistritosPorRegion(string codUbigeoRegion);
        IEnumerable<EDistrito> ObtenerDistritosPorProvincia(string codUbigeoProvincia);
        IEnumerable<EIged> ObtenerListaUgelesInvolucradas(int IdDre, int? IdUgel);
        IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(int IdUgel);
        IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre);
        IEnumerable<EEventoRegistral> ObtenerEventosColaterales(int codEvento);
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionDeUgelesPorDre(int IdDre);
        IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel);
        int ActualizarRegistrosDeJurisdiccion(List<JurisdiccionIged> listaJurisdiccion, List<EIged> listaIged);
        IEnumerable<EDistrito> ObtenerDistritosPorListaProvincias(List<EProvincia> listaProvincias);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorListaDistrito(List<EDistrito> listaDistritos);
        IEnumerable<EDistrito> ObtenerDistritosPorListaIdDistritos(List<EDistrito> listaIdDistritos);
        IEnumerable<EDistrito> ObtenerDistritosPorRegionNoIncluidosEnLasProvincias(string codUbigeoRegion, List<EProvincia> listaProvincias);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorListaCCPP(List<ECentroPoblado> listaCCPP);
        IEnumerable<EEventoRegistral> ObtenerEventoRegistralPorConfiguracion(int codTipoRegistro, int codTipoIGED);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito);
        ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest);
        ResponseService SuspCanRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest, int codSuspCanc);
        ResponseService pasarADefinitivo(ERegistroDefinitivo registroDefinitivo);
        //ResponseService pasarADefinitivo(RegistroDefinitivoResponse registroDefinitivoResponse);
        ResponseService modificacionSignificativa(EModificacionSignificativaRequest modificacionSignificativaRequest);
        ResponseService modificacionComplementaria(ERegistroDefinitivo registroDefinitivo);
        ListasComponentesResponse ObtenerListasComponentes();
        ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension();
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales();
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro);
        IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja);
        IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro);
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel);
        UploadTempResponse GrabarDatosDocumentoTemporal(EDocumentoTem documentoTem);
        //EDocumentoTem GrabarDatosDocumentoTemporal(EDocumentoTem documentoTem);
        Documento ObtenerDocumentoPorId(int idDocumento);
        DocumentoTem ObtenerDocumentoTemPorId(int idDocumentoTem);
        int saveDocumento(Documento documento);
        ResponseService ElimarRegistro(int idRegistro);
    }
}
