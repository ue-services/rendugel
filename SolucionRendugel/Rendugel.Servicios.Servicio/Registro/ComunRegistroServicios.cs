using Rendugel.Aplicacion.Registro;
using Rendugel.Servicios.Contratos.Registro;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace Rendugel.Servicios.Servicio.Registro
{
    public class ComunRegistroServicios : IComunRegistroServicios
    {
        readonly ComunRegistro comunRegistro = new ComunRegistro();

        //public HttpResponseMessage Upload(HttpContent content)
        public string  Upload(Stream data)
        {
            return "ok";
            // Obtener información de encabezado de WebOperationContext.Current.IncomingRequest.Headers
            // abrir y decodificar los datos multiparte, guardar en el lugar deseado
        }

      
        public List<EIged> ObtenerDre()
        {
            return comunRegistro.ObtenerDre();
        }

        public IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento()
        {
            return comunRegistro.ObtenerListaCDTipoDocumento().ToList();
        }

        public IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre)
        {
            return comunRegistro.ObtenerListaUgelesPorDre(codDre).ToList();
        }

        public EOpcionesJurisdiccionInvolucradas ObtenerOpcionesJurisdiccionInvolucradas(EParametrosRegistroRequest parRegistrorequest)
        {
            return comunRegistro.ObtenerOpcionesJurisdiccionInvolucradas(parRegistrorequest);
        }

        public EOpcionesRegistro ObtenerOpcionesRegistro(EOpcionesRequest eOpcionesRequest)
        {
            return comunRegistro.ObtenerOpcionesRegistro(eOpcionesRequest);
        }

        public EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre)
        {
            return comunRegistro.ObtenerOpcionesUbigeo(IdDre);
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito)
        {
            return comunRegistro.ObtenerCCPPPorDistrito(distrito).ToList();
        }

        public ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest)
        {
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"]; // ver por que qui no llee los setting del webConfig
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];

            //Luego quitar esto dark
            string rutaBase = @"C:\Users\anica\source\repos\ProyectoRendugel\SolucionRendugel\Rendugel.Servicios.Host\documentos\";

            //ResponseService responseService2 = new ResponseService();

            //responseService2.MensajePrincipal = "Probando respuesta";
            //responseService2.idRegistro = 0;
            //responseService2.ResultValid = true;

            //return responseService2;
            return comunRegistro.SaveRegistroProvisional(eRegistroRequest, rutaBase);
        }

        public ResponseService SuspenderRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest)
        {
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"]; // ver por que qui no llee los setting del webConfig
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];

            //Luego quitar esto dark
            string rutaBase = @"C:\Users\anica\source\repos\ProyectoRendugel\SolucionRendugel\Rendugel.Servicios.Host\documentos\";

            //ResponseService responseService2 = new ResponseService();

            //responseService2.MensajePrincipal = "Probando respuesta";
            //responseService2.idRegistro = 0;
            //responseService2.ResultValid = true;

            //return responseService2;
            return comunRegistro.SuspCanRegistroProvisional(eRegistroSuspensionRequest, rutaBase, 1);
        }

        public ResponseService CancelarRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest)
        {
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"]; // ver por que qui no llee los setting del webConfig
            //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];

            //Luego quitar esto dark
            string rutaBase = @"C:\Users\anica\source\repos\ProyectoRendugel\SolucionRendugel\Rendugel.Servicios.Host\documentos\";

            //ResponseService responseService2 = new ResponseService();

            //responseService2.MensajePrincipal = "Probando respuesta";
            //responseService2.idRegistro = 0;
            //responseService2.ResultValid = true;

            //return responseService2;
            return comunRegistro.SuspCanRegistroProvisional(eRegistroSuspensionRequest, rutaBase, 2);
        }

        public ListasComponentesResponse ObtenerListasComponentes()
        {
            return comunRegistro.ObtenerListasComponentes();
        }

        public ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension()
        {
            return comunRegistro.ObtenerListasComponentesSuspension();
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales()
        {
            return comunRegistro.ObtenerRegistrosProvisionales();
        }

        public RegistrosProvisionalesResponse ObtenerRegistrosProvisionales2()
        {

            RegistrosProvisionalesResponse resp = new RegistrosProvisionalesResponse();
            resp.ListaRegistroBandeja = comunRegistro.ObtenerRegistrosProvisionales().ToList();
            return resp;
        }

        public IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro)
        {
            return comunRegistro.ObtenerRegistroDetallePorIdRegistro(idRegistro).ToList();
        }

        public IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel)
        {
            return comunRegistro.ObtenerJurisdiccionUgelPorListaUgeles(listaUgel);
        }

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel)
        {
            return comunRegistro.ObtenerJurisdiccionUgelPorIdUgel(IdUgel);
        }

        public ResponseService pasarADefinitivo(ERegistroDefinitivo registroDefinitivo)
        {
            return comunRegistro.pasarADefinitivo(registroDefinitivo);
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(EOpcionesBandejaRequest opcionesBandejaRequest)
        {
            return comunRegistro.ObtenerRegistrosProvisionalesPoTipoEstado(opcionesBandejaRequest.listaTipoRegistro, opcionesBandejaRequest.listaEstadoRegistro);
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja)
        {
            return comunRegistro.ObtenerRegistrosPorBandeja(bandeja);
        }

        public ResponseService ElimarRegistro(int idRegistro)
        {
            return comunRegistro.ElimarRegistro(idRegistro);
        }

        public IList<EIged> ObtenerListaUgelesInvolucradasPorUgel(EIged ugel)
        {
            return comunRegistro.ObtenerListaUgelesInvolucradasPorUgel(ugel).ToList();
        }

        public List<EBandeja> ObtenerBandejas()
        {
            ConfiguracionAplicacion configuracionAplicacion = new ConfiguracionAplicacion();
            return configuracionAplicacion.ObtenerBandejas();
        }
    }
}
