using Rendugel.Datos.Repositorio;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Dominio.Interfaces;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using Rendugel.Transversal.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio
{
    public class ComunRegistroRepositorio : IComunRegistroRepositorio
    {
        public int ActualizarRegistrosDeJurisdiccion(List<JurisdiccionIged> listaJurisdiccion, List<EIged> listaIged)
        {
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();         
            var item = managerJurisdiccion.ActualizarRegistrosDeJurisdiccion(listaJurisdiccion, listaIged);
            return item;
        }

        public ResponseService ElimarRegistro(int idRegistro)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            return managerRegistro.elimarRegistro(idRegistro);

        }

        public UploadTempResponse GrabarDatosDocumentoTemporal(EDocumentoTem eDocumentoTem)
        {
            UploadTempResponse uploadTempResponse = new UploadTempResponse();
            //ManagerDocumento managerDocumento = new ManagerDocumento();
            ManagerDocumentoTem managerDocumentoTem = new ManagerDocumentoTem();

            //Documento documento = new Documento();
            DocumentoTem documentoTem = new DocumentoTem();

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            documentoTem.EsActivo = true;
            documentoTem.EsBorrado = false;
            documentoTem.FechaCreacion = fechaHoy;
            documentoTem.UsuCreacion = usuario;
            documentoTem.Ruta = eDocumentoTem.Ruta;
            documentoTem.NombreArchivo = eDocumentoTem.NombreArchivo;
            documentoTem.Finalidad = eDocumentoTem.Finalidad;

            //documentoTem.Temporal = true; 
            if (eDocumentoTem.IdDocumentoTem > 0)
            {
                //return eDocumento;  
                try
                {
                    documentoTem.IdDocumentoTem = eDocumentoTem.IdDocumentoTem;
                    managerDocumentoTem.updateDocumento(documentoTem);   
                }
                catch (Exception e)
                {
                    uploadTempResponse.result = false;
                    uploadTempResponse.message = e.Message.ToString() + "Error al actualizar";
                    uploadTempResponse.data = null;
                    return uploadTempResponse;
                }                             
            }
            else
            {  
                try
                {
                    //Si existe un registro en DocumentoTem con ese usuario y esa finalidad.
                    var r = managerDocumentoTem.ObtenerDocumentoPorUsurioFinalidad(usuario, eDocumentoTem.Finalidad);

                    if (r != null) //Si es asi => reemplazar con los nuevos datos y actualizar
                    {
                        documentoTem.IdDocumentoTem = r.IdDocumentoTem;
                        managerDocumentoTem.updateDocumento(documentoTem);
                        eDocumentoTem.IdDocumentoTem = documentoTem.IdDocumentoTem;
                    }
                    else //Si no es asi, crear. 
                    {
                        documentoTem.IdDocumentoTem = 0;
                        eDocumentoTem.IdDocumentoTem = managerDocumentoTem.saveDocumento(documentoTem);
                    }

                }
                catch (Exception e)
                {
                    uploadTempResponse.result = false;
                    uploadTempResponse.message = e.Message.ToString() + "Error al obtener el registro temporal activo por usuario y finalida";
                    uploadTempResponse.data = null;
                    return uploadTempResponse;
                }              
            }

            uploadTempResponse.result = true;
            uploadTempResponse.message = "OK";
            uploadTempResponse.data = eDocumentoTem;

            return uploadTempResponse;
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerCCPPPorDistrito(distrito).ToList();
            return item;
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorListaCCPP(List<ECentroPoblado> listaCCPP)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerCCPPPorListaCCPP(listaCCPP);
            return item;
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorListaDistrito(List<EDistrito> listaDistritos)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerCCPPPorListaDistrito(listaDistritos);
            return item;
        }

        public EEventoRegistral ObtenerCDEventoRegistralPorCodigo(int codEvento)
        {
            ManagerEventoRegistral managerEventoRegistral = new ManagerEventoRegistral();
            var item = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(codEvento);
            return item;
        }

        public ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorCodigo(int codNaturaleza)
        {
            ManagerNaturaleza managerNaturaleza = new ManagerNaturaleza();
            return managerNaturaleza.ObtenerCDNaturalezaActoAdministrativoPorCodigo(codNaturaleza);
        }

        public ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorEvento(int codEvento)
        {
            ManagerNaturaleza managerNaturaleza = new ManagerNaturaleza();
            return managerNaturaleza.ObtenerCDNaturalezaActoAdministrativoPorEvento(codEvento);
        }

        public ETipoDocumento ObtenerCDTipoDocumentoPorCodigo(int codTipoDoc)
        {
            ManagerTipoDocumento managerTipoDocumento = new ManagerTipoDocumento();
            return managerTipoDocumento.ObtenerCDTipoDocumentoPorCodigo(codTipoDoc);
        }

        public ETipoIged ObtenerCDTipoIgedPorCodigo(int codTipoIged)
        {
            ManagerTipoIged managerTipoIged = new ManagerTipoIged();
            return managerTipoIged.ObtenerCDTipoIgedPorCodigo(codTipoIged);
        }

        public ETipoRegistro ObtenerCDTipoRegistroPorCodigo(int codTipoRegistro)
        {
            ManagerTipoRegistro managerTipoRegistro = new ManagerTipoRegistro();
            return managerTipoRegistro.ObtenerCDTipoRegistroPorCodigo(codTipoRegistro);
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorListaIdDistritos(List<EDistrito> listaIdDistritos)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerDistritosPorListaIdDistritos(listaIdDistritos);
            return item;
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorListaProvincias(List<EProvincia> listaProvincias)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerDistritosPorListaProvincias(listaProvincias);
            return item;
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorProvincia(string codUbigeoProvincia)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerDistritosPorProvincia(codUbigeoProvincia);
            return item;
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorRegion(string codUbigeoRegion)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerDistritosPorRegion(codUbigeoRegion);
            return item;
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorRegionNoIncluidosEnLasProvincias(string codUbigeoRegion, List<EProvincia> listaProvincias)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerDistritosPorRegionNoIncluidosEnLasProvincias(codUbigeoRegion, listaProvincias);
            return item;
        }

        public Documento ObtenerDocumentoPorId(int idDocumento)
        {
            ManagerDocumento managerDocumento = new ManagerDocumento();
            var item = managerDocumento.ObtenerDocumentoPorId(idDocumento);
            return item;
        }

        public IEnumerable<EEventoRegistral> ObtenerEventoRegistralPorConfiguracion(int codTipoRegistro, int codTipoIGED)
        {
            ManagerEventoRegistral managerEventoRegistral = new ManagerEventoRegistral();
            var item = managerEventoRegistral.ObtenerEventoRegistralPorConfiguracion(codTipoRegistro, codTipoIGED);
            return item;
        }

        public IEnumerable<EEventoRegistral> ObtenerEventosColaterales(int codEvento)
        {
            ManagerEventoRegistral managerEventoRegistral = new ManagerEventoRegistral();
            var item = managerEventoRegistral.ObtenerEventosColaterales(codEvento);
            return item;
        }

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionDeUgelesPorDre(int IdDre)
        {
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            var item = managerJurisdiccion.ObtenerJurisdiccionDeUgelesPorDre(IdDre);
            return item;
        }

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel)
        {
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            var item = managerJurisdiccion.ObtenerJurisdiccionUgelPorIdUgel(IdUgel).ToList();
            return item;
        }

        public IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel)
        {
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            var item = managerJurisdiccion.ObtenerJurisdiccionUgelPorListaUgeles(listaUgel);
            return item.ToList();
        }

        public IEnumerable<EIged> ObtenerListaCDIgedPorCodTipoIged(int codTipoIged)
        {
            ManagerIged managerIged = new ManagerIged();
            var item = managerIged.ObtenerListaCDIgedPorCodTipoIged(codTipoIged);
            return item;
        }

        public IEnumerable<ETipoDocumento> ObtenerListaCDTipoDocumento()
        {
            ManagerTipoDocumento managerTipoDocumento = new ManagerTipoDocumento();
            return managerTipoDocumento.ObtenerListaCDTipoDocumento().ToList();
        }

        public ListasComponentesResponse ObtenerListasComponentes()
        {
            ManagerTipoPersonal managerTipoPersonal = new ManagerTipoPersonal();
            ManagerTipoLocal managerTipoLocal = new ManagerTipoLocal();
            ManagerTipoPropiedad managerTipoPropiedad = new ManagerTipoPropiedad();
            ManagerTipoMedioContacto managerTipoMedioContacto = new ManagerTipoMedioContacto();
            ManagerTipoDocumento managerTipoDocumento = new ManagerTipoDocumento();
            ManagerPliegoUnidadEjecutora managerPliegoUnidadEjecutora = new ManagerPliegoUnidadEjecutora();
            ManagerOrigenSuspCanc managerOrigenSuspCanc = new ManagerOrigenSuspCanc();
           

            ListasComponentesResponse resp = new ListasComponentesResponse();

            resp.TipoMedioCelular = null;
            resp.TipoMedioEmail = null;
            resp.TipoMedioTelefono = null;
            resp.TiposMedioDatosDirector = null;
            resp.TiposMedioDatosGenerales = null;

            resp.TipoPersonalDirector = null;
            resp.TiposPersonalDatosPersonal = null;

            resp.TiposLocal = null;

            resp.TiposPropiedad = null;

            resp.TiposDocumento = null;

            resp.PliegosUnidadEjecutora = null;

            int codTipoCelular = 1;
            int codTipoTelefono = 2;
            int codTipoEmail = 3;

            resp.TipoMedioCelular = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(codTipoCelular);
            resp.TipoMedioTelefono = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(codTipoTelefono);
            resp.TipoMedioEmail = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(codTipoEmail);
            resp.TiposMedioDatosDirector = managerTipoMedioContacto.ObtenerListaTiposMedioContactoDatosDirector().ToList();
            resp.TiposMedioDatosGenerales = managerTipoMedioContacto.ObtenerListaTiposMedioContactoDatosGenerales().ToList();

            int codTipoDirector = 1;
            resp.TipoPersonalDirector = managerTipoPersonal.ObtenerTipoPersonalPorCodigo(codTipoDirector);
            resp.TiposPersonalDatosPersonal = managerTipoPersonal.ObtenerListaTiposPersonalDatosPersonal().ToList();

            resp.TiposLocal = managerTipoLocal.ObtenerListaTiposLocal().ToList();
            resp.TiposPropiedad = managerTipoPropiedad.ObtenerListaTiposPropiedad().ToList();

            resp.TiposDocumento = managerTipoDocumento.ObtenerListaCDTipoDocumento().ToList();
            resp.PliegosUnidadEjecutora = managerPliegoUnidadEjecutora.ObtenerListaPliegoUnidadEjecutora().ToList();

            return resp;
        }

        public ListasComponentesSuspensionResponse ObtenerListasComponentesSuspension()
        {
            ManagerTipoDocumento managerTipoDocumento = new ManagerTipoDocumento();
            ManagerOrigenSuspCanc managerOrigenSuspCanc = new ManagerOrigenSuspCanc();

            ListasComponentesSuspensionResponse resp = new ListasComponentesSuspensionResponse();

            resp.TiposDocumento = null;
            resp.OrigenesSuspCanc = null;

            resp.TiposDocumento = managerTipoDocumento.ObtenerListaCDTipoDocumento().ToList();
            resp.OrigenesSuspCanc = managerOrigenSuspCanc.ObtenerListaOrigenSuspCanc().ToList();

            return resp;
        }

        public IEnumerable<EIged> ObtenerListaUgelesInvolucradas(int IdDre, int? IdUgel)
        {
            ManagerIged managerIged = new ManagerIged();
            var item = managerIged.ObtenerListaUgelesInvolucradas(IdDre, IdUgel?? default(int));
            return item;
        }

        public IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(int IdUgel)
        {
            ManagerIged managerIged = new ManagerIged();
            var item = managerIged.ObtenerListaUgelesInvolucradasPorUgel(IdUgel);
            return item;
        }

        public IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre)
        {
            ManagerIged managerIged = new ManagerIged();
            var item = managerIged.ObtenerListaUgelesPorDre(codDre).ToList();
            return item;
        }

        public IEnumerable<EProvincia> ObtenerProvinciasPorRegion(string codUbigeoRegion)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerProvinciasPorRegion(codUbigeoRegion);
            return item;
        }

        public ERegion ObtenerRegionPorDre(int IdDre)
        {
            ManagerUbigeo managerUbigeo = new ManagerUbigeo();
            var item = managerUbigeo.ObtenerRegionPorDre(IdDre);
            return item;
        }

        public IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            var resp = managerRegistro.ObtenerRegistroDetallePorIdRegistro(idRegistro);
            return resp.ToList();
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales()
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            var resp = managerRegistro.ObtenerRegistrosProvisionales();
            return resp;
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            var resp = managerRegistro.ObtenerRegistrosProvisionalesPoTipoEstado(listTipoRegistro, listEstadoRegistro);
            return resp;
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            var resp = managerRegistro.ObtenerRegistrosPorBandeja(bandeja);
            return resp;
        }

        public ResponseService pasarADefinitivo(ERegistroDefinitivo eRegistroDefinitivo)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            ManagerIgedRegistroDetalle managerIgedRegistroDetalle = new ManagerIgedRegistroDetalle();
            ManagerPersona managerPersona = new ManagerPersona();
            ManagerPersonal managerPersonal = new ManagerPersonal();
            ManagerTipoMedioContacto managerTipoMedioContacto = new ManagerTipoMedioContacto();
            ManagerIgedMedioContacto managerIgedMedioContacto = new ManagerIgedMedioContacto();
            ManagerPersonalMedioContacto managerPersonalMedioContacto = new ManagerPersonalMedioContacto();
            ManagerDocumento managerDocumento = new ManagerDocumento();
            ManagerDocumentoDirector managerDocumentoDirector = new ManagerDocumentoDirector();
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            ManagerTipoPersonal managerTipoPersonal = new ManagerTipoPersonal();
            ManagerDependenciaUnidadEjecutora managerDependenciaUnidadEjecutora = new ManagerDependenciaUnidadEjecutora();
            ManagerIgedBasicos managerIgedBasicos = new ManagerIgedBasicos();
            ManagerUnidadEjecutora managerUnidadEjecutora = new ManagerUnidadEjecutora();

            ResponseService responseService = new ResponseService();
            IgedBasicos igedBasicosNuevo = new IgedBasicos();

            int idRegistro = 0;
            //int idRegistroDefinitivo = 0;

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";
            int idIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
            idRegistro = eRegistroDefinitivo.IdRegistro;

            //crear el objeto igedBasico para su registro posterios
            igedBasicosNuevo.IdRegistro = idRegistro;
            igedBasicosNuevo.IdIged = idIged;
            igedBasicosNuevo.IdDre = eRegistroDefinitivo.RegistroDetallePrincipal.Dre.IdIged;
            igedBasicosNuevo.NomIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.NomIged;
            igedBasicosNuevo.IdUbigeo = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Ubigeo.IdUbigeo;
            igedBasicosNuevo.EsActivo = true;
            igedBasicosNuevo.EsBorrado = false;
            igedBasicosNuevo.FechaCreacion = fechaHoy;
            igedBasicosNuevo.UsuCreacion = usuario;
            //Actualizar al final.

            //Obtenemos el registro provisional a modificar
            Registro registroProvisional = new Registro();
            registroProvisional = managerRegistro._ObtenerRegistroPorId(idRegistro);

            try
            {
                Registro registroDefinitivo = new Registro();
                registroDefinitivo = registroProvisional;
                registroDefinitivo.IdTipoRegistro = 2; //DEFINITIVO
                registroDefinitivo.IdEstadoRegistro = 7; //ASENTADO
                registroDefinitivo.UsuActualizacion = usuario;
                registroDefinitivo.FechaActualizacion = fechaHoy;
                //Actualizar al final.

                //INSERTAR DETALLE PRINCIPAL
                //EIgedRegistroDefinitivoDetalle registroDetallePrincipal = new EIgedRegistroDefinitivoDetalle();
                //registroDetallePrincipal = eRegistroDefinitivo.RegistroDetallePrincipal;

                //OBTENER EL DETALLE DE REGISTRO ORIGINAL POR ID_REGISTRO (Talvez tambien deberìa ser por Ugel)
                //IgedRegistroDetalle igedRegistroDetalle = new IgedRegistroDetalle();
                //igedRegistroDetalle = managerIgedRegistroDetalle.getIgedRegistroDetalleOrigenPorIdRegistro(idRegistro);

                //1. GUARDAR CONTACTOS DE IGED SI EXISTEN
                List<IgedMedioContacto> listaIgedMediosContacto = new List<IgedMedioContacto>();
                List<EMedioContacto> mediosContactoIged = new List<EMedioContacto>();
                mediosContactoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.MediosContactoIged.ToList();

                if (mediosContactoIged != null && mediosContactoIged.Count > 0)
                {
                    foreach (EMedioContacto medio in mediosContactoIged)
                    {
                        IgedMedioContacto igedMedioContacto = new IgedMedioContacto();

                        igedMedioContacto.IdTipoMedioContacto = medio.TipoMedioContacto.IdTipoMedioContacto;
                        igedMedioContacto.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                        igedMedioContacto.Medio = medio.Medio;
                        igedMedioContacto.Descripcion = medio.Descripcion;
                        igedMedioContacto.IdRegistro = idRegistro; // eRegistroDefinitivo.RegistroDetallePrincipal.IdIGEDRegistro;
                        igedMedioContacto.UsuCreacion = usuario;
                        igedMedioContacto.FechaCreacion = fechaHoy;
                        igedMedioContacto.EsActivo = true;
                        igedMedioContacto.EsBorrado = false;

                        listaIgedMediosContacto.Add(igedMedioContacto);
                        //Actualizar al final
                        //...
                    }
                }
                //.../

                List<PersonalMedioContacto> listaPersonalMedioContacto = new List<PersonalMedioContacto>();
                //2. GUARDAR DIRECTOR SI EXISTE
                EPersonalExtend director = new EPersonalExtend();
                director = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director;

                if (director != null && director.DniPersona != "")
                {
                    Persona persona = new Persona();
                    Personal personal = new Personal();

                    //2.1 SI EXISTE PERSONA CON EL MISMO DNI
                    // (para validaciones) SI ESTÁ VINCULADO A OTRO REGISTRO ACTIVO, ADVERTIR. Y NO HACER NADA.
                    // SI NO ESTÁ VINCULADO, ACTUALIZAR, SINO, CREAR.
                    string dni = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.DniPersona;
                    persona = managerPersona.getPersonaPorDNI(director.DniPersona);
                    int idPersona = 0;
                    if (persona is null)
                    {
                        persona.IdPersona = 0;
                        persona.NomPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.NomPersona;
                        persona.AppPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.AppPersona;
                        persona.ApmPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.ApmPersona;
                        persona.DniPersona = dni;
                        persona.UsuCreacion = usuario;
                        persona.FechaCreacion = fechaHoy;
                        persona.EsActivo = true;
                        persona.EsBorrado = false;

                        idPersona = managerPersona.savePersona(persona);
                    }
                    else
                    {
                        persona.NomPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.NomPersona;
                        persona.AppPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.AppPersona;
                        persona.ApmPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.ApmPersona;
                        persona.DniPersona = dni;
                        persona.UsuActualizacion = usuario;
                        persona.FechaActualizacion = fechaHoy;
                        persona.EsActivo = true;
                        persona.EsBorrado = false;

                        managerPersona.updatePersona(persona);
                        idPersona = persona.IdPersona;
                    }
                    //2.2. CREAR EL NUEVO REGISTRO DIRECTOR EN PERSONAL.
                    Personal personalNuevoDirector = new Personal();

                    personalNuevoDirector.IdPersona = idPersona;
                    personalNuevoDirector.IdIged = idIged;
                    personalNuevoDirector.IdRegistro = idRegistro;
                    personalNuevoDirector.IdTipoPersonal = managerTipoPersonal.ObtenerTipoPersonalPorCodigo(1).IdTipoPersonal; //1: director
                    personalNuevoDirector.UsuCreacion = usuario;
                    personalNuevoDirector.FechaCreacion = fechaHoy;
                    personalNuevoDirector.EsActivo = true;
                    personalNuevoDirector.EsBorrado = false;

                    int IdDirector = managerPersonal.savePersonal(personalNuevoDirector);

                    //2.3. SI EXISTEN LOS MEDIOS DE CONTACTO DEL DIRECTOR, GUARDAR MEDIOS DE CONTACTO.
                    //EPersonalMedioContactoB celular = new EPersonalMedioContactoB();
                    //EPersonalMedioContactoB telefono = new EPersonalMedioContactoB();
                    //EPersonalMedioContactoB email = new EPersonalMedioContactoB();

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio != "")
                    {
                        PersonalMedioContacto celular = new PersonalMedioContacto();
                        celular.IdTipoMedioContacto = 0;
                        celular.IdPersonal = IdDirector;
                        celular.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(1).IdTipoMedioContacto;//1: CELULAR deberia ser ENUMERADO
                        celular.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio;
                        celular.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Descripcion;
                        celular.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(celular);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(celular);
                    }

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio != "")
                    {
                        PersonalMedioContacto telefono = new PersonalMedioContacto();
                        telefono.IdTipoMedioContacto = 0;
                        telefono.IdPersonal = IdDirector;
                        telefono.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(2).IdTipoMedioContacto;//1: TELEFONO deberia ser ENUMERADO;
                        telefono.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio;
                        telefono.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Descripcion;
                        telefono.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(telefono);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(telefono);
                    }

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio != "")
                    {
                        PersonalMedioContacto email = new PersonalMedioContacto();
                        email.IdTipoMedioContacto = 0;
                        email.IdPersonal = IdDirector;
                        email.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(3).IdTipoMedioContacto;//1: WEB deberia ser ENUMERADO;
                        email.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio;
                        email.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Descripcion;
                        email.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(email);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(email);
                    }
                    //...

                    //2.4. GUARDAR EL DOCUMENTO QUE DESIGNA AL DIRECTOR.

                    //2.4.1. GUARDAR DOCUMENTO (TRANSACCION)
                    Documento documento = new Documento();
                    documento.IdDocumento = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.IdDocumento;
                    documento.IdClasificacionDoc = 1;
                    documento.IdTipoDoc = 1;
                    documento.NroDocumento = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.NroDocumento;
                    documento.NombreArchivo = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.NombreArchivo;
                    documento.Ruta = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.Ruta;
                    documento.FechaEmision = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.FechaEmision;
                    documento.FechaPublicacion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.FechaPublicacion;
                    documento.Temporal = false;
                    documento.FechaCreacion = fechaHoy;
                    documento.UsuCreacion = usuario;
                    documento.EsActivo = true;
                    documento.EsBorrado = false;

                    managerDocumento.updateDocumento(documento);

                    //2.4.2. GUARDAR EN DOCUMENTO_DIRECTOR (FICHA) CON EL ID_DOCUMENTO
                    DocumentoDirector documentoDirector = new DocumentoDirector();
                    documentoDirector.IdDocumentoDirector = 0;
                    documentoDirector.IdDocumento = documento.IdDocumento;
                    documentoDirector.IdPersonal = IdDirector;
                    documentoDirector.FechaCreacion = fechaHoy;
                    documentoDirector.UsuCreacion = usuario;
                    documentoDirector.EsActivo = true;
                    documentoDirector.EsBorrado = false;

                    managerDocumentoDirector.saveDocumentoDirector(documentoDirector);
                    //..
                }

                //3. GUARDAR UNIDAD EJECUTORA SI EXISTE                
                    // LA UNIDAD EJECUTORA
                    DependeciaUnidadEjecutora dependenciaUnidadEjecutoraAInactivar = new DependeciaUnidadEjecutora();
                    dependenciaUnidadEjecutoraAInactivar = managerDependenciaUnidadEjecutora.ObtenerDependenciaUnidadEjecutoraActivaPorIdUgel(idIged);

                    
                    igedBasicosNuevo.EsUeAutonoma = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.EsUeAutonoma;                   

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.EsUeAutonoma)
                    //9.2.1 SI ES UNIDAD AUTONOMA => CREAR LA ENTIDAD UE EN LA TABLA UNIDAD_EJECUTORA                    
                    {
                        int idUnidadEjecutora = 0;
                        UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

                        unidadEjecutora.IdPliegoUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.PliegoUnidadEjecutora.IdPliegoUnidadEjecutora;
                        unidadEjecutora.CodUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.CodUnidadEjecutora;
                        unidadEjecutora.DescUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.DescUnidadEjecutora;
                        unidadEjecutora.UsuCreacion = usuario;
                        unidadEjecutora.FechaActualizacion = fechaHoy;
                        unidadEjecutora.EsActivo = true;
                        unidadEjecutora.EsBorrado = false;

                        //9.2.1.1 CREAR EL VINCULO EN UGEL_BASICOS CON LOS DATOS DE LA UGEL COMO UE_AUTONOMA
                        idUnidadEjecutora = managerUnidadEjecutora.saveManagerUnidadEjecutora(unidadEjecutora);
                        //managerDependenciaUnidadEjecutora.DarBajaDependenciaUnidadEjecutora(dependenciaUnidadEjecutoraAInactivar.IdIgedEjecutora);
                        igedBasicosNuevo.IdUnidadEjecutora = idUnidadEjecutora;

                    }
                    //9.2.2 SI NO ES UNIDAD AUTÓNOMA => CREAR EL VINCULO CON LA UE DE LA QUE DEPENDE EN LA TABLA DEPENDENCIA_UNIDAD_EJECUTORA
                    else
                    {
                        DependeciaUnidadEjecutora dependenciaUnidadEjecutora = new DependeciaUnidadEjecutora();

                        dependenciaUnidadEjecutora.IdUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.IdUnidadEjecutora;
                        dependenciaUnidadEjecutora.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                        dependenciaUnidadEjecutora.IdRegistro = idRegistro;
                        dependenciaUnidadEjecutora.UsuCreacion = usuario;
                        dependenciaUnidadEjecutora.FechaActualizacion = fechaHoy;
                        dependenciaUnidadEjecutora.EsActivo = true;
                        dependenciaUnidadEjecutora.EsBorrado = false;

                        //managerDependenciaUnidadEjecutora.saveDependenciaUnidadEjecutora(dependenciaUnidadEjecutora);
                        managerDependenciaUnidadEjecutora.saveDependenciaUnidadEjecutora(dependenciaUnidadEjecutora);
                    }
                

                //4. GUARDAR LISTA DE PERSONAL
                List<EPersonalExtend> ListaPersonal = new List<EPersonalExtend>();
                ListaPersonal = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.PersonalIged.ToList();

                foreach (EPersonalExtend personalItem in ListaPersonal) 
                {
                    Persona _persona = new Persona();
                    Personal _personal = new Personal();
                    string dni = "";
                    dni = personalItem.DniPersona;
                    _persona = managerPersona.getPersonaPorDNI(dni);
                    //4.1 SI EXISTE PERSONA CON EL MISMO DNI
                    // (para validaciones) SI ESTÁ VINCULADO A OTRO REGISTRO ACTIVO, ADVERTIR. Y NO HACER NADA.
                    // SI NO ESTÁ VINCULADO, ACTUALIZAR, SINO, CREAR.
                    if (_persona is null)
                    {
                        _persona.IdPersona = 0;
                        _persona.NomPersona = personalItem.NomPersona;
                        _persona.AppPersona = personalItem.AppPersona;
                        _persona.ApmPersona = personalItem.ApmPersona;
                        _persona.DniPersona = dni;
                        _persona.UsuCreacion = usuario;
                        _persona.FechaCreacion = fechaHoy;
                        _persona.EsActivo = true;
                        _persona.EsBorrado = false;

                        _personal.IdPersona = managerPersona.savePersona(_persona);
                    }
                    else
                    {
                        _personal.IdPersona = _persona.IdPersona;
                    }

                    _personal.IdPersonal = 0;
                    _personal.IdTipoPersonal = personalItem.tipoPersonal.IdTipoPersonal;
                    _personal.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                    _personal.IdRegistro = idRegistro; // igedRegistroDetalle.IdIgedRegistro; //eRegistroDefinitivo.IdRegistro;
                    _personal.FechaCreacion = fechaHoy;
                    _personal.UsuCreacion = usuario;
                    _personal.EsActivo = true;
                    _personal.EsBorrado = false;

                    int _IdPersonal = managerPersonal.savePersonal(_personal);
                    //4.2. SI EXISTEN MEDIOS DE CONTACTO POR PERSONAL

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio != "")
                    {
                        PersonalMedioContacto _celular = new PersonalMedioContacto();
                        _celular.IdTipoMedioContacto = 0;
                        _celular.IdPersonal = _IdPersonal;
                        _celular.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(1).IdTipoMedioContacto;//1: CELULAR deberia ser ENUMERADO
                        _celular.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio;
                        _celular.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Descripcion;
                        _celular.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(_celular);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(celular);
                    }

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio != "")
                    {
                        PersonalMedioContacto _telefono = new PersonalMedioContacto();
                        _telefono.IdTipoMedioContacto = 0;
                        _telefono.IdPersonal = _IdPersonal;
                        _telefono.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(2).IdTipoMedioContacto;//1: TELEFONO deberia ser ENUMERADO;
                        _telefono.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio;
                        _telefono.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Descripcion;
                        _telefono.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(_telefono);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(telefono);
                    }

                    if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio != "")
                    {
                        PersonalMedioContacto _email = new PersonalMedioContacto();
                        _email.IdTipoMedioContacto = 0;
                        _email.IdPersonal = _IdPersonal;
                        _email.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(3).IdTipoMedioContacto;//1: WEB deberia ser ENUMERADO;
                        _email.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio;
                        _email.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Descripcion;
                        _email.IdRegistro = idRegistro;

                        listaPersonalMedioContacto.Add(_email);
                        //managerPersonalMedioContacto.SavePersonalMedioContacto(email);
                    }
                }

                //5. GUARDAR LOCALES
                List<ELocalIged> locales = new List<ELocalIged>();
                locales = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.localesIged.ToList();
                List<LocalIgel> listaLocalesIgel = new List<LocalIgel>();

                foreach(var localItem in locales)
                {
                    LocalIgel localIged = new LocalIgel();
                    localIged.IdIged = localItem.Iged.IdIged;
                    localIged.IdTipoLocal  = localItem.TipoLocal.IdTipoLocal;
                    localIged.DireccionLocal = localItem.DireccionLocal;
                    localIged.IdTipoPropiedad = localItem.TipoPropiedad.IdTipoPropiedad;
                    localIged.IdRegistro = idRegistro; 
                    localIged.UsuCreacion = usuario;
                    localIged.FechaCreacion = fechaHoy;
                    localIged.EsActivo = true;
                    localIged.EsBorrado = false;

                    listaLocalesIgel.Add(localIged);
                }

                //6. GUARDAR JURISDICCIONES
                List<EJurisdiccion> listaJurisdiccion = new List<EJurisdiccion>();
                listaJurisdiccion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.JurisdiccionUgel.ToList();

                List<JurisdiccionIged> listaJurisdiccionUgel = new List<JurisdiccionIged>();

                foreach (var jurisdiccion in listaJurisdiccion)
                {
                    JurisdiccionIged jurisdiccionIged = new JurisdiccionIged();
                    jurisdiccionIged.IdJurisdiccion = jurisdiccion.IdJurisdiccion;
                    jurisdiccionIged.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                    jurisdiccionIged.IdTerminoCantidad = jurisdiccion.TerminoCantidadJurisdiccion.IdTerminoCantidad;
                    jurisdiccionIged.IdTerminoPertenencia = jurisdiccion.TerminoPertenenciaJurisdiccion.IdTerminoPertenencia;
                    jurisdiccionIged.IdUbigeo = jurisdiccion.Ubigeo.IdUbigeo;
                    jurisdiccionIged.IdRegistro = idRegistro;  //igedRegistroDetalle.IdIgedRegistro;
                    jurisdiccionIged.UsuCreacion = usuario;
                    jurisdiccionIged.FechaCreacion = fechaHoy;
                    jurisdiccionIged.EsActivo = true;
                    jurisdiccionIged.EsBorrado = false;

                    listaJurisdiccionUgel.Add(jurisdiccionIged);
                }

                List<EIged> listaUgel = new List<EIged>();
                EIged eIged = new EIged();
                eIged.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                eIged.CodIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.CodIged;
                eIged.NomIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.NomIged;
                eIged.CodTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.CodTipoIged;
                eIged.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;

                listaUgel.Add(eIged);                

                //INSERTAR DETALLE DERIVADOS y JURISDICCION DE DERIVADOS
                List<JurisdiccionIged> listaJurisdiccionDerivadosActualizar = new List<JurisdiccionIged>();
                List<EIged> listaIgedDerivadosActualizar = new List<EIged>();

                foreach (EIgedRegistroDefinitivoDetalle item in eRegistroDefinitivo.RegistroDetalleDerivados)
                {
                    IgedRegistroDetalle igedRegistroDetalleDerivados = new IgedRegistroDetalle();

                    igedRegistroDetalleDerivados.EsActivo = true;
                    igedRegistroDetalleDerivados.EsBorrado = false;
                    igedRegistroDetalleDerivados.EsOrigen = false;
                    igedRegistroDetalleDerivados.FechaCreacion = fechaHoy;
                    igedRegistroDetalleDerivados.UsuCreacion = usuario;
                    igedRegistroDetalleDerivados.NomIged = item.ugel.NomIged;
                    igedRegistroDetalleDerivados.IdEventoRegistral = item.EventoRegistral.IdEventoRegistral;
                    igedRegistroDetalleDerivados.IdRegistro = idRegistro;
                    igedRegistroDetalleDerivados.IdIged = item.ugel.IdIged;

                    var idRegistroDetalle = managerIgedRegistroDetalle.saveIgedRegistroDetalle(igedRegistroDetalleDerivados);

                    EIged eIgedDerivada = new EIged();
                    eIgedDerivada.IdIged = item.ugel.IdIged;
                    eIgedDerivada.CodIged = item.ugel.CodIged;
                    eIgedDerivada.NomIged = item.ugel.NomIged;
                    eIgedDerivada.CodTipoIged = item.ugel.TipoIged.CodTipoIged;
                    eIgedDerivada.IdTipoIged = item.ugel.TipoIged.IdTipoIged;

                    listaIgedDerivadosActualizar.Add(eIgedDerivada);
                    //RECORRER JURISDICCIÓN
                    List<EJurisdiccion> listaJurisdiccionDerivados = new List<EJurisdiccion>();
                    listaJurisdiccionDerivados = item.ugel.JurisdiccionUgel.ToList();

                    foreach (var jurisdiccionDerivado in listaJurisdiccionDerivados)
                    {
                        JurisdiccionIged jurisdiccionDerivadoIged = new JurisdiccionIged();
                        jurisdiccionDerivadoIged.IdJurisdiccion = jurisdiccionDerivado.IdJurisdiccion;
                        jurisdiccionDerivadoIged.IdIged = item.ugel.IdIged;
                        jurisdiccionDerivadoIged.IdTerminoCantidad = jurisdiccionDerivado.TerminoCantidadJurisdiccion.IdTerminoCantidad;
                        jurisdiccionDerivadoIged.IdTerminoPertenencia = jurisdiccionDerivado.TerminoPertenenciaJurisdiccion.IdTerminoPertenencia;
                        jurisdiccionDerivadoIged.IdUbigeo = jurisdiccionDerivado.Ubigeo.IdUbigeo;
                        jurisdiccionDerivadoIged.IdRegistro = idRegistro; //igedRegistroDetalle.IdIgedRegistro;
                        jurisdiccionDerivadoIged.UsuCreacion = usuario;
                        jurisdiccionDerivadoIged.FechaCreacion = fechaHoy;
                        jurisdiccionDerivadoIged.EsActivo = true;
                        jurisdiccionDerivadoIged.EsBorrado = false;

                        listaJurisdiccionDerivadosActualizar.Add(jurisdiccionDerivadoIged);
                    }
                }

                managerRegistro.updateRegistro(registroDefinitivo);
                managerIgedBasicos.saveIgedBasicos(igedBasicosNuevo);
                managerIgedMedioContacto.saveListaIgedMedioContacto(listaIgedMediosContacto);
                managerPersonalMedioContacto.SaveListaPersonalMedioContacto(listaPersonalMedioContacto);
                //ELIMINAR LAS JURISDICCIONES QUE YA NO SON VALIDAS E INGRESAR LAS NUEVAS LINEAS DE JURISDICCION.
                managerJurisdiccion.ActualizarRegistrosDeJurisdiccion(listaJurisdiccionUgel, listaUgel);
                //ELIMINAR LAS JURISDICCIONES QUE YA NO SON VALIDAS E INGRESAR LAS NUEVAS LINEAS DE JURISDICCION.
                managerJurisdiccion.ActualizarRegistrosDeJurisdiccion(listaJurisdiccionDerivadosActualizar, listaIgedDerivadosActualizar);

                responseService.MensajePrincipal = "Actualizado correctamente";
                responseService.idRegistro = idRegistro;
                responseService.ResultValid = true;
            }
            catch (Exception e)
            {
                responseService.MensajePrincipal = e.Message;
                responseService.idRegistro = idRegistro;
                responseService.ResultValid = false;
            }
            return responseService;
            /*ManagerRegistro managerRegistro = new ManagerRegistro();
            var resp = managerRegistro.pasarADefinitivo(registroDefinitivoResponse);
            return resp;*/
        }

        public ResponseService modificacionSignificativa(EModificacionSignificativaRequest modificacionSignificativaRequest)
        {
            ResponseService responseService = new ResponseService();

            ManagerRegistro managerRegistro = new ManagerRegistro();
            ManagerIgedRegistroDetalle managerIgedRegistroDetalle = new ManagerIgedRegistroDetalle();
            ManagerPersona managerPersona = new ManagerPersona();
            ManagerPersonal managerPersonal = new ManagerPersonal();
            ManagerTipoMedioContacto managerTipoMedioContacto = new ManagerTipoMedioContacto();
            ManagerIgedMedioContacto managerIgedMedioContacto = new ManagerIgedMedioContacto();
            ManagerPersonalMedioContacto managerPersonalMedioContacto = new ManagerPersonalMedioContacto();
            ManagerDocumento managerDocumento = new ManagerDocumento();
            ManagerDocumentoRegistro managerDocumentoRegistro = new ManagerDocumentoRegistro();
            ManagerDocumentoDirector managerDocumentoDirector = new ManagerDocumentoDirector();
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            ManagerTipoRegistro managerTipoRegistro = new ManagerTipoRegistro();
            ManagerEstadoRegistro managerEstadoRegistro = new ManagerEstadoRegistro();
            ManagerClasificacionDocumento managerClasificacionDocumento = new ManagerClasificacionDocumento();
            ManagerEventoRegistral managerEventoRegistral = new ManagerEventoRegistral();
            ManagerIgedBasicos managerIgedBasicos = new ManagerIgedBasicos();
            ManagerUnidadEjecutora managerUnidadEjecutora = new ManagerUnidadEjecutora();
            ManagerDependenciaUnidadEjecutora managerDependenciaUnidadEjecutora = new ManagerDependenciaUnidadEjecutora();
            ManagerTipoPersonal managerTipoPersonal = new ManagerTipoPersonal();

            List<EEventoRegistral> listaEventoRegistral = modificacionSignificativaRequest.listaEventoRegistral;

            ERegistroDefinitivo eRegistroDefinitivo = modificacionSignificativaRequest.registroDefinitivo;

            int idRegistro = 0;
            //int idRegistroDefinitivo = 0;
            bool modIgedBasicos = false;

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            // SI EXISTE UN CAMBIO PENDIENTE:
            if (listaEventoRegistral.Count>0)
            {
                try
                {              
                    //1. CREAR EL REGISTO
                    Registro registroDefinitivo = new Registro();

                    registroDefinitivo.IdTipoRegistro = managerTipoRegistro.ObtenerCDTipoRegistroPorCodigo(2).IdTipoRegistro; //2 DEFINITIVO
                    registroDefinitivo.IdEstadoRegistro = managerEstadoRegistro.ObtenerEstadoRegistroPorCodigo(5).IdEstadoRegistro; //5: ASENTADO
                    registroDefinitivo.UsuCreacion = usuario;
                    registroDefinitivo.FechAsiento = fechaHoy;
                    registroDefinitivo.FechaCreacion = fechaHoy;
                    registroDefinitivo.EsActivo = true;
                    registroDefinitivo.EsBorrado = false;

                    idRegistro = managerRegistro.saveRegistro(registroDefinitivo);

                    //2. ACTUALIZAR EL CÓDIGO DE REGISTRO
                    registroDefinitivo.IdRegistro = idRegistro;
                    registroDefinitivo.CodRegistro = idRegistro.ToString();
                    managerRegistro.updateRegistro(registroDefinitivo);
                    ///

                    //3. ACTUALIZAMOS EL REGISTRO DEL DOCUMENTO RESOLUTIVO SUBIDO TEMPORALMENTE
                    Documento documento = new Documento();
                    documento.IdDocumento = eRegistroDefinitivo.DocumentoResolutivo.IdDocumento;                
                    documento.NombreArchivo = eRegistroDefinitivo.DocumentoResolutivo.NombreArchivo;
                    documento.Ruta = eRegistroDefinitivo.DocumentoResolutivo.Ruta;
                    documento.FechaEmision = eRegistroDefinitivo.DocumentoResolutivo.FechaEmision;
                    documento.FechaPublicacion = eRegistroDefinitivo.DocumentoResolutivo.FechaPublicacion;
                    documento.NroDocumento = eRegistroDefinitivo.DocumentoResolutivo.NroDocumento;
                    documento.IdTipoDoc = eRegistroDefinitivo.DocumentoResolutivo.TipoDocumento.IdTipoDoc;
                    documento.IdClasificacionDoc = managerClasificacionDocumento.ObtenerClasificacionDocumentoPorCodigo(1).IdClasificacionDoc; //cod: 1 :Resolutivo;
                    documento.EsActivo = true;
                    documento.EsBorrado = false;
                    documento.FechaCreacion = fechaHoy;
                    documento.UsuCreacion = usuario;
                    documento.Temporal = false;

                    managerDocumento.updateDocumento(documento);

                    //4.REGISTRAR EL DOCUMENTO-REGISTRO

                    DocumentoRegistro documentoRegistro = new DocumentoRegistro();
                    documentoRegistro.EsActivo = true;
                    documentoRegistro.EsBorrado = false;
                    documentoRegistro.FechaCreacion = fechaHoy;
                    documentoRegistro.UsuCreacion = usuario;
                    documentoRegistro.IdDocumento = documento.IdDocumento;
                    documentoRegistro.IdRegistro = idRegistro;

                    managerDocumentoRegistro.saveDocumentoRegistro(documentoRegistro);

                    int IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged?? default(int);

                    //OBTENER EL REGISTRO IGED_BASICO ACTIVO
                    IgedBasicos igedBasicosAInactivar = new IgedBasicos();
                    IgedBasicos igedBasicosNuevo = new IgedBasicos();
                    int idIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                    igedBasicosAInactivar = managerIgedBasicos.ObtenerIgedBasicosPorIgedPorEstado(idIged, true);
                    igedBasicosNuevo = igedBasicosAInactivar;
                    igedBasicosNuevo.IdRegistro = idRegistro;

                    List<IgedRegistroDetalle> listaIgedRegistroDetalle = new List<IgedRegistroDetalle>();


                    //5. SI SE REQUIERE CAMBIO DE DENOMINACIÓN?????
                    if((from a in listaEventoRegistral where a.CodEvento == 2 select a).FirstOrDefault() != null)
                    {
                        //5.1 CREAR EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle1 = new IgedRegistroDetalle();

                        igedRegistroDetalle1.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle1.IdRegistro = idRegistro;
                        igedRegistroDetalle1.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(2).IdEventoRegistral; //cod: 2: cambio de denominación
                        igedRegistroDetalle1.NomIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.NomIged;
                        igedRegistroDetalle1.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle1.UsuCreacion = usuario;
                        igedRegistroDetalle1.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle1.EsActivo = true;
                        igedRegistroDetalle1.EsBorrado = false;

                        listaIgedRegistroDetalle.Add(igedRegistroDetalle1);

                        //5.2 MODIFICAR EL REGISTRO IGED_BASICOS
                        igedBasicosNuevo.NomIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.NomIged;
                        modIgedBasicos = true;

                    }

                    //8. SI REQUIERE CAMBIO DE SEDE PRINCIPAL?????
                    if ((from a in listaEventoRegistral where a.CodEvento == 5 select a).FirstOrDefault() != null)
                    {
                        //8.1 CREAR EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle2 = new IgedRegistroDetalle();

                        igedRegistroDetalle2.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle2.IdRegistro = idRegistro;
                        igedRegistroDetalle2.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(5).IdEventoRegistral; //cod: 5: cambio de sede principal
                        igedRegistroDetalle2.IdUbigeoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Ubigeo.IdUbigeo;
                        igedRegistroDetalle2.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle2.UsuCreacion = usuario;
                        igedRegistroDetalle2.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle2.EsActivo = true;
                        igedRegistroDetalle2.EsBorrado = false;

                        listaIgedRegistroDetalle.Add(igedRegistroDetalle2);
                        //8.2 MODIFICAR SEDE PRINCIPAL
                        igedBasicosNuevo.IdUbigeo = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Ubigeo.IdUbigeo;
                        modIgedBasicos = true;
                    }

                    //9. SI REQUIERE CAMBIO DE UNIDAD EJECUTORA??????????
                    if ((from a in listaEventoRegistral where a.CodEvento == 6 select a).FirstOrDefault() != null)
                    {
                        //9.1 CREAR EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle3 = new IgedRegistroDetalle();

                        igedRegistroDetalle3.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle3.IdRegistro = idRegistro;
                        igedRegistroDetalle3.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(6).IdEventoRegistral; //cod: 6: Conversión / Cambio de Unidad Ejecutora                   
                        igedRegistroDetalle3.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle3.UsuCreacion = usuario;
                        igedRegistroDetalle3.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle3.EsActivo = true;
                        igedRegistroDetalle3.EsBorrado = false;

                        listaIgedRegistroDetalle.Add(igedRegistroDetalle3);

                        //9.2 MODIFICAR LA UNIDAD EJECUTORA
                        DependeciaUnidadEjecutora dependenciaUnidadEjecutoraAInactivar = new DependeciaUnidadEjecutora();
                        dependenciaUnidadEjecutoraAInactivar = managerDependenciaUnidadEjecutora.ObtenerDependenciaUnidadEjecutoraActivaPorIdUgel(idIged);

                        igedBasicosNuevo.EsUeAutonoma = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.EsUeAutonoma;
                        modIgedBasicos = true;

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.EsUeAutonoma)
                        //9.2.1 SI ES UNIDAD AUTONOMA => CREAR LA ENTIDAD UE EN LA TABLA UNIDAD_EJECUTORA                    
                        {
                            int idUnidadEjecutora = 0;
                            UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

                            unidadEjecutora.IdPliegoUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.PliegoUnidadEjecutora.IdPliegoUnidadEjecutora;
                            unidadEjecutora.CodUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.CodUnidadEjecutora;
                            unidadEjecutora.DescUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.DescUnidadEjecutora;
                            unidadEjecutora.UsuCreacion = usuario;
                            unidadEjecutora.FechaActualizacion = fechaHoy;
                            unidadEjecutora.EsActivo = true;
                            unidadEjecutora.EsBorrado = false;

                            //9.2.1.1 CREAR EL VINCULO EN UGEL_BASICOS CON LOS DATOS DE LA UGEL COMO UE_AUTONOMA
                            idUnidadEjecutora = managerUnidadEjecutora.saveManagerUnidadEjecutora(unidadEjecutora);
                            managerDependenciaUnidadEjecutora.DarBajaDependenciaUnidadEjecutora(dependenciaUnidadEjecutoraAInactivar.IdIgedEjecutora);
                            igedBasicosNuevo.IdUnidadEjecutora = idUnidadEjecutora;
                            modIgedBasicos = true;

                        }
                        //9.2.2 SI NO ES UNIDAD AUTÓNOMA => CREAR EL VINCULO CON LA UE DE LA QUE DEPENDE EN LA TABLA DEPENDENCIA_UNIDAD_EJECUTORA
                        else
                        {
                            DependeciaUnidadEjecutora dependenciaUnidadEjecutora = new DependeciaUnidadEjecutora();
                             
                            dependenciaUnidadEjecutora.IdUnidadEjecutora = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.UnidadEjecutora.IdUnidadEjecutora;
                            dependenciaUnidadEjecutora.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                            dependenciaUnidadEjecutora.IdRegistro = idRegistro;
                            dependenciaUnidadEjecutora.UsuCreacion = usuario;
                            dependenciaUnidadEjecutora.FechaActualizacion = fechaHoy;
                            dependenciaUnidadEjecutora.EsActivo = true;
                            dependenciaUnidadEjecutora.EsBorrado = false;

                            //managerDependenciaUnidadEjecutora.saveDependenciaUnidadEjecutora(dependenciaUnidadEjecutora);
                            managerDependenciaUnidadEjecutora.RemplazarDependenciaUnidadEjecutora(dependenciaUnidadEjecutoraAInactivar, dependenciaUnidadEjecutora);
                        }
                    }

                    //6. SI SE REQUIERE CAMBIO DE DIRECTOR????
                    if ((from a in listaEventoRegistral where a.CodEvento == 3 select a).FirstOrDefault() != null)
                    {
                        //6.1 CREA EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle4 = new IgedRegistroDetalle();

                        igedRegistroDetalle4.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle4.IdRegistro = idRegistro;
                        igedRegistroDetalle4.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(3).IdEventoRegistral; //cod: 3: Cambio de director 
                        igedRegistroDetalle4.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle4.UsuCreacion = usuario;
                        igedRegistroDetalle4.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle4.EsActivo = true;
                        igedRegistroDetalle4.EsBorrado = false;

                        listaIgedRegistroDetalle.Add(igedRegistroDetalle4);

                        //6.2 MODIFICAR LAS TABLAS DOCUMENTO Y PERSONAL
                        //6.2.1. CREAR REGISTRO DE DIRECTOR, ANTES DESHABILITAR EL ANTERIOR.
                        //6.2.1.1 OBTENER EL ULTIMO REGISTRO ACTIVO DE DIRECTOR DE LA UGEL.
                        Personal personalDirectorAInactivar = new Personal();
                        personalDirectorAInactivar = managerPersonal.getPersonalPorCodTipoPersonaIdUgel(1, IdIged); //cod: 1 : director

                        //6.2.1.2 BUSCAR SI LA PERSONA CON ESE DNI EXISTE, SI EXISTE Y ESTA RELACIONADO A OTRO REGISTRO (ALERTAR), 
                        //6.2.1.3 SI NO EXISTE UNA RELACION => ACTUALIZAR *** aun falta implementar
                        //6.2.1.4 SI NO EXISTE LA PERSONA ENTONCES CREARLA
                        string dni = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.DniPersona;
                        Persona persona = new Persona();
                        persona = managerPersona.getPersonaPorDNI(dni);
                        int idPersona = 0;
                        if (persona is null)
                        {
                            persona.IdPersona = 0;
                            persona.NomPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.NomPersona;
                            persona.AppPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.AppPersona;
                            persona.ApmPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.ApmPersona;
                            persona.DniPersona = dni;
                            persona.UsuCreacion = usuario;
                            persona.FechaCreacion = fechaHoy;
                            persona.EsActivo = true;
                            persona.EsBorrado = false;

                            idPersona = managerPersona.savePersona(persona);
                        }
                        else
                        {
                            persona.NomPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.NomPersona;
                            persona.AppPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.AppPersona;
                            persona.ApmPersona = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.ApmPersona;
                            persona.DniPersona = dni;
                            persona.UsuActualizacion = usuario;
                            persona.FechaActualizacion = fechaHoy;
                            persona.EsActivo = true;
                            persona.EsBorrado = false;

                            managerPersona.updatePersona(persona);
                            idPersona = persona.IdPersona;
                        }


                        //6.2.1.5 CREAR EL NUEVO REGISTRO DIRECTOR EN PERSONAL.
                        Personal personalNuevoDirector = new Personal();

                        personalNuevoDirector.IdPersona = idPersona;
                        personalNuevoDirector.IdIged = idIged;
                        personalNuevoDirector.IdRegistro = idRegistro;
                        personalNuevoDirector.IdTipoPersonal = managerTipoPersonal.ObtenerTipoPersonalPorCodigo(1).IdTipoPersonal; //1: director
                        personalNuevoDirector.UsuCreacion = usuario;
                        personalNuevoDirector.FechaCreacion = fechaHoy;
                        personalNuevoDirector.EsActivo = true;
                        personalNuevoDirector.EsBorrado = false;

                        int idNuevoDirector = managerPersonal.remplazarPersonal(personalDirectorAInactivar, personalNuevoDirector);

                        //2.3. SI EXISTEN LOS MEDIOS DE CONTACTO DEL DIRECTOR, GUARDAR MEDIOS DE CONTACTO.
                        EPersonalMedioContactoB _celular = new EPersonalMedioContactoB();
                        EPersonalMedioContactoB _telefono = new EPersonalMedioContactoB();
                        EPersonalMedioContactoB _email = new EPersonalMedioContactoB();

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio != "")
                        {
                            PersonalMedioContacto celular = new PersonalMedioContacto();
                            celular.IdTipoMedioContacto = 0;
                            celular.IdPersonal = idNuevoDirector;
                            celular.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(1).IdTipoMedioContacto;//1: CELULAR deberia ser ENUMERADO
                            celular.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio;
                            celular.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Descripcion;
                            celular.IdRegistro = idRegistro;
                            managerPersonalMedioContacto.SavePersonalMedioContacto(celular);
                        }

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio != "")
                        {
                            PersonalMedioContacto telefono = new PersonalMedioContacto();
                            telefono.IdTipoMedioContacto = 0;
                            telefono.IdPersonal = idNuevoDirector;
                            telefono.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(2).IdTipoMedioContacto;//1: TELEFONO deberia ser ENUMERADO;
                            telefono.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio;
                            telefono.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Descripcion;
                            telefono.IdRegistro = idRegistro;
                            managerPersonalMedioContacto.SavePersonalMedioContacto(telefono);
                        }

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio != "")
                        {
                            PersonalMedioContacto email = new PersonalMedioContacto();
                            email.IdTipoMedioContacto = 0;
                            email.IdPersonal = idNuevoDirector;
                            email.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(3).IdTipoMedioContacto;//1: WEB deberia ser ENUMERADO;
                            email.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio;
                            email.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Descripcion;
                            email.IdRegistro = idRegistro;
                            managerPersonalMedioContacto.SavePersonalMedioContacto(email);
                        }
                        /*
                        //6.2.2. ACTUALIZAMOS EL REGISTRO DEL DOCUMENTO RESOLUTIVO SUBIDO TEMPORALMENTE
                        Documento documentoDirector = new Documento();
                        documentoDirector.IdDocumento = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.IdDocumento;
                        documentoDirector.NombreArchivo = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.NombreArchivo;
                        documentoDirector.Ruta = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.Ruta;
                        documentoDirector.FechaEmision = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.FechaEmision;
                        documentoDirector.FechaPublicacion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.FechaPublicacion;
                        documentoDirector.NroDocumento = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.NroDocumento;
                        documentoDirector.IdTipoDoc = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.documentoResolutivo.TipoDocumento.IdTipoDoc;
                        documentoDirector.IdClasificacionDoc = managerClasificacionDocumento.ObtenerClasificacionDocumentoPorCodigo(1).IdClasificacionDoc; //cod: 1 :Resolutivo;
                        documentoDirector.EsActivo = true;
                        documentoDirector.EsBorrado = false;
                        documentoDirector.FechaCreacion = fechaHoy;
                        documentoDirector.UsuCreacion = usuario;
                        documentoDirector.Temporal = false;

                        managerDocumento.updateDocumento(documentoDirector);

                        //6.2.3.REGISTRAR EL DOCUMENTO-DIRECTOR
                        DocumentoDirector documentoRegistroDirector = new DocumentoDirector();
                        documentoRegistroDirector.IdPersonal = idNuevoDirector;
                        documentoRegistroDirector.IdDocumento = documentoDirector.IdDocumento;
                        documentoRegistroDirector.FechaCreacion = fechaHoy;
                        documentoRegistroDirector.UsuCreacion = usuario;
                        documentoRegistroDirector.EsActivo = true;
                        documentoRegistroDirector.EsBorrado = false;

                        managerDocumentoRegistro.saveDocumentoRegistro(documentoRegistro);
                        */
                    }


                    //7. SI REQUIERE CAMBIO DE JURISDICCION????

                    if ((from a in listaEventoRegistral where a.CodEvento == 4 select a).FirstOrDefault() != null)
                    {
                        //7.1 CREAR EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle5 = new IgedRegistroDetalle();

                        igedRegistroDetalle5.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle5.IdRegistro = idRegistro;
                        igedRegistroDetalle5.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(4).IdEventoRegistral; //cod: 4: Modificación de jurisdicción
                        igedRegistroDetalle5.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle5.UsuCreacion = usuario;
                        igedRegistroDetalle5.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle5.EsActivo = true;
                        igedRegistroDetalle5.EsBorrado = false;

                        listaIgedRegistroDetalle.Add(igedRegistroDetalle5);

                        //7.2 MODIFICAR LA JURISDICCION DE LA IGED
                        //7.3 CREAR EL REGISTRO DE LAS DERIVADAS
                        //7.4 MODIFICAR LA JURISDICCION DE LA IGED
                        //6. GUARDAR JURISDICCIONES
                        List<EJurisdiccion> listaJurisdiccion = new List<EJurisdiccion>();
                        listaJurisdiccion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.JurisdiccionUgel.ToList();

                        List<JurisdiccionIged> listaJurisdiccionUgel = new List<JurisdiccionIged>();

                        foreach (var jurisdiccion in listaJurisdiccion)
                        {
                            JurisdiccionIged jurisdiccionIged = new JurisdiccionIged();
                            jurisdiccionIged.IdJurisdiccion = jurisdiccion.IdJurisdiccion;
                            jurisdiccionIged.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                            jurisdiccionIged.IdTerminoCantidad = jurisdiccion.TerminoCantidadJurisdiccion.IdTerminoCantidad;
                            jurisdiccionIged.IdTerminoPertenencia = jurisdiccion.TerminoPertenenciaJurisdiccion.IdTerminoPertenencia;
                            jurisdiccionIged.IdUbigeo = jurisdiccion.Ubigeo.IdUbigeo;
                            jurisdiccionIged.IdRegistro = idRegistro;
                            jurisdiccionIged.UsuCreacion = usuario;
                            jurisdiccionIged.FechaCreacion = fechaHoy;
                            jurisdiccionIged.EsActivo = true;
                            jurisdiccionIged.EsBorrado = false;

                            listaJurisdiccionUgel.Add(jurisdiccionIged);
                        }

                        List<EIged> listaUgel = new List<EIged>();
                        EIged eIged = new EIged();
                        eIged.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                        eIged.CodIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.CodIged;
                        eIged.NomIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.NomIged;
                        eIged.CodTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.CodTipoIged;
                        eIged.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;

                        listaUgel.Add(eIged);

                        //ELIMINAR LAS JURISDICCIONES QUE YA NO SON VALIDAS E INGRESAR LAS NUEVAS LINEAS DE JURISDICCION.
                        managerJurisdiccion.ActualizarRegistrosDeJurisdiccion(listaJurisdiccionUgel, listaUgel);

                        //INSERTAR DETALLE DERIVADOS y JURISDICCION DE DERIVADOS
                        List<JurisdiccionIged> listaJurisdiccionDerivadosActualizar = new List<JurisdiccionIged>();
                        List<EIged> listaIgedDerivadosActualizar = new List<EIged>();

                        foreach (EIgedRegistroDefinitivoDetalle item in eRegistroDefinitivo.RegistroDetalleDerivados)
                        {
                            IgedRegistroDetalle igedRegistroDetalleDerivados = new IgedRegistroDetalle();

                            igedRegistroDetalleDerivados.EsActivo = true;
                            igedRegistroDetalleDerivados.EsBorrado = false;
                            igedRegistroDetalleDerivados.EsOrigen = false;
                            igedRegistroDetalleDerivados.FechaCreacion = fechaHoy;
                            igedRegistroDetalleDerivados.UsuCreacion = usuario;
                            igedRegistroDetalleDerivados.NomIged = item.ugel.NomIged;
                            igedRegistroDetalleDerivados.IdEventoRegistral = item.EventoRegistral.IdEventoRegistral;
                            igedRegistroDetalleDerivados.IdRegistro = idRegistro;
                            igedRegistroDetalleDerivados.IdIged = item.ugel.IdIged;

                            listaIgedRegistroDetalle.Add(igedRegistroDetalleDerivados);
                            //var idRegistroDetalle = managerIgedRegistroDetalle.saveIgedRegistroDetalle(igedRegistroDetalleDerivados);

                            EIged eIgedDerivada = new EIged();
                            eIgedDerivada.IdIged = item.ugel.IdIged;
                            eIgedDerivada.CodIged = item.ugel.CodIged;
                            eIgedDerivada.NomIged = item.ugel.NomIged;
                            eIgedDerivada.CodTipoIged = item.ugel.TipoIged.CodTipoIged;

                            eIgedDerivada.IdTipoIged = item.ugel.TipoIged.IdTipoIged;

                            listaIgedDerivadosActualizar.Add(eIgedDerivada);
                            //RECORRER JURISDICCIÓN
                            List<EJurisdiccion> listaJurisdiccionDerivados = new List<EJurisdiccion>();
                            listaJurisdiccionDerivados = item.ugel.JurisdiccionUgel.ToList();

                            foreach (var jurisdiccionDerivado in listaJurisdiccionDerivados)
                            {
                                JurisdiccionIged jurisdiccionDerivadoIged = new JurisdiccionIged();
                                jurisdiccionDerivadoIged.IdJurisdiccion = jurisdiccionDerivado.IdJurisdiccion;
                                jurisdiccionDerivadoIged.IdIged = item.ugel.IdIged;
                                jurisdiccionDerivadoIged.IdTerminoCantidad = jurisdiccionDerivado.TerminoCantidadJurisdiccion.IdTerminoCantidad;
                                jurisdiccionDerivadoIged.IdTerminoPertenencia = jurisdiccionDerivado.TerminoPertenenciaJurisdiccion.IdTerminoPertenencia;
                                jurisdiccionDerivadoIged.IdUbigeo = jurisdiccionDerivado.Ubigeo.IdUbigeo;
                                jurisdiccionDerivadoIged.IdRegistro = idRegistro;
                                jurisdiccionDerivadoIged.UsuCreacion = usuario;
                                jurisdiccionDerivadoIged.FechaCreacion = fechaHoy;
                                jurisdiccionDerivadoIged.EsActivo = true;
                                jurisdiccionDerivadoIged.EsBorrado = false;

                                listaJurisdiccionDerivadosActualizar.Add(jurisdiccionDerivadoIged);
                            }

                            //responseService.MensajePrincipal = "Los datos se guardaron correctamente";
                            //responseService.idRegistro = idRegistro;
                            //responseService.ResultValid = true;
                        }
                        //ELIMINAR LAS JURISDICCIONES QUE YA NO SON VALIDAS E INGRESAR LAS NUEVAS LINEAS DE JURISDICCION.
                        managerJurisdiccion.ActualizarRegistrosDeJurisdiccion(listaJurisdiccionDerivadosActualizar, listaIgedDerivadosActualizar);

                    }
                    if (listaIgedRegistroDetalle.Count>0)
                    {
                        managerIgedRegistroDetalle.saveListaIgedRegistroDetalle(listaIgedRegistroDetalle);
                    }
                    //Si codigo de eventos es: 2 o 5 o 6
                    //reemplazar iged basico.
                    if(modIgedBasicos)
                    {managerIgedBasicos.remplazaIgedBasicos(igedBasicosAInactivar, igedBasicosNuevo); }                    

                    responseService.MensajePrincipal = "Actualizado correctamente";
                    responseService.idRegistro = idRegistro;
                    responseService.ResultValid = true;
                }
                catch (Exception e)
                {
                    responseService.MensajePrincipal = e.Message;
                    responseService.idRegistro = idRegistro;
                    responseService.ResultValid = false;
                }                
            }
            return responseService;
        }

        public ResponseService modificacionComplementaria(ERegistroDefinitivo eRegistroDefinitivo)
        {
            ResponseService responseService = new ResponseService();

            ManagerRegistro managerRegistro = new ManagerRegistro();
            ManagerIgedRegistroDetalle managerIgedRegistroDetalle = new ManagerIgedRegistroDetalle();
            ManagerPersona managerPersona = new ManagerPersona();
            ManagerPersonal managerPersonal = new ManagerPersonal();
            ManagerTipoMedioContacto managerTipoMedioContacto = new ManagerTipoMedioContacto();
            ManagerIgedMedioContacto managerIgedMedioContacto = new ManagerIgedMedioContacto();
            ManagerPersonalMedioContacto managerPersonalMedioContacto = new ManagerPersonalMedioContacto();
            ManagerDocumento managerDocumento = new ManagerDocumento();
            ManagerDocumentoRegistro managerDocumentoRegistro = new ManagerDocumentoRegistro();
            ManagerDocumentoDirector managerDocumentoDirector = new ManagerDocumentoDirector();
            ManagerJurisdiccion managerJurisdiccion = new ManagerJurisdiccion();
            ManagerTipoRegistro managerTipoRegistro = new ManagerTipoRegistro();
            ManagerEstadoRegistro managerEstadoRegistro = new ManagerEstadoRegistro();
            ManagerClasificacionDocumento managerClasificacionDocumento = new ManagerClasificacionDocumento();
            ManagerEventoRegistral managerEventoRegistral = new ManagerEventoRegistral();
            ManagerIgedBasicos managerIgedBasicos = new ManagerIgedBasicos();
            ManagerUnidadEjecutora managerUnidadEjecutora = new ManagerUnidadEjecutora();
            ManagerDependenciaUnidadEjecutora managerDependenciaUnidadEjecutora = new ManagerDependenciaUnidadEjecutora();
            ManagerTipoPersonal managerTipoPersonal = new ManagerTipoPersonal();

            int idRegistro = 0;
            //int idRegistroDefinitivo = 0;
            bool modIgedBasicos = false;

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            // SI EXISTE UN CAMBIO PENDIENTE:
            try
                {
                    //1. CREAR EL REGISTO
                    Registro registroDefinitivo = new Registro();

                    registroDefinitivo.IdTipoRegistro = managerTipoRegistro.ObtenerCDTipoRegistroPorCodigo(2).IdTipoRegistro; //2 DEFINITIVO
                    registroDefinitivo.IdEstadoRegistro = managerEstadoRegistro.ObtenerEstadoRegistroPorCodigo(5).IdEstadoRegistro; //5: ASENTADO
                    registroDefinitivo.UsuCreacion = usuario;
                    registroDefinitivo.FechAsiento = fechaHoy;
                    registroDefinitivo.FechaCreacion = fechaHoy;
                    registroDefinitivo.EsActivo = true;
                    registroDefinitivo.EsBorrado = false;

                    idRegistro = managerRegistro.saveRegistro(registroDefinitivo);

                    //2. ACTUALIZAR EL CÓDIGO DE REGISTRO
                    registroDefinitivo.IdRegistro = idRegistro;
                    registroDefinitivo.CodRegistro = idRegistro.ToString();
                    managerRegistro.updateRegistro(registroDefinitivo);
                    ///                  

                    int IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);

                    //5. SI SE REQUIERE CAMBIO DE DENOMINACIÓN?????                    
                        //5.1 CREAR EL DETALLE DE REGISTRO
                        IgedRegistroDetalle igedRegistroDetalle = new IgedRegistroDetalle();

                        igedRegistroDetalle.IdIged = IdIged; //eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged ?? default(int);
                        igedRegistroDetalle.IdRegistro = idRegistro;
                        igedRegistroDetalle.IdEventoRegistral = managerEventoRegistral.ObtenerCDEventoRegistralPorCodigo(2).IdEventoRegistral; //cod: 2: cambio de denominación
                        igedRegistroDetalle.IdTipoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.TipoIged.IdTipoIged;
                        igedRegistroDetalle.UsuCreacion = usuario;
                        igedRegistroDetalle.FechaActualizacion = fechaHoy;
                        igedRegistroDetalle.EsActivo = true;
                        igedRegistroDetalle.EsBorrado = false;

                        managerIgedRegistroDetalle.saveIgedRegistroDetalle(igedRegistroDetalle);

                        //1. GUARDAR CONTACTOS DE IGED SI EXISTEN
                        List<IgedMedioContacto> listaIgedMediosContacto = new List<IgedMedioContacto>();
                        List<EMedioContacto> mediosContactoIged = new List<EMedioContacto>();
                        mediosContactoIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.MediosContactoIged.ToList();

                        if (mediosContactoIged != null && mediosContactoIged.Count > 0)
                        {
                            foreach (EMedioContacto medio in mediosContactoIged)
                            {
                                IgedMedioContacto igedMedioContacto = new IgedMedioContacto();

                                igedMedioContacto.IdTipoMedioContacto = medio.TipoMedioContacto.IdTipoMedioContacto;
                                igedMedioContacto.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                                igedMedioContacto.Medio = medio.Medio;
                                igedMedioContacto.Descripcion = medio.Descripcion;
                                igedMedioContacto.IdRegistro = idRegistro; // eRegistroDefinitivo.RegistroDetallePrincipal.IdIGEDRegistro;
                                igedMedioContacto.UsuCreacion = usuario;
                                igedMedioContacto.FechaCreacion = fechaHoy;
                                igedMedioContacto.EsActivo = true;
                                igedMedioContacto.EsBorrado = false;

                                listaIgedMediosContacto.Add(igedMedioContacto); 
                            }
                        }
                        managerIgedMedioContacto.ActualizarRegistrosDeMediosContacto(listaIgedMediosContacto, IdIged);
                        //.../

                        //2.3. SI EXISTEN LOS MEDIOS DE CONTACTO DEL DIRECTOR, GUARDAR MEDIOS DE CONTACTO.
                        List<PersonalMedioContacto> listaPersonalMedioContacto = new List<PersonalMedioContacto>();

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio != "")
                        {
                            PersonalMedioContacto celular = new PersonalMedioContacto();
                            //celular.IdTipoMedioContacto = 0;
                            celular.IdPersonal = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.IdPersonal;
                            celular.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(1).IdTipoMedioContacto;//1: CELULAR deberia ser ENUMERADO
                            celular.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio;
                            celular.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Descripcion;
                            celular.IdRegistro = idRegistro;

                            listaPersonalMedioContacto.Add(celular);
                            //managerPersonalMedioContacto.SavePersonalMedioContacto(celular);
                        }

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio != "")
                        {
                            PersonalMedioContacto telefono = new PersonalMedioContacto();
                            //telefono.IdTipoMedioContacto = 0;
                            telefono.IdPersonal = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.IdPersonal;
                            telefono.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(2).IdTipoMedioContacto;//1: TELEFONO deberia ser ENUMERADO;
                            telefono.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio;
                            telefono.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Descripcion;
                            telefono.IdRegistro = idRegistro;
                            listaPersonalMedioContacto.Add(telefono);
                            //managerPersonalMedioContacto.SavePersonalMedioContacto(telefono);
                        }

                        if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio != "")
                        {
                            PersonalMedioContacto email = new PersonalMedioContacto();
                            //email.IdTipoMedioContacto = 0;
                            email.IdPersonal = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.IdPersonal;
                            email.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(3).IdTipoMedioContacto;//1: WEB deberia ser ENUMERADO;
                            email.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio;
                            email.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Descripcion;
                            email.IdRegistro = idRegistro;
                            listaPersonalMedioContacto.Add(email);
                            //managerPersonalMedioContacto.SavePersonalMedioContacto(email);
                        }

                        managerPersonalMedioContacto.ActualizarRegistrosDeMediosContacto(listaPersonalMedioContacto, IdIged);

                        //4. GUARDAR LISTA DE PERSONAL
                List<EPersonalExtend> ListaPersonal = new List<EPersonalExtend>();
                        ListaPersonal = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.PersonalIged.ToList();

                        foreach (EPersonalExtend personalItem in ListaPersonal)
                        {
                            Persona _persona = new Persona();
                            Personal _personal = new Personal();
                            string dni = "";
                           
                            dni = personalItem.DniPersona;
                            _persona = managerPersona.getPersonaPorDNI(dni);
                            //4.1 SI EXISTE PERSONA CON EL MISMO DNI
                            // (para validaciones) SI ESTÁ VINCULADO A OTRO REGISTRO ACTIVO, ADVERTIR. Y NO HACER NADA.
                            // SI NO ESTÁ VINCULADO, ACTUALIZAR, SINO, CREAR.
                            if (_persona is null)
                            {
                                _persona.IdPersona = 0;
                                _persona.NomPersona = personalItem.NomPersona;
                                _persona.AppPersona = personalItem.AppPersona;
                                _persona.ApmPersona = personalItem.ApmPersona;
                                _persona.DniPersona = dni;
                                _persona.UsuCreacion = usuario;
                                _persona.FechaCreacion = fechaHoy;
                                _persona.EsActivo = true;
                                _persona.EsBorrado = false;

                                _personal.IdPersona = managerPersona.savePersona(_persona);
                            }
                            else
                            {
                                _personal.IdPersona = _persona.IdPersona;
                            }

                            _personal.IdPersonal = personalItem.IdPersonal;
                            _personal.IdTipoPersonal = personalItem.tipoPersonal.IdTipoPersonal;
                            _personal.IdIged = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.IdIged;
                            _personal.IdRegistro = idRegistro; // igedRegistroDetalle.IdIgedRegistro; //eRegistroDefinitivo.IdRegistro;
                            _personal.FechaCreacion = fechaHoy;
                            _personal.UsuCreacion = usuario;
                            _personal.EsActivo = true;
                            _personal.EsBorrado = false;

                            if (personalItem.IdPersonal == 0)
                            { 
                                int _IdPersonal = managerPersonal.actualizarPersonal(_personal); //da de baja al personal del mismo tipo de la misma iged, activo y registra la nueva entrada como nuevo personal.
                            
                                //4.2. SI EXISTEN MEDIOS DE CONTACTO POR PERSONAL
                                if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio != "")
                                {
                                    PersonalMedioContacto _celular = new PersonalMedioContacto();
                                    _celular.IdTipoMedioContacto = 0;
                                    _celular.IdPersonal = _IdPersonal;
                                    _celular.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(1).IdTipoMedioContacto;//1: CELULAR deberia ser ENUMERADO
                                    _celular.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Medio;
                                    _celular.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Celular.Descripcion;
                                    _celular.IdRegistro = idRegistro;

                                    listaPersonalMedioContacto.Add(_celular);
                                    //managerPersonalMedioContacto.SavePersonalMedioContacto(celular);
                                }

                                if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio != "")
                                {
                                    PersonalMedioContacto _telefono = new PersonalMedioContacto();
                                    _telefono.IdTipoMedioContacto = 0;
                                    _telefono.IdPersonal = _IdPersonal;
                                    _telefono.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(2).IdTipoMedioContacto;//1: TELEFONO deberia ser ENUMERADO;
                                    _telefono.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Medio;
                                    _telefono.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Telefono.Descripcion;
                                    _telefono.IdRegistro = idRegistro;

                                    listaPersonalMedioContacto.Add(_telefono);
                                    //managerPersonalMedioContacto.SavePersonalMedioContacto(telefono);
                                }

                                if (eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email != null && eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio != "")
                                {
                                    PersonalMedioContacto _email = new PersonalMedioContacto();
                                    _email.IdTipoMedioContacto = 0;
                                    _email.IdPersonal = _IdPersonal;
                                    _email.IdTipoMedioContacto = managerTipoMedioContacto.ObtenerMedioContactoPorCodigo(3).IdTipoMedioContacto;//1: WEB deberia ser ENUMERADO;
                                    _email.Medio = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Medio;
                                    _email.Descripcion = eRegistroDefinitivo.RegistroDetallePrincipal.ugel.Director.Email.Descripcion;
                                    _email.IdRegistro = idRegistro;

                                    listaPersonalMedioContacto.Add(_email);
                                    //managerPersonalMedioContacto.SavePersonalMedioContacto(email);
                                }
                            }
                        }

                    //Si codigo de eventos es: 2 o 5 o 6
                    //reemplazar iged basico.
                    responseService.MensajePrincipal = "Actualizado correctamente";
                    responseService.idRegistro = idRegistro;
                    responseService.ResultValid = true;
                }
                catch (Exception e)
                {
                    responseService.MensajePrincipal = e.Message;
                    responseService.idRegistro = idRegistro;
                    responseService.ResultValid = false;
                }
            
            return responseService;
        }
        public ResponseService SaveRegistroProvisional(ERegistroProvisionalRequest eRegistroRequest)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            ManagerDocumento managerDocumento = new ManagerDocumento();
            ManagerDocumentoRegistro managerDocumentoRegistro = new ManagerDocumentoRegistro();
            ManagerIged managerIged = new ManagerIged();
            ManagerIgedRegistroDetalle managerIgedRegistroDetalle = new ManagerIgedRegistroDetalle();

            Registro registro = new Registro();
            Documento documento = new Documento();
            DocumentoRegistro documentoRegistro = new DocumentoRegistro();
            Iged iged = new Iged();

            int idRegistro = 0;
            int idDocumento = 0;
            int idDocumentoRegistro = 0;
            int idUgel = 0;
            int idRegistroDetalle = 0;

            DateTime fechaCreacion = DateTime.Now;
            string usuario = "40615837";

            //registro.CodRegistro = "00000000";
            registro.EsActivo = true;
            registro.EsBorrado = false;
            registro.FechaCreacion = fechaCreacion;
            registro.UsuCreacion = usuario;
            registro.IdEstadoRegistro = 2; //ENUMERADO (PENDIENTE)
            registro.IdTipoRegistro = eRegistroRequest.TipoRegistro.IdTipoRegistro;

            if (eRegistroRequest.IdRegistro > 0)
            {
                //obtener el registro con el Id.
                try
                {

                
                var r = managerRegistro._ObtenerRegistroPorId(eRegistroRequest.IdRegistro);
                if (r!= null) //si el registro con el id existe => actualizar
                {
                    registro.IdRegistro = r.IdRegistro;
                    registro.CodRegistro = r.CodRegistro;
                    registro.FechaActualizacion = fechaCreacion;
                    registro.UsuActualizacion = usuario;
                    managerRegistro.updateRegistro(registro);//actualizar la data con la data que viene en eRegistroRequest.
                    idRegistro = registro.IdRegistro; 
                }
                else //si no existe => crear
                {
                        try
                        {                        
                        registro.IdRegistro = 0;
                        registro.CodRegistro = "00000000";
                        idRegistro = managerRegistro.saveRegistro(registro);

                        //ACTUALIZAR EL CÓDIGO DE REGISTRO
                        registro.IdRegistro = idRegistro;
                        registro.CodRegistro = idRegistro.ToString();
                        managerRegistro.updateRegistro(registro);
                        }
                        catch (Exception e)
                        {
                            ResponseService responseService2 = new ResponseService();

                            responseService2.MensajePrincipal = "Error en _ObtenerRegistroPorId _ saver_registro";
                            responseService2.idRegistro = idRegistro;
                            responseService2.ResultValid = true;

                            return responseService2;
                        }
                        ///
                    }
                    //En ambos casos asignar a la variable idRegistro el valor.
                }
                catch (Exception e)
                {

                    ResponseService responseService1 = new ResponseService();

                    responseService1.MensajePrincipal = "Error en _ObtenerRegistroPorId_update_registro";
                    responseService1.idRegistro = idRegistro;
                    responseService1.ResultValid = true;

                    return responseService1;

                }
            }
            else
            {
                //Crear registro
                registro.IdRegistro = 0;
                registro.CodRegistro = "00000000";
                idRegistro = managerRegistro.saveRegistro(registro);

                //ACTUALIZAR EL CÓDIGO DE REGISTRO
                registro.IdRegistro = idRegistro;
                registro.CodRegistro = idRegistro.ToString();
                managerRegistro.updateRegistro(registro);
                ///
            }


            if (eRegistroRequest.DocumentoResolutivo != null) //Si request trae data de documento => actualizar o crear en BD
            {
                documento.NombreArchivo = eRegistroRequest.DocumentoResolutivo.NombreArchivo;
                documento.Ruta = eRegistroRequest.DocumentoResolutivo.Ruta;
                documento.FechaEmision = eRegistroRequest.DocumentoResolutivo.FechaEmision;
                documento.FechaPublicacion = eRegistroRequest.DocumentoResolutivo.FechaPublicacion;
                documento.NroDocumento = eRegistroRequest.DocumentoResolutivo.NroDocumento;
                documento.IdTipoDoc = eRegistroRequest.DocumentoResolutivo.TipoDocumento.IdTipoDoc;
                documento.IdClasificacionDoc = 1;
                documento.EsActivo = true;
                documento.EsBorrado = false;

                if (eRegistroRequest.DocumentoResolutivo.IdDocumento > 0)
                {
                    //obtener el documento con el id.
                    var r = managerDocumento.ObtenerDocumentoPorId(eRegistroRequest.DocumentoResolutivo.IdDocumento);
                    if (r != null) //si el documento con el id existe => actualizar //actualizar la data con la que viene en eRegistroRequest.
                    {
                        documento.IdDocumento = r.IdDocumento;
                        documento.FechaActualizacion = fechaCreacion;
                        documento.UsuActualizacion = usuario;
                        documento.FechaCreacion = r.FechaCreacion==null? fechaCreacion: r.FechaCreacion;
                        documento.UsuCreacion = r.UsuCreacion==null? usuario : r.UsuCreacion;

                        managerDocumento.updateDocumento(documento);
                        idDocumento = r.IdDocumento;

                    }
                    else //si no existe => 
                    {
                        //crear
                        documento.IdDocumento = 0;                        
                        documento.EsActivo = true;
                        documento.EsBorrado = false;

                        idDocumento = managerDocumento.saveDocumento(documento);
                    }                    
                }
                else
                {
                    //Crear el documento.
                    documento.IdDocumento = 0;
                    documento.FechaCreacion = fechaCreacion;
                    documento.UsuCreacion = usuario;

                    idDocumento = managerDocumento.saveDocumento(documento);
                }
                //En ambos casos asignar a la variable idDocumento el valor.
            }

            //Registrar/Actualizar DocumentoRegsitro.
            documentoRegistro.IdDocumento = idDocumento;
            documentoRegistro.IdRegistro = idRegistro;
            documentoRegistro.FechaCreacion = fechaCreacion;
            documentoRegistro.UsuCreacion = usuario;
            documentoRegistro.FechaActualizacion = fechaCreacion;
            documentoRegistro.UsuActualizacion = usuario;
            documentoRegistro.EsActivo = true;
            documentoRegistro.EsBorrado = false;            

            managerDocumentoRegistro.actualizarDocumentoRegistro(documentoRegistro);
           
            //Obtener el registro de iged con el id de

            if(eRegistroRequest.Ugel != null)
            {                
                iged.CodIged = eRegistroRequest.Ugel.CodIged;
                iged.IdEstadoIged = 3; //ENUMERADO
                iged.IdTipoIged = 2; //ENUMERADO           
                iged.FechaCreacion = fechaCreacion;
                iged.UsuCreacion = usuario;
                iged.EsActivo = true;
                iged.EsBorrado = false;

                if (eRegistroRequest.Ugel.IdIged>0)
                {

                    var r = managerIged.ObtenerIgedPorId(eRegistroRequest.Ugel.IdIged?? default(int));

                    if(r != null)
                    {
                        iged.IdIged = r.IdIged; //eRegistroRequest.Ugel.IdIged ?? default(int);
                        iged.FechaCreacion = r.FechaCreacion;
                        iged.UsuCreacion = r.UsuCreacion;
                        iged.FechaActualizacion = fechaCreacion;
                        iged.UsuActualizacion = usuario;
                        managerIged.updateIged(iged);
                        idUgel = iged.IdIged;
                    }
                    else
                    {
                       iged.IdIged = 0;
                       idUgel =  managerIged.saveIged(iged);
                    }                   
                }
                else
                {
                    iged.IdIged = 0;
                    idUgel = managerIged.saveIged(iged);
                }
            }

            //Registrar/Actualizar IgedRegistroDetalle.
            IgedRegistroDetalle igedRegistroDetalle = new IgedRegistroDetalle();

            igedRegistroDetalle.EsActivo = true;
            igedRegistroDetalle.EsBorrado = false;
            igedRegistroDetalle.EsOrigen = true;
            igedRegistroDetalle.FechaCreacion = fechaCreacion;
            igedRegistroDetalle.UsuCreacion = usuario;
            igedRegistroDetalle.NomIged = eRegistroRequest.Ugel.NomIged;
            igedRegistroDetalle.IdUbigeoIged = eRegistroRequest.Ubigeo.IdUbigeo;
            igedRegistroDetalle.IdTipoIged = eRegistroRequest.Ugel.TipoIged.IdTipoIged;
            igedRegistroDetalle.IdDre = eRegistroRequest.Dre.IdIged;
            igedRegistroDetalle.IdEventoRegistral = eRegistroRequest.EventoRegistral.IdEventoRegistral;
            igedRegistroDetalle.IdRegistro = idRegistro;
            igedRegistroDetalle.IdIged = idUgel;

            idRegistroDetalle = managerIgedRegistroDetalle.ActualizarRegDetalleOrigen(igedRegistroDetalle);

            ResponseService responseService = new ResponseService();

                responseService.MensajePrincipal = "Los datos se guardaron correctamente";
                responseService.idRegistro = idRegistro;
                responseService.ResultValid = true;

                return responseService;          

        }

        public int saveDocumento(Documento documento)
        {
            ManagerDocumento managerDocumento = new ManagerDocumento();
            return managerDocumento.saveDocumento(documento);
        }

        public DocumentoTem ObtenerDocumentoTemPorId(int idDocumentoTem)
        {
            ManagerDocumentoTem managerDocumentoTem = new ManagerDocumentoTem();
            return managerDocumentoTem.ObtenerDocumentoPorId(idDocumentoTem);
        }

        public ResponseService SuspCanRegistroProvisional(ERegistroSuspensionRequest eRegistroRequest, int codSuspCanc)
        {
            ManagerRegistro managerRegistro = new ManagerRegistro();
            ManagerEstadoRegistro managerEstadoRegistro = new ManagerEstadoRegistro();
            ManagerClasificacionDocumento managerClasificacionDocumento = new ManagerClasificacionDocumento();
            ManagerDocumento managerDocumento = new ManagerDocumento();
            //ManagerDocumentoRegistro managerDocumentoRegistro = new ManagerDocumentoRegistro();
            ManagerDocumentoSuspension managerDocumentoSuspension = new ManagerDocumentoSuspension();
            ManagerIged managerIged = new ManagerIged();
            ManagerEstadoIged managerEstadoIged = new ManagerEstadoIged();
            ManagerTipoSuspensionCancelacion managerTipoSuspensionCancelacion = new ManagerTipoSuspensionCancelacion();
            ManagerIgedRegistroDetalle managerIgedRegistroDetalle = new ManagerIgedRegistroDetalle();
            ManagerConfiguracionTipoSusp managerConfiguracionTipoSusp = new ManagerConfiguracionTipoSusp();
            ManagerSuspensionCancelacion managerSuspensionCancelacion = new ManagerSuspensionCancelacion();

            Registro registro = new Registro();
            Documento documento = new Documento();
            DocumentoSuspension documentoSuspension = new DocumentoSuspension();
            SuspensionCancelación suspensionCancelacion = new SuspensionCancelación();
            ResponseService responseService = new ResponseService();
            Iged iged = new Iged();

            int idRegistro = 0;
            int idDocumento = 0;
            int idDocumentoRegistro = 0;
            int idUgel = 0;
            int idRegistroDetalle = 0;

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            if (eRegistroRequest != null)
            {
                if (eRegistroRequest.IdRegistro > 0)
                {
                    //obtener el registro con el Id.
                    try
                    {
                        var r = managerRegistro._ObtenerRegistroPorId(eRegistroRequest.IdRegistro);
                        if (r != null) //si el registro con el id existe => actualizar
                        {
                            r.FechaActualizacion = fechaHoy;
                            r.UsuActualizacion = usuario;
                            if (codSuspCanc == 1)
                            {
                                r.IdEstadoRegistro = managerEstadoRegistro.ObtenerEstadoRegistroPorCodigo(3).IdEstadoRegistro; //CodEstadoRegistro : 3 Suspendido  //crear enumerado
                            }
                            else
                            {
                                if (codSuspCanc == 2)
                                {
                                    r.IdEstadoRegistro = managerEstadoRegistro.ObtenerEstadoRegistroPorCodigo(4).IdEstadoRegistro; //CodEstadoRegistro : 4 Cancelado  //crear enumerado
                                }
                            }
                            
                            managerRegistro.updateRegistro(r);//actualizar la data con la data que viene en eRegistroRequest.
                            idRegistro = r.IdRegistro;
                            int idClasificacionDoc = 0;

                            idClasificacionDoc = managerConfiguracionTipoSusp.ObtenerConfiguracionTipoSusp(codSuspCanc).IdClasificacionDoc?? default (int);

                            if (eRegistroRequest.DocumentoDeSustento != null) //Si request trae data de documento => actualizar o crear en BD
                            {
                                documento.NombreArchivo = eRegistroRequest.DocumentoDeSustento.NombreArchivo;
                                documento.Ruta = eRegistroRequest.DocumentoDeSustento.Ruta;
                                documento.FechaEmision = eRegistroRequest.DocumentoDeSustento.FechaEmision;
                                documento.FechaPublicacion = eRegistroRequest.DocumentoDeSustento.FechaPublicacion;
                                documento.NroDocumento = eRegistroRequest.DocumentoDeSustento.NroDocumento;
                                documento.IdTipoDoc = eRegistroRequest.DocumentoDeSustento.TipoDocumento.IdTipoDoc;
                                documento.IdClasificacionDoc = idClasificacionDoc; // managerClasificacionDocumento.ObtenerClasificacionDocumentoPorCodigo(3).IdClasificacionDoc;
                                documento.EsActivo = true;
                                documento.EsBorrado = false;

                                if (eRegistroRequest.DocumentoDeSustento.IdDocumento > 0)
                                {
                                    //obtener el documento con el id.
                                    var d = managerDocumento.ObtenerDocumentoPorId(eRegistroRequest.DocumentoDeSustento.IdDocumento);
                                    if (d != null) //si el documento con el id existe => actualizar //actualizar la data con la que viene en eRegistroRequest.
                                    {
                                        documento.IdDocumento = d.IdDocumento;
                                        documento.FechaActualizacion = fechaHoy;
                                        documento.UsuActualizacion = usuario;
                                        documento.FechaCreacion = d.FechaCreacion == null ? fechaHoy : r.FechaCreacion;
                                        documento.UsuCreacion = d.UsuCreacion == null ? usuario : d.UsuCreacion;

                                        managerDocumento.updateDocumento(documento);
                                        idDocumento = d.IdDocumento;

                                        //Registrar/Actualizar DocumentoSuspención.
                                        documentoSuspension.IdDocumento = idDocumento;
                                        //documentoSuspension.IdRegistro = idRegistro;
                                        documentoSuspension.FechaCreacion = fechaHoy;
                                        documentoSuspension.UsuCreacion = usuario;
                                        documentoSuspension.EsActivo = true;
                                        documentoSuspension.EsBorrado = false;

                                        managerDocumentoSuspension.saveDocumentoSuspension(documentoSuspension);
                                    }
                                }
                            }

                            var u = managerIged.ObtenerIgedOrigenPorIdRegistro(idRegistro);

                            if (u != null)
                            {
                                u.FechaActualizacion = fechaHoy;
                                u.UsuActualizacion = usuario;

                                if (codSuspCanc == 1)
                                {
                                    u.IdEstadoIged = managerEstadoIged.ObtenerEstadoIgedPorCodigo(3).IdEstadoIged;  //CodEstadoIged : 3 ProvisionalSuspendida  //crear enumerado
                                }
                                else
                                {
                                    if (codSuspCanc == 2)
                                    {
                                        u.IdEstadoIged = managerEstadoIged.ObtenerEstadoIgedPorCodigo(4).IdEstadoIged; //CodEstadoIged : 4 ProvisionalCancelada  //crear enumerado
                                    }
                                }                                

                                managerIged.updateIged(u);
                                idUgel = u.IdIged;
                            }

                            if (eRegistroRequest.suspencionCancelacion != null)
                            {
                                suspensionCancelacion.IdSuspCanc = 0;
                                suspensionCancelacion.IdRegistro = eRegistroRequest.IdRegistro;
                                suspensionCancelacion.IdOrigenSuspCanc = eRegistroRequest.suspencionCancelacion.origenSuspencionCancelacion.IdOrigenSuspCanc;
                                suspensionCancelacion.IdTipoSuspCanc = managerTipoSuspensionCancelacion.ObtenerTipoSuspCancPorCodigo(codSuspCanc).IdTipoSuspCanc;
                                suspensionCancelacion.FechaSuspension = fechaHoy;
                                suspensionCancelacion.MotivoSuspension = eRegistroRequest.suspencionCancelacion.MotivoSuspension;
                                suspensionCancelacion.UsuCreacion = usuario;
                                suspensionCancelacion.FechaCreacion = fechaHoy;
                                suspensionCancelacion.EsActivo = true;
                                suspensionCancelacion.EsBorrado = false;

                                managerSuspensionCancelacion.saveSuspensionCancelacion(suspensionCancelacion);
                            }                            

                            responseService.MensajePrincipal = "Los datos se guardaron correctamente";
                            responseService.idRegistro = idRegistro;
                            responseService.ResultValid = true;

                            return responseService;
                        }
                        else
                        {
                            responseService.MensajePrincipal = "El registro que desea suspender no existe en la BD";
                            responseService.idRegistro = eRegistroRequest.IdRegistro;
                            responseService.ResultValid = false;

                            return responseService;
                        }
                    }
                    catch (Exception e)
                    {
                        responseService.MensajePrincipal = "Error en _ObtenerRegistroPorId_update_registro";
                        responseService.idRegistro = idRegistro;
                        responseService.ResultValid = false;

                        return responseService;
                    }                    
                }                
            }

            responseService.MensajePrincipal = "Los datos del registro que desea suspender no son correctos";
            responseService.idRegistro = 0;
            responseService.ResultValid = false;

            return responseService;
        }
    }
}
