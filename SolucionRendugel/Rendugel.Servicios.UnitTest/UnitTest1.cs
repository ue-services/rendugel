using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Servicios.Servicio.Registro;

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
    }
}
