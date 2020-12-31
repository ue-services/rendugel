using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Aplicacion.Interfaces;
using Rendugel.Transversal.Entidades;
using Rendugel.Dominio;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Rendugel.Dominio.Entidades.Modelo;
using System.Configuration;
using System.IO;
using Rendugel.Transversal.Entidades.Response;
using Rendugel.Transversal.Entidades.Entidades;

namespace Rendugel.Aplicacion.Registro
{
    public class ComunRegistro : IComunRegistro
    {
        readonly ComunRegistroRepositorio comunRegistroRepositorio = new ComunRegistroRepositorio();

        public UploadTempResponse GrabarDatosDocumentoTemporal(EDocumentoTem eDocumentoTem)
        {
            return comunRegistroRepositorio.GrabarDatosDocumentoTemporal(eDocumentoTem);
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito)
        {
            var listaCPP = comunRegistroRepositorio.ObtenerCCPPPorDistrito(distrito);
            return listaCPP.ToList();
        }

        public List<EIged> ObtenerDre()
        {
            var listaDre = comunRegistroRepositorio.ObtenerListaCDIgedPorCodTipoIged(1);
            return listaDre.ToList();
        }

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel)
        {
            //Procesar la liusta de jurisdicción para completarla y obtener el enunciado por cada una de ellas.
            Complementarias managerJurisdiccion = new Complementarias();
            List<EJurisdiccion> jurisdiccionUgel = new List<EJurisdiccion>();

            jurisdiccionUgel = comunRegistroRepositorio.ObtenerJurisdiccionUgelPorIdUgel(IdUgel).ToList();

            foreach (EJurisdiccion jurisdiccion in jurisdiccionUgel)
                { managerJurisdiccion.GenerarEnunciadoJurisdiccion(jurisdiccion);}
            
            return jurisdiccionUgel;
        }

