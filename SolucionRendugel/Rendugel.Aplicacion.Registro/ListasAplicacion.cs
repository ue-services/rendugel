using Rendugel.Aplicacion.Interfaces;
using Rendugel.Dominio;
using Rendugel.Dominio.Entidades.Modelo;
using System.Collections.Generic;

namespace Rendugel.Aplicacion.Registro
{
    public class ListasAplicacion: IListasAplicacion
    {
        readonly GeneralUnitOfWork generalUnitOfWork = new GeneralUnitOfWork();
        readonly GeneralRepositorio generalRepositorio = new GeneralRepositorio();

        public IEnumerable<TipoIged> ObtenerListaTipoIgedSP()
        {
            var items = generalUnitOfWork.ObtenerListaTipoIged();
            return items;
        }
        public IEnumerable<TipoIged> ObtenerListaTipoIgedEF()
        {
            var items = generalRepositorio.ObtenerListaTipoIged();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoSP()
        {
            var items = generalUnitOfWork.ObtenerListaNaturalezaActoAdministrativo();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoEF()
        {
            var items = generalRepositorio.ObtenerListaNaturalezaActoAdministrativo();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralEF()
        {
            var items = generalRepositorio.ObtenerListaEventoRegistral();
            return items;
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistroSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistroEF()
        {
            var items = generalRepositorio.ObtenerListaTipoRegistro();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeoSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeoEF()
        {
            var items = generalRepositorio.ObtenerListasUbigeo();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidadSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidadEF()
        {
            var items = generalRepositorio.ObtenerListaLocalidad();
            return items;
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoEF()
        {
            var items = generalRepositorio.ObtenerListaTipoDocumento();
            return items;
        }

        public IEnumerable<Iged> ObtenerListaUgelesSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Iged> ObtenerListaUgelesEF()
        {
            var items = generalRepositorio.ObtenerListaUgeles();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaSP(int idNaturalea)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaEF(int idNaturalea)
        {
            var items = generalRepositorio.ObtenerListaEventoRegistralPorIdNaturaleza(idNaturalea);
            return items;
        }
    }
}
