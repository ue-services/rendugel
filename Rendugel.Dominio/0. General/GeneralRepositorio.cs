using Rendugel.Dominio.Interfaces;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Modelo;

namespace Rendugel.Dominio
{
    public class GeneralRepositorio : IGeneralRepositorio
    {
        private ManagerGeneralRepositorio mgRepositorio = new ManagerGeneralRepositorio();

        #region Listas

        public IEnumerable<TipoIged> ObtenerListaTipoIged()
        {
            var items = mgRepositorio.ObtenerListaTipoIged().ToList();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativo()
        {
            var items = mgRepositorio.ObtenerListaNaturalezaActoAdministrativo().ToList();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistral()
        {
            var items = mgRepositorio.ObtenerListaEventoRegistral().ToList();
            return items;
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistro()
        {
            var items = mgRepositorio.ObtenerListaTipoRegistro().ToList();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeo()
        {
            var items = mgRepositorio.ObtenerListasUbigeo().ToList();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidad()
        {
            var items = mgRepositorio.ObtenerListaLocalidad().ToList();
            return items;
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumento()
        {
            var items = mgRepositorio.ObtenerListaTipoDocumento().ToList();
            return items;
        }

        public IEnumerable<Iged> ObtenerListaUgeles()
        {
            var items = mgRepositorio.ObtenerListaUgeles().ToList();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturaleza(int idNaturalea)
        {
            var items = mgRepositorio.ObtenerListaEventoRegistralPorIdNaturaleza(idNaturalea).ToList();
            return items;
        }

        #endregion
    }
}
