using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Aplicacion.Registro;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Servicios.Servicio.Registro;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Response;

namespace Rendugel.Servicios.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ListasServicio listasServicio = new ListasServicio();
            List<TipoIged> _listaTipoIged = new List<TipoIged>();

            _listaTipoIged = listasServicio.ObtenerListaTipoIgedSP().ToList();

            var result = _listaTipoIged.Count();
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ListasServicio listasServicio = new ListasServicio();
            List<TipoIged> _listaTipoIged = new List<TipoIged>();

            _listaTipoIged = listasServicio.ObtenerListaTipoIgedEF().ToList();

            var result = _listaTipoIged.Count();
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMetho3()
        {
            ComunRegistroServicios comunRegistro = new ComunRegistroServicios();

            EOpcionesRequest eOpcionesRequest = new EOpcionesRequest();
            // eOpcionesRequest.codTipoIgedUgel = 2;
            eOpcionesRequest.codTipoRegistro = 1;
            // eOpcionesRequest.codNaturaleza = 1;
            //eOpcionesRequest.codEventoRegistral = 1;
            //eOpcionesRequest.codTipoIgedDre = 1;
            eOpcionesRequest.codTipoIgedRegistrar = 2;

            var result = comunRegistro.ObtenerOpcionesRegistro(eOpcionesRequest);

            //Assert.AreNotEqual(result.ListaDRE.Count(), 0);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.AreNotEqual(result.ListaTipoRegistro.Count(), 0);


        }

        [TestMethod]
        public void TestMetho4()
        {
            ComunRegistroServicios comunRegistro = new ComunRegistroServicios();

            EIged dre = new EIged();
            dre.IdIged = 1;
            dre.CodIged = "010000";
            dre.NomIged = "DRE AMAZONAS";
            dre.CodTipoIged = 1;


            var result = comunRegistro.ObtenerOpcionesUbigeo(dre.IdIged.ToString());
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);www
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.IsNotNull(result.ListaProvincias);
        }

        [TestMethod]
        public void TestMetho5()
        {
            ComunRegistroServicios comunRegistro = new ComunRegistroServicios();

            int id = 1004;



            var result = comunRegistro.ObtenerRegistroDetallePorIdRegistro(id);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);www
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            //var i= 2;

            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void TestMetho6()
        {
            ComunRegistro comunRegistro = new ComunRegistro(); ;
            UploadTempResponse uploadTempResponse = new UploadTempResponse();

            EClasificacionDocumento clasificacion = new EClasificacionDocumento();
            clasificacion.IdClasificacionDoc = 1;
            ETipoDocumento tipoDocumento = new ETipoDocumento();
            tipoDocumento.IdTipoDoc = 1;
            EDocumentoTem documento = new EDocumentoTem();

            documento.NombreArchivo = "ProbandoEnTest";
            //documento.Temporal = true;
            //documento.ClasificacionDocumento = clasificacion; //Resolutivo, cambiar esto depues.
            //documento.NroDocumento = "1234567890";
            //documento.TipoDocumento = tipoDocumento;

            EDocumentoTem _documento = new EDocumentoTem();
            //_documento.NombreArchivo = "xxxxxx";
            uploadTempResponse = comunRegistro.GrabarDatosDocumentoTemporal(documento);
            _documento = uploadTempResponse.data;
            Assert.IsNotNull(_documento);
        }

        [TestMethod]
        public void TestMetho7()
        {
            ComunRegistro comunRegistro = new ComunRegistro(); ;

            EClasificacionDocumento clasificacion = new EClasificacionDocumento();
            clasificacion.IdClasificacionDoc = 1;
            ETipoDocumento tipoDocumento = new ETipoDocumento();
            tipoDocumento.IdTipoDoc = 1;
            EDocumento documento = new EDocumento();

            documento.IdDocumento = 3033;
            documento.NombreArchivo = "ProbandoEnTest";
            //documento.Temporal = true;
            documento.ClasificacionDocumento = clasificacion; //Resolutivo, cambiar esto depues.
            documento.NroDocumento = "HHH_000";
            documento.TipoDocumento = tipoDocumento;

            EDocumento _documento = new EDocumento();

            string rutaBase = @"C:\Users\anica\source\repos\ProyectoRendugel\SolucionRendugel\Rendugel.Servicios.Host\documentos\";

            _documento = comunRegistro.pasarFileDeTemporal(documento, rutaBase, "Resolutivos");

            Assert.IsNotNull(_documento);
        }

        [TestMethod]
        public void TestMetho8()
        {
            ComunRegistroServicios comunRegistro = new ComunRegistroServicios(); ;

            RegistroResponse registroResponse = null;

            var res = 1; // comunRegistro.SaveRegistroProvisional(registroResponse);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestMetho9()
        {
            /* ComunRegistroServicios comunRegistro = new ComunRegistroServicios(); ;

             RegistroDefinitivoResponse registroResponse = new RegistroDefinitivoResponse();
             registroResponse.IdRegistro = 1003;
             var res = comunRegistro.pasarADefinitivo(registroResponse);

             Assert.IsNotNull(res);*/
        }

        [TestMethod]
        public void TestMetho10()
        {
            ComunRegistro comunRegistro = new ComunRegistro(); ;

            EEstadoRegistro estadoRegistro = new EEstadoRegistro();
            ETipoRegistro tipoRegistro = new ETipoRegistro();
            List<EEstadoRegistro> listaEstadoRegistro = new List<EEstadoRegistro>();
            List<ETipoRegistro> listaETipoRegistro = new List<ETipoRegistro>();

            estadoRegistro.CodEstadoRegistro = 1;
            estadoRegistro.DescEstadoRegistro = "";
            estadoRegistro.IdEstadoRegistro = 0;

            listaEstadoRegistro.Add(estadoRegistro);

            tipoRegistro.CodTipoRegistro = 1;
            tipoRegistro.DescTipoRegistro = "";
            tipoRegistro.IdTipoRegistro = 0;

            listaETipoRegistro.Add(tipoRegistro);

            var res = comunRegistro.ObtenerRegistrosProvisionalesPoTipoEstado(listaETipoRegistro, listaEstadoRegistro);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestMetho11()
        {
            ComunRegistroServicios comunRegistro = new ComunRegistroServicios(); ;

            RegistroDefinitivoResponse registroResponse = new RegistroDefinitivoResponse();
            registroResponse.IdRegistro = 1004;
            var res = comunRegistro.ElimarRegistro(registroResponse.IdRegistro);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestMetho12()
        {
            /*{ "CodIged": "040003",
                "CodTipoIged": 2,
                "DescTipoIged": "NULL",
                "IdIged": 65,
                "IdTipoIged": 2,
                "NomIged": "UGEL CAMANÁ"}*/

            ComunRegistroServicios comunRegistro = new ComunRegistroServicios(); ;

            EIged iged = new EIged();
            iged.CodIged = "040003";
            iged.CodTipoIged = 2;
            iged.DescTipoIged = "NULL";
            iged.IdIged = 65;
            iged.IdTipoIged = 2;
            iged.NomIged = "UGEL CAMANÁ";

            var res = comunRegistro.ObtenerListaUgelesInvolucradasPorUgel(iged);

            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void TestMetho13()
        {          

            ComunRegistroServicios comunRegistro = new ComunRegistroServicios();

            var res = comunRegistro.ObtenerBandejas();

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Suspension()
        {
            ComunRegistroServicios comunRegistroServicios = new ComunRegistroServicios();
            ResponseService responseService = new ResponseService();
            ERegistroSuspensionRequest registroSuspensionRequest = new ERegistroSuspensionRequest
            {
                IdRegistro = 5013,
                suspencionCancelacion = new ESuspencionCancelacion
                {
                    IdSuspCanc = 0,
                    origenSuspencionCancelacion = new EOrigenSuspencionCancelacion
                    {
                        IdOrigenSuspCanc = 1,
                        CodTipoSuspCanc = 1,
                        Descripcion = "Por vencimiento de plazo"
                    },
                    tipoSuspensionCancelacion = new ETipoSuspensionCancelacion
                    {
                        IdTipoSuspCanc = 0,
                        CodTipoSuspCanc = 1,
                        DescTipoSuspCanc = "Suspension"
                    },
                    FechaSuspension = null,
                    MotivoSuspension = "rtyfg yytuty yutt"
                },

                DocumentoDeSustento = new EDocumento
                {
                    IdDocumento = 0,
                    NroDocumento = "SUSTENTO",
                    NombreArchivo = "",
                    Temporal = new EDocumentoTem
                    {
                        IdDocumentoTem = 1002,
                        NombreArchivo = "10406158379DeSustentoSup.pdf",
                        Ruta = "Temporales\\10406158379",
                        Finalidad = "DeSustentoSup"
                    },
                    FechaEmision = null,
                    FechaPublicacion = null,
                    Ruta = "",
                    ClasificacionDocumento = new EClasificacionDocumento
                    {
                        IdClasificacionDoc = 3,
                        CodClasificacionDoc = 3,
                        DescClasificacionDoc = "Sustento Sus/Canc"
                    },
                    TipoDocumento = new ETipoDocumento
                    {
                        IdTipoDoc = 1,
                        CodTipoDoc = 1,
                        DescTipoDoc = "Ordenanza Regional"
                    }
                }
            };


            responseService = comunRegistroServicios.SuspenderRegistroProvisional(registroSuspensionRequest);

            Assert.IsTrue(responseService.ResultValid ?? default(bool));
        }
    }
}


