using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Aplicacion.Interfaces
{
    public interface IComunRegistro
    {
        EOpcionesRegistro ObtenerOpcionesRegistro(EOpcionesRequest eOpcionesRequest);

        /// <summary>
        ///Obtenemos aqui una región y su lista de Provincias y distritos en el obeto EOpcionesUbigeo
        ///teniendo como parámeto la DRE, para obtener a partir de ella la región.
        /// </summary>
        //EOpcionesUbigeo ObtenerOpcionesUbigeo(EIged dre);
        EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre);
        EOpcionesJurisdiccionInvolucradas ObtenerOpcionesJurisdiccionInvolucradas(EParametrosRegistroRequest parRegistrorequest);
        EOpcionesJurisdiccionPertenencia ObtenerOpcionesJurisdiccionPertenencia(EPertenenciaRequest ePertenenciaRequest);
        IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel);
        IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(EIged ugel);
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel);
        IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre);
        IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento();
        IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito);
        List<EIged> ObtenerDre();
        ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest, string rutaBase);
        ResponseService SuspCanRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest, string rutaBase, int codSuspCanc);
        ResponseService pasarADefinitivo(ERegistroDefinitivo eRegistroDefinitivo);
        ListasComponentesResponse ObtenerListasComponentes();
        ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension();
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales();
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro);
        IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja);
        IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro);
        UploadTempResponse GrabarDatosDocumentoTemporal(EDocumentoTem eDocumentoTem);
        //EDocumentoTem GrabarDatosDocumentoTemporal(EDocumentoTem eDocumentoTem);
        ResponseService ElimarRegistro(int idRegistro);
    }
}
