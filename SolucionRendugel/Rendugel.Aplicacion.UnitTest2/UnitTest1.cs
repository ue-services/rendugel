using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Aplicacion.Registro;
using Rendugel.Dominio.Entidades.Modelo;

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
    }
}
