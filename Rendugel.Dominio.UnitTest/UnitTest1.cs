using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;

namespace Rendugel.Dominio.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
    }
}