        public IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel)
        {
            //Procesar la liusta de jurisdicción para completarla y obtener el enunciado por cada una de ellas.
            Complementarias managerJurisdiccion = new Complementarias();

            List<IgedJurisdiccionResponse> listaIgedJurisdiccionResponse = new List<IgedJurisdiccionResponse>();

            listaIgedJurisdiccionResponse = comunRegistroRepositorio.ObtenerJurisdiccionUgelPorListaUgeles(listaUgel).ToList();

            foreach (IgedJurisdiccionResponse igedJurisdiccionResponse in listaIgedJurisdiccionResponse)
            {
                foreach(EJurisdiccion jurisdiccion in igedJurisdiccionResponse.JurisdiccionUgel)
                {
                    managerJurisdiccion.GenerarEnunciadoJurisdiccion(jurisdiccion);
                }
            }
            //var item = managerJurisdiccion.ObtenerJurisdiccionUgelPorListaUgeles(listaUgel);           

            return listaIgedJurisdiccionResponse;
        }

        public IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento()
        {
            return comunRegistroRepositorio.ObtenerListaCDTipoDocumento().ToList();
        }

        public ListasComponentesResponse ObtenerListasComponentes()
        {
            return comunRegistroRepositorio.ObtenerListasComponentes();
        }

        public ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension()
        {
            return comunRegistroRepositorio.ObtenerListasComponentesSuspension();
        }

        public IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre)
        {
            return comunRegistroRepositorio.ObtenerListaUgelesPorDre(codDre).ToList();
        }

        public IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(EIged ugel)
        {
            return comunRegistroRepositorio.ObtenerListaUgelesInvolucradasPorUgel(ugel.IdIged ?? default(int)).ToList();
        }

        public EOpcionesJurisdiccionInvolucradas ObtenerOpcionesJurisdiccionInvolucradas(EParametrosRegistroRequest parRegistrorequest)
        {
            EOpcionesJurisdiccionInvolucradas respuesta = new EOpcionesJurisdiccionInvolucradas();

            var listaUgel = comunRegistroRepositorio.ObtenerListaUgelesInvolucradas(parRegistrorequest.dre.IdIged ?? default(int), parRegistrorequest.ugel.IdIged ?? default(int));
            var listaEventos = comunRegistroRepositorio.ObtenerEventosColaterales(parRegistrorequest.eventoRegistral.CodEvento ?? default(int));

            var listaNaturaleza = (from a in listaEventos
                                   select new ENaturaleza
                                   {
                                       IdNaturaleza = a.Naturaleza.IdNaturaleza,
                                       CodNaturaleza = a.Naturaleza.CodNaturaleza,
                                       DescNaturaleza = a.Naturaleza.DescNaturaleza
                                   }).Distinct();

            respuesta.ListaUgel = listaUgel.ToList();
            respuesta.ListaEventoRegistralC = listaEventos.ToList();
            respuesta.ListaNaturalezaC = listaNaturaleza.ToList();

            return respuesta;
        }

        public EOpcionesJurisdiccionPertenencia ObtenerOpcionesJurisdiccionPertenencia(EPertenenciaRequest ePertenenciaRequest)
        {
            EOpcionesJurisdiccionPertenencia eOpcionesJurisdiccionPertenencia = new EOpcionesJurisdiccionPertenencia();
            IEnumerable<EJurisdiccion> jurisdiccionUgeles = null;
            IEnumerable<int> IdProvinciasAsignadas;

            var region = comunRegistroRepositorio.ObtenerRegionPorDre(ePertenenciaRequest.dre.IdIged ?? default(int));
            var provinciasPorRegion = comunRegistroRepositorio.ObtenerProvinciasPorRegion(region.CodUbigeo);
            jurisdiccionUgeles = comunRegistroRepositorio.ObtenerJurisdiccionDeUgelesPorDre(ePertenenciaRequest.dre.IdIged ?? default(int));

            // PROVINCIAS ------------------------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------------------------------
            IdProvinciasAsignadas = (from a in jurisdiccionUgeles
                                     where a.Ubigeo.TipoUbigeo.CodTipoUbigeo == 2 //Provincias (Aqui crear numeral) 
                                      & a.CodTerminoPertenencia == 1 //COMPRENDE (Aqui va numeral
                                     select a.Ubigeo.IdUbigeo).ToList();


            // Lista de provincias no asignadas con el termino "Comprende"
            var varp1_provinciasNoAsignadasComprende = (from a in provinciasPorRegion
                                                        where !IdProvinciasAsignadas.Contains(a.IdUbigeo)
                                                        select a).ToList();

            // Obtener todos los distritos de las provincias no asignadas.
            var varp2_distritosNoAsignadosDeVar1 = comunRegistroRepositorio.ObtenerDistritosPorListaProvincias(varp1_provinciasNoAsignadasComprende);

            //Obtener todos los CCPP de los distritos de las provincias no asignadas.
            //var varp3_ccppNoAsignadosDeVar2 = comunRegistroRepositorio.ObtenerCCPPPorListaDistrito(varp2_distritosNoAsignadosDeVar1.ToList());


            //DISTRITOS -----------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------

            //Distrito asignados con comprende e incluye, se tiene que restar del total de distritos y tambien restar sus centros poblados del total de centros poblados.
            var vard1_distritosAsignados = (from a in jurisdiccionUgeles
                                            where a.Ubigeo.TipoUbigeo.CodTipoUbigeo == 3 //Distritos (Aqui crear numeral) 
                                             & (a.CodTerminoPertenencia == 1 || a.CodTerminoPertenencia == 2) //COMPRENDE O INCLUYE (Aqui va numeral
                                            select new EDistrito { IdUbigeo = a.Ubigeo.IdUbigeo }
                                    ).ToList();


            // Obtener ID de los distritos excluidos
            var idDistritosExcluidos = (from a in jurisdiccionUgeles
                                        where a.Ubigeo.TipoUbigeo.CodTipoUbigeo == 3 //Distritos (Aqui crear numeral) 
                                         & a.CodTerminoPertenencia == 3 //EXCLUYE (Aqui va numeral)
                                        select new EDistrito { IdUbigeo = a.Ubigeo.IdUbigeo }
                                     ).ToList();


            //Obtener distritos excluidos, se tienen que sumar al total de distritos y tambien sumar sus provincias y sus centros poblados.
            IEnumerable<EDistrito> vard2_distritosExcluidos = null;
            IEnumerable<EProvincia> vard3_provinciasDeVard2 = null;
            if (idDistritosExcluidos.Count > 0)
            {
                vard2_distritosExcluidos = comunRegistroRepositorio.ObtenerDistritosPorListaIdDistritos(idDistritosExcluidos);

                // Obtener las provincias de los distritos excluidos. Sumar al total de provincias no asignadas. 
                vard3_provinciasDeVard2 = (from a in vard2_distritosExcluidos
                                           select a.Provincia
                                         ).Distinct().ToList();
            }

            List<EDistrito> vard4_distritosNoAsignados = null;
            // varp2_distritosNoAsignadosDeVar1  - vard1_distritosAsignados + vard2_distritosExcluidos
            if (vard1_distritosAsignados.Count > 0)
            {
                vard4_distritosNoAsignados = ((from a in varp2_distritosNoAsignadosDeVar1
                                               where !(from b in vard1_distritosAsignados select b.IdUbigeo).Contains(a.IdUbigeo)
                                               select a).ToList()).Union(vard2_distritosExcluidos).ToList();
            }
            else vard4_distritosNoAsignados = (from a in varp2_distritosNoAsignadosDeVar1
                                               where !(from b in vard1_distritosAsignados select b.IdUbigeo).Contains(a.IdUbigeo)
                                               select a).ToList();
            //CENTROS POBLADOS ----------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------------
            //Obtener todos los CCPP de vard4_distritosNoAsignados
            var varc1_ccppNoAsignadosDeVard4 = comunRegistroRepositorio.ObtenerCCPPPorListaDistrito(vard4_distritosNoAsignados);

            //CCPP asignados con comprende e incluye, se tiene que restar del total de distritos y tambien restar sus centros poblados del total de centros poblados.
            var varc2_CCPPAsignados = (from a in jurisdiccionUgeles
                                       where a.Ubigeo.TipoUbigeo.CodTipoUbigeo == 4 //CCPP (Aqui crear numeral) 
                                        & (a.CodTerminoPertenencia == 1 || a.CodTerminoPertenencia == 2) //COMPRENDE O INCLUYE (Aqui va numeral)
                                       select new ECentroPoblado { IdUbigeo = a.Ubigeo.IdUbigeo }
                                    ).ToList();

            // Obtener ID de los CCPP excluidos            
            var idCCPPExcluidos = (from a in jurisdiccionUgeles
                                   where a.Ubigeo.TipoUbigeo.CodTipoUbigeo == 4 //Distritos (Aqui crear numeral) 
                                    & a.CodTerminoPertenencia == 3 //EXCLUYE (Aqui va numeral)
                                   select new ECentroPoblado { IdUbigeo = a.Ubigeo.IdUbigeo }
                                     ).ToList();

            //Obtener distritos excluidos, se tienen que sumar al total de distritos y tambien sumar sus provincias y sus centros poblados.
            IEnumerable<ECentroPoblado> varc3_CCPPExcluidos = null;
            IEnumerable<EDistrito> varc4_distritosDeVard3 = null;

            if (idCCPPExcluidos.Count > 0)
            {
                varc3_CCPPExcluidos = comunRegistroRepositorio.ObtenerCCPPPorListaCCPP(idCCPPExcluidos).ToList();

                // Obtener las provincias de los distritos excluidos. Sumar al total de provincias no asignadas. 
                varc4_distritosDeVard3 = (from a in varc3_CCPPExcluidos
                                          select a.Distrito
                                         ).Distinct().ToList();
            }

            // varc1_ccppNoAsignadosDeVard4  - varc2_CCPPAsignados + varc3_CCPPExcluidos
            var varc5_CCPPNoAsignados = ((from a in varc1_ccppNoAsignadosDeVard4
                                          where !(from b in varc2_CCPPAsignados select b.IdUbigeo).Contains(a.IdUbigeo)
                                          select a).ToList()).Union(varc3_CCPPExcluidos).ToList();

            var provinciasNoAsignadas = varp1_provinciasNoAsignadasComprende.Union(vard3_provinciasDeVard2).ToList();
            var distritosNoAsignados = vard4_distritosNoAsignados.Union(varc4_distritosDeVard3).ToList();
            var centrosPobladosNoAsignados = varc5_CCPPNoAsignados;

            eOpcionesJurisdiccionPertenencia.Region = region;
            eOpcionesJurisdiccionPertenencia.ListaProvincias = provinciasNoAsignadas;
            eOpcionesJurisdiccionPertenencia.ListaDistritos = distritosNoAsignados;
            eOpcionesJurisdiccionPertenencia.ListaCentroPoblado = centrosPobladosNoAsignados;

            return eOpcionesJurisdiccionPertenencia;
        }

          public EOpcionesRegistro ObtenerOpcionesRegistro(EOpcionesRequest eOpcionesRequest)
        {
            EOpcionesRegistro eOpcionesRegistro = new EOpcionesRegistro();

            var codTipoDre = 1; // crear  numeradores
            var listaDre = comunRegistroRepositorio.ObtenerListaCDIgedPorCodTipoIged(codTipoDre);

            var resulEventoRegistral = comunRegistroRepositorio.ObtenerEventoRegistralPorConfiguracion(eOpcionesRequest.codTipoRegistro, eOpcionesRequest.codTipoIgedRegistrar);
            List<EEventoRegistral> listaEventoRegistral = new List<EEventoRegistral>();
            listaEventoRegistral = resulEventoRegistral.ToList();

            //var eventoRegistral = comunRegistroRepositorio.ObtenerCDEventoRegistralPorCodigo(eOpcionesRequest.codEventoRegistral);
            //List<EEventoRegistral> listaEventoRegistral = new List<EEventoRegistral>();
            //listaEventoRegistral.Add(eventoRegistral);

            //var naturalezaDA = comunRegistroRepositorio.ObtenerCDNaturalezaActoAdministrativoPorEvento(eOpcionesRequest.codEventoRegistral);
            List<ENaturaleza> listaNaturaleza = new List<ENaturaleza>();
            //listaNaturaleza.Add(naturalezaDA);

            if (listaEventoRegistral.Count > 0)
            {

                // Obtener las provincias de los distritos excluidos. Sumar al total de provincias no asignadas. 
                /*listaNaturaleza = (from a in listaEventoRegistral
                                   select a.Naturaleza
                                         ).Distinct().ToList();*/

                listaNaturaleza = (listaEventoRegistral.Select(x => x.Naturaleza).Distinct().ToList())
                                        .GroupBy(x => x.IdNaturaleza).Select(y =>y.First()).ToList();
            }

            var tipoIged = comunRegistroRepositorio.ObtenerCDTipoIgedPorCodigo(eOpcionesRequest.codTipoIgedRegistrar);
            List<ETipoIged> listaTipoIged = new List<ETipoIged>();
            listaTipoIged.Add(tipoIged); 

            var tipoRegistro = comunRegistroRepositorio.ObtenerCDTipoRegistroPorCodigo(eOpcionesRequest.codTipoRegistro);
            List<ETipoRegistro> listaTipoRegistro = new List<ETipoRegistro>();
            listaTipoRegistro.Add(tipoRegistro);

            eOpcionesRegistro.ListaDRE = listaDre.ToList();
            eOpcionesRegistro.ListaEventoRegistral= listaEventoRegistral;
            eOpcionesRegistro.ListaNaturaleza= listaNaturaleza;
            eOpcionesRegistro.ListaTipoIged = listaTipoIged;
            eOpcionesRegistro.ListaTipoRegistro = listaTipoRegistro;

            return eOpcionesRegistro;
        }

        public EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre)
        {
            EOpcionesUbigeo eOpcionesUbigeo = new EOpcionesUbigeo();

            var region = comunRegistroRepositorio.ObtenerRegionPorDre(int.Parse(IdDre)); 
            var listaProvincias = comunRegistroRepositorio.ObtenerProvinciasPorRegion(region.CodUbigeo);
            var listaDistritos = comunRegistroRepositorio.ObtenerDistritosPorRegion(region.CodUbigeo); //Posiblemente este no vaya, ya que los distritos deberian cargar al seleccionar provincia.

            eOpcionesUbigeo.Region = region;
            eOpcionesUbigeo.ListaProvincias = listaProvincias.ToList();
            eOpcionesUbigeo.ListaDistritos = listaDistritos.ToList();

            return eOpcionesUbigeo;
        }

        public IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro)
        {
            return comunRegistroRepositorio.ObtenerRegistroDetallePorIdRegistro(idRegistro);
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales()
        {
            return comunRegistroRepositorio.ObtenerRegistrosProvisionales();
        }

        public ResponseService pasarADefinitivo(ERegistroDefinitivo registroDefinitivo)
        {
            //ResponseService responseService = new ResponseService();
            //responseService.MensajePrincipal = "Los datos llegaron correctamente:" ;
            //return responseService;
            return comunRegistroRepositorio.pasarADefinitivo(registroDefinitivo);
        }

        public ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest, string rutaBase)
        {
            //*****PASAR ARCHIVO DE TEMPORAL A RESOLUTIVO


            Documento _documento = new Documento();
            _documento.IdDocumento = 0;
            _documento.EsActivo = true;
            _documento.EsBorrado = false;            

            EDocumento documento = new EDocumento();            

            eRegistroRequest.DocumentoResolutivo.IdDocumento = comunRegistroRepositorio.saveDocumento(_documento);

            documento = this.pasarFileDeTemporal(eRegistroRequest.DocumentoResolutivo, rutaBase, "Resolutivos"); // "Resolutivo ponerlo en el config y traerlo desde alli."
            //eRegistroRequest.DocumentoResolutivo = documento;

            //ResponseService responseService2 = new ResponseService();

            //responseService2.MensajePrincipal = "Probando respuesta pasarDeTemporal";
            //responseService2.idRegistro = 0;
            //responseService2.ResultValid = true;

            //return responseService2;

            return comunRegistroRepositorio.SaveRegistroProvisional(eRegistroRequest);
        }

        //** NO EN INTERFACE
        public EDocumento pasarFileDeTemporal(EDocumento documento, string rutaBase, string dir) {
            //Documento _doc = new Documento();
            DocumentoTem _docTem = new DocumentoTem();
            int IdDocumentoTem = 0;

            //documento.NombreArchivo = "";
            //documento.Ruta = "";

            if (documento.Temporal != null && documento.Temporal.IdDocumentoTem > 0)
            {
                //_doc = comunRegistroRepositorio.ObtenerDocumentoPorId(documento.IdDocumento);
                IdDocumentoTem = documento.Temporal.IdDocumentoTem;
                _docTem = comunRegistroRepositorio.ObtenerDocumentoTemPorId(IdDocumentoTem); 
                        

                //string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];
                var path1 = Path.Combine(rutaBase, dir); //Resolutivos
                string nombreArchivo = documento.NroDocumento + "_" + documento.IdDocumento.ToString() + ".pdf"; //Resolutivo
                var fullPath1 = Path.Combine(path1, nombreArchivo); //Resolutivos

                var path2 = Path.Combine(rutaBase, _docTem.Ruta); //Temporal
                var fullPath2 = Path.Combine(path2, _docTem.NombreArchivo); //Temporal

                    //var fileStream1 = new FileStream(fullPath1, FileMode.Create, FileAccess.Write);
                    //var fileStream2 = new FileStream(fullPath2, FileMode.Open, FileAccess.Read);
            
                try
                {
                    ////Si existe un resolutivo con el mismo nombre, eliminarlo, luego copiar.
                   if (File.Exists(fullPath1))
                    {
                        FileInfo fi1 = new FileInfo(fullPath1);
                        fi1.Delete();
                   }

                    System.IO.File.Move(fullPath2, fullPath1);

                   // //fileStream2.Seek(0, SeekOrigin.Begin);
                   // //fileStream2.CopyTo(fileStream1);
                   // //fileStream1.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed...: {0}", e.ToString());
                }
                finally { }

            documento.NombreArchivo = nombreArchivo;
            documento.Ruta = dir;
            }

            return documento;

        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro)
        {
            return comunRegistroRepositorio.ObtenerRegistrosProvisionalesPoTipoEstado(listTipoRegistro, listEstadoRegistro);
        }

        public ResponseService ElimarRegistro(int idRegistro)
        {
            return comunRegistroRepositorio.ElimarRegistro(idRegistro);
        }

        public ResponseService SuspCanRegistroProvisional(ERegistroSuspensionRequest eRegistroSuspensionRequest, string rutaBase, int codSuspCanc)
        {
            Documento _documento = new Documento();
            _documento.IdDocumento = 0;
            _documento.EsActivo = true;
            _documento.EsBorrado = false;

            EDocumento documento = new EDocumento();
            String carpeta = "";
            if (codSuspCanc == 1)
            {
                carpeta = "Suspension";
            }
            else
            {
                if (codSuspCanc == 2)
                {
                    carpeta = "Cancelacion";
                }
            }

            if (eRegistroSuspensionRequest.DocumentoDeSustento != null && eRegistroSuspensionRequest.DocumentoDeSustento.Temporal != null && eRegistroSuspensionRequest.DocumentoDeSustento.Temporal.IdDocumentoTem>0)
            {
                eRegistroSuspensionRequest.DocumentoDeSustento.IdDocumento = comunRegistroRepositorio.saveDocumento(_documento);
                documento = this.pasarFileDeTemporal(eRegistroSuspensionRequest.DocumentoDeSustento, rutaBase, carpeta); // "Resolutivo ponerlo en el config y traerlo desde alli."
            //eRegistroRequest.DocumentoResolutivo = documento;
            }            

            return comunRegistroRepositorio.SuspCanRegistroProvisional(eRegistroSuspensionRequest, codSuspCanc);
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja)
        {
            return comunRegistroRepositorio.ObtenerRegistrosPorBandeja(bandeja);
        }
    }
}
