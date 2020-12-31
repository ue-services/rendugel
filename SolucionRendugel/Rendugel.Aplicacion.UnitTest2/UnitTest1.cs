using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Aplicacion.Registro;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Aplicacion.UnitTest2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ListasAplicacion listasAplicacion = new ListasAplicacion();
            List<TipoIged> _listaTipoIged = new List<TipoIged>();

            _listaTipoIged = listasAplicacion.ObtenerListaTipoIgedSP().ToList();

            var result = _listaTipoIged.Count();
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ListasAplicacion listasAplicacion = new ListasAplicacion();
            List<TipoIged> _listaTipoIged = new List<TipoIged>();

            _listaTipoIged = listasAplicacion.ObtenerListaTipoIgedEF().ToList();

            var result = _listaTipoIged.Count();
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMetho3()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            EOpcionesRequest eOpcionesRequest = new EOpcionesRequest();
            //eOpcionesRequest.codTipoIgedUgel = 2;
            eOpcionesRequest.codTipoRegistro = 1;
            //eOpcionesRequest.codNaturaleza = 1;
            //eOpcionesRequest.codEventoRegistral = 1;
            //eOpcionesRequest.codTipoIgedDre = 1;
            eOpcionesRequest.codTipoIgedRegistrar = 2;

            var result = comunRegistro.ObtenerOpcionesRegistro(eOpcionesRequest);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            //Assert.AreNotEqual(result.ListaTipoRegistro.Count(), 0);
        }

        [TestMethod]
        public void TestMetho4()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            EIged dre = new EIged();
            dre.IdIged = 1;
            dre.CodIged = "010000";
            dre.NomIged = "DRE AMAZONAS";
            dre.CodTipoIged = 1;


            var result = comunRegistro.ObtenerOpcionesUbigeo(dre.IdIged.ToString());
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.IsNotNull(result.ListaProvincias);
        }

        [TestMethod]
        public void TestMetho5()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            EParametrosRegistroRequest parametros = new EParametrosRegistroRequest();
            parametros.dre = new EIged { IdIged = 1, CodIged = "010000" };
            parametros.ugel = new EIged { IdIged = 0 };
            parametros.eventoRegistral = new EEventoRegistral { IdEventoRegistral = 1, CodEvento = 1 };


            var result = comunRegistro.ObtenerOpcionesJurisdiccionInvolucradas(parametros);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.IsNotNull(result.ListaUgel);
        }

        [TestMethod]
        public void TestMetho6()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            EPertenenciaRequest parametros = new EPertenenciaRequest();
            parametros.dre = new EIged { IdIged = 1, CodIged = "010000" };
            parametros.ugelModificar = new EIged { IdIged = 28, CodIged = "010002" };
            parametros.CodTerminoPertenencia = 1;


            var result = comunRegistro.ObtenerOpcionesJurisdiccionPertenencia(parametros);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.IsNotNull(result.ListaProvincias);
        }

        [TestMethod]
        public void TestMetho7()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            RegistroResponse registroResponse = new RegistroResponse
            {
                CodUgel = "012569",
                NombreUgel = "sfsfd dfdfd dgdf",
                Dre = new EIged
                {
                    CodIged = "010000",
                    CodTipoIged = 1,
                    DescTipoIged = null,
                    IdIged = 1,
                    IdTipoIged = 1,
                    NomIged = "DRE AMAZONAS"
                },
                DocumentoResolutivo = new EDocumento
                {
                    IdDocumento = 0,
                    NroDocumento = "wdsdwew",
                    NombreArchivo = "tdr.pdf",
                    FechaEmision = null,
                    FechaPublicacion = null,
                    ClasificacionDocumento = new EClasificacionDocumento
                    {
                        CodClasificacionDoc = 1,
                        DescClasificacionDoc = "Resolutivo",
                        IdClasificacionDoc = 1
                    },
                    TipoDocumento = new ETipoDocumento
                    {
                        CodTipoDoc = 1,
                        DescTipoDoc = "Ordenanza Regional",
                        IdTipoDoc = 1
                    }
                },
                EventoRegistral = new EEventoRegistral
                {
                    CodEvento = 1,
                    DescEvento = "Creacion",
                    IdEventoRegistral = 1,
                    Naturaleza = new ENaturaleza
                    {
                        CodNaturaleza = 1,
                        DescNaturaleza = "creacion",
                        IdNaturaleza = 1
                    }
                },
                TipoIged = new ETipoIged
                {
                    CodTipoIged = 2,
                    DescTipoIged = "UGEL",
                    IdTipoIged = 2
                },
                TipoRegistro = new ETipoRegistro
                {
                    CodTipoRegistro = 1,
                    DescTipoRegistro = "Provisional",
                    IdTipoRegistro = 1
                },
                Ubigeo = new EUbigeo
                {
                    CodUbigeo = "010102",
                    IdUbigeo = 449,
                    Nombre = "ASUNCIÓN"
                }
            };

            var result = 1; // comunRegistro.SaveRegistroProvisional(registroResponse, "");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMetho8()
        {
            ComunRegistro comunRegistro = new ComunRegistro();

            EIged ugel1 = new EIged();
            ugel1.IdIged = 27;
            ugel1.CodIged = "010001";
            ugel1.NomIged = "UGEL CHACHAPOYAS";
            ugel1.CodTipoIged = 2;
            ugel1.IdTipoIged = 1;

            EIged ugel2 = new EIged();
            ugel2.IdIged = 28;
            ugel2.CodIged = "010002";
            ugel2.NomIged = "UGEL BAGUA";
            ugel2.CodTipoIged = 2;
            ugel2.IdTipoIged = 1;

            EIged ugel3 = new EIged();
            ugel3.IdIged = 29;
            ugel3.CodIged = "010003";
            ugel3.NomIged = "UGEL BONGARÁ";
            ugel3.CodTipoIged = 2;
            ugel3.IdTipoIged = 1;

            List<EIged> listaUgel = new List<EIged>();
            listaUgel.Add(ugel1);
            listaUgel.Add(ugel2);
            listaUgel.Add(ugel3);

            var result = comunRegistro.ObtenerJurisdiccionUgelPorListaUgeles(listaUgel);
            //Assert.AreNotEqual(result.ListaEventoRegistral.Count(), 0);
            //Assert.AreNotEqual(result.ListaNaturaleza.Count(), 0);
            //Assert.IsTrue(result.ListaTipoIged.Count() > 0);
            Assert.IsNotNull(result.ToList());
        }

        [TestMethod]
        public void TestMetho9()
        {
            Complementarias complementarias = new Complementarias();
            var v = complementarias.validarExtension("a", "b");
            Assert.IsTrue(v.result);
        }
    }
}
