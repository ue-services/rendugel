using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Datos.Modelo;
using Rendugel.Datos.Repositorio;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Response;

namespace Rendugel.Dominio.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void obtenerTemporal()
        {
            UploadTempResponse uploadTempResponse = new UploadTempResponse();
            DocumentoTem documentoTem = new DocumentoTem();
            string usuario = "40615837";

            EDocumentoTem eDocumentoTem = new EDocumentoTem();
            ManagerDocumentoTem managerDocumentoTem = new ManagerDocumentoTem();

            string finalidad = "DeCreacion";

            eDocumentoTem.IdDocumentoTem = 0;
            eDocumentoTem.NombreArchivo = "xxx";
            eDocumentoTem.Ruta = "xxx"; // path.ToString();
            eDocumentoTem.Finalidad = finalidad;

            documentoTem = managerDocumentoTem.ObtenerDocumentoPorUsurioFinalidad(usuario, eDocumentoTem.Finalidad);

            var result = documentoTem.IdDocumentoTem;
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void GrabarTemporal2()
        {
            EDocumentoTem documentoTem = new EDocumentoTem();

            documentoTem.IdDocumentoTem = 2;
            documentoTem.NombreArchivo = "xxx"; // fileStream.Name;
            documentoTem.Ruta = "xxx";// path.ToString();
            documentoTem.Finalidad = "DeCreacion";

            UploadTempResponse uploadTempResponse = new UploadTempResponse();

            EDocumentoTem _documentoTem = new EDocumentoTem();
            ComunRegistroRepositorio comunRegistroRepositorio = new ComunRegistroRepositorio();

            uploadTempResponse = comunRegistroRepositorio.GrabarDatosDocumentoTemporal(documentoTem);                

            documentoTem = uploadTempResponse.data;
            Assert.IsNotNull(documentoTem);
        }

        /* [TestMethod]
         public void TestMethod1()
         {
             var _iged = new Iged();
             using (var _contexDB = new rendugelDBContext() )
             {
                 _iged = _contexDB.Iged.FirstOrDefault();
             }
             var result = _iged.IdIged;
             Assert.AreEqual(result, 1);
         }

         [TestMethod]
         public void TestMethod2()
         {
             List<Iged> _listaIged = new List<Iged>();
             using (var _contexDB = new rendugelDBContext())
             {
                 _listaIged = _contexDB.Iged.ToList();
             }
             var result = _listaIged.Count();
             Assert.AreEqual(result, 246);
         }


         [TestMethod]
         public void TestMethod3()
         {   
             GeneralUnitOfWork generalUnitOfWork = new GeneralUnitOfWork();
             List<TipoIged> _listaTipoIged = new List<TipoIged>();

             _listaTipoIged = generalUnitOfWork.ObtenerListaTipoIged().ToList();

             var result = _listaTipoIged.Count();
             Assert.AreEqual(result, 2);
         }

         [TestMethod]
         public void TestMethod4()
         {
             GeneralUnitOfWork generalUnitOfWork = new GeneralUnitOfWork();
             List<TipoIged> _listaTipoIged = new List<TipoIged>();

             _listaTipoIged = generalUnitOfWork.ObtenerListaTipoIged().ToList();

             var result = _listaTipoIged.Count();
             Assert.AreEqual(result, 2);
         }

         [TestMethod]
         public void TestMethod5()
         {
             ComunRegistroRepositorio comunRegistroRepositorio = new ComunRegistroRepositorio();
             List<JurisdiccionIged> ListaJurisdiccion  = new List<JurisdiccionIged>();

             JurisdiccionIged jurisdiccion = new JurisdiccionIged
             {
                 IdJurisdiccion = 1002,
                 IdIged = 98,
                 IdTerminoPertenencia = 1,
                 IdTerminoCantidad = 2,
                 IdUbigeo = 93,
                 UsuCreacion = "40615837",
                 FechaCreacion = DateTime.Now,
                 EsActivo = true,
                 EsBorrado = false
             };

             ListaJurisdiccion.Add(jurisdiccion);

             JurisdiccionIged jurisdiccion2 = new JurisdiccionIged();
             jurisdiccion2.IdJurisdiccion = 1003;
             jurisdiccion2.IdIged = 99;
             jurisdiccion2.IdTerminoPertenencia = 1;
             jurisdiccion2.IdTerminoCantidad = 2;
             jurisdiccion2.IdUbigeo = 94;
             jurisdiccion2.UsuCreacion = "40615837";
             jurisdiccion2.FechaCreacion = DateTime.Now;
             jurisdiccion2.EsActivo = true;
             jurisdiccion2.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion2);

             //JurisdiccionIged jurisdiccion3 = new JurisdiccionIged();
             //jurisdiccion3.IdJurisdiccion = 0;
             //jurisdiccion3.IdIged = 100;
             //jurisdiccion3.IdTerminoPertenencia = 1;
             //jurisdiccion3.IdTerminoCantidad = 2;
             //jurisdiccion3.IdUbigeo = 95;
             //jurisdiccion3.UsuCreacion = "40615837";
             //jurisdiccion3.FechaCreacion = DateTime.Now;
             //jurisdiccion3.EsActivo = true;
             //jurisdiccion3.EsBorrado = false;

             //ListaJurisdiccion.Add(jurisdiccion3);

             JurisdiccionIged jurisdiccion4 = new JurisdiccionIged();
             jurisdiccion4.IdJurisdiccion = 1005;
             jurisdiccion4.IdIged = 101;
             jurisdiccion4.IdTerminoPertenencia = 1;
             jurisdiccion4.IdTerminoCantidad = 2;
             jurisdiccion4.IdUbigeo = 96;
             jurisdiccion4.UsuCreacion = "40615837";
             jurisdiccion4.FechaCreacion = DateTime.Now;
             jurisdiccion4.EsActivo = true;
             jurisdiccion4.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion4);

             JurisdiccionIged jurisdiccion5 = new JurisdiccionIged();
             jurisdiccion5.IdJurisdiccion = 1006;
             jurisdiccion5.IdIged = 102;
             jurisdiccion5.IdTerminoPertenencia = 1;
             jurisdiccion5.IdTerminoCantidad = 2;
             jurisdiccion5.IdUbigeo = 97;
             jurisdiccion5.UsuCreacion = "40615837";
             jurisdiccion5.FechaCreacion = DateTime.Now;
             jurisdiccion5.EsActivo = true;
             jurisdiccion5.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion5);

             //JurisdiccionIged jurisdiccion6 = new JurisdiccionIged();
             //jurisdiccion6.IdJurisdiccion = 0;
             //jurisdiccion6.IdIged = 103;
             //jurisdiccion6.IdTerminoPertenencia = 1;
             //jurisdiccion6.IdTerminoCantidad = 2;
             //jurisdiccion6.IdUbigeo = 98;
             //jurisdiccion6.UsuCreacion = "40615837";
             //jurisdiccion6.FechaCreacion = DateTime.Now;
             //jurisdiccion6.EsActivo = true;
             //jurisdiccion6.EsBorrado = false;

             //ListaJurisdiccion.Add(jurisdiccion6);

             JurisdiccionIged jurisdiccion7 = new JurisdiccionIged();
             jurisdiccion7.IdJurisdiccion = 1008;
             jurisdiccion7.IdIged = 104;
             jurisdiccion7.IdTerminoPertenencia = 1;
             jurisdiccion7.IdTerminoCantidad = 2;
             jurisdiccion7.IdUbigeo = 99;
             jurisdiccion7.UsuCreacion = "40615837";
             jurisdiccion7.FechaCreacion = DateTime.Now;
             jurisdiccion7.EsActivo = true;
             jurisdiccion7.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion7);

             JurisdiccionIged jurisdiccion8 = new JurisdiccionIged();
             jurisdiccion8.IdJurisdiccion = 1009;
             jurisdiccion8.IdIged = 105;
             jurisdiccion8.IdTerminoPertenencia = 1;
             jurisdiccion8.IdTerminoCantidad = 2;
             jurisdiccion8.IdUbigeo = 100;
             jurisdiccion8.UsuCreacion = "40615837";
             jurisdiccion8.FechaCreacion = DateTime.Now;
             jurisdiccion8.EsActivo = true;
             jurisdiccion8.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion8);

             JurisdiccionIged jurisdiccion9 = new JurisdiccionIged();
             jurisdiccion9.IdJurisdiccion = 1010;
             jurisdiccion9.IdIged = 106;
             jurisdiccion9.IdTerminoPertenencia = 1;
             jurisdiccion9.IdTerminoCantidad = 2;
             jurisdiccion9.IdUbigeo = 101;
             jurisdiccion9.UsuCreacion = "40615837";
             jurisdiccion9.FechaCreacion = DateTime.Now;
             jurisdiccion9.EsActivo = true;
             jurisdiccion9.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion9);

             JurisdiccionIged jurisdiccion10 = new JurisdiccionIged();
             jurisdiccion10.IdJurisdiccion = 1011;
             jurisdiccion10.IdIged = 107;
             jurisdiccion10.IdTerminoPertenencia = 1;
             jurisdiccion10.IdTerminoCantidad = 2;
             jurisdiccion10.IdUbigeo = 102;
             jurisdiccion10.UsuCreacion = "40615837";
             jurisdiccion10.FechaCreacion = DateTime.Now;
             jurisdiccion10.EsActivo = true;
             jurisdiccion10.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion10);

             JurisdiccionIged jurisdiccion11 = new JurisdiccionIged();
             jurisdiccion11.IdJurisdiccion = 1012;
             jurisdiccion11.IdIged = 108;
             jurisdiccion11.IdTerminoPertenencia = 1;
             jurisdiccion11.IdTerminoCantidad = 2;
             jurisdiccion11.IdUbigeo = 103;
             jurisdiccion11.UsuCreacion = "40615837";
             jurisdiccion11.FechaCreacion = DateTime.Now;
             jurisdiccion11.EsActivo = true;
             jurisdiccion11.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion11);

             JurisdiccionIged jurisdiccion12 = new JurisdiccionIged();
             jurisdiccion12.IdJurisdiccion = 1013;
             jurisdiccion12.IdIged = 109;
             jurisdiccion12.IdTerminoPertenencia = 1;
             jurisdiccion12.IdTerminoCantidad = 2;
             jurisdiccion12.IdUbigeo = 104;
             jurisdiccion12.UsuCreacion = "40615837";
             jurisdiccion12.FechaCreacion = DateTime.Now;
             jurisdiccion12.EsActivo = true;
             jurisdiccion12.EsBorrado = false;

             ListaJurisdiccion.Add(jurisdiccion12);

             List<EIged> listaIGed = new List<EIged>();

             EIged iged1 = new EIged{IdIged = 98};
             EIged iged2 = new EIged{IdIged = 99};
             EIged iged3 = new EIged { IdIged = 100 };
             EIged iged4 = new EIged { IdIged = 101 };
             EIged iged5 = new EIged { IdIged = 102 };
             EIged iged6 = new EIged { IdIged = 103 };
             EIged iged7 = new EIged { IdIged = 104 };
             EIged iged8 = new EIged { IdIged = 105 };
             EIged iged9 = new EIged { IdIged = 106 };
             EIged iged10 = new EIged { IdIged = 107 };
             EIged iged11 = new EIged { IdIged = 108 };
             EIged iged12 = new EIged { IdIged = 109 };

             listaIGed.Add(iged1);
             listaIGed.Add(iged2);
             listaIGed.Add(iged3);
             listaIGed.Add(iged4);
             listaIGed.Add(iged5);
             listaIGed.Add(iged6);
             listaIGed.Add(iged7);
             listaIGed.Add(iged8);
             listaIGed.Add(iged9);
             listaIGed.Add(iged10);
             listaIGed.Add(iged11);
             listaIGed.Add(iged12);

             var result = comunRegistroRepositorio.ActualizarRegistrosDeJurisdiccion(ListaJurisdiccion, listaIGed);

             Assert.AreEqual(result, 1);
         }*/
    }
}
