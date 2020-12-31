using Rendugel.Aplicacion.Registro;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Servicios.Contratos.Registro;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Rendugel.Servicios.Servicio.Registro
{
    public class ListasServicio: IListasServicio
    {
        readonly ListasAplicacion listasAplicacion = new ListasAplicacion();

        //public static void Configure(ServiceConfiguration config)
        //{
        //}
        public IEnumerable<TipoIged> ObtenerListaTipoIgedSP()
        {
            var items = listasAplicacion.ObtenerListaTipoIgedSP();
            return items;
        }
        public IEnumerable<TipoIged> ObtenerListaTipoIgedEF()
        {
            var items = listasAplicacion.ObtenerListaTipoIgedEF();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoSP()
        {
            var items = listasAplicacion.ObtenerListaNaturalezaActoAdministrativoSP();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoEF()
        {
            var items = listasAplicacion.ObtenerListaNaturalezaActoAdministrativoEF();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralEF() 
        {
            var items = listasAplicacion.ObtenerListaEventoRegistralEF();
            return items;
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistroSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistroEF()
        {
            var items = listasAplicacion.ObtenerListaTipoRegistroEF();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeoSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeoEF()
        {
            var items = listasAplicacion.ObtenerListasUbigeoEF();
            return items;
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidadSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidadEF()
        {
            var items = listasAplicacion.ObtenerListaLocalidadEF();
            return items;
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoEF()
        {
            var items = listasAplicacion.ObtenerListaTipoDocumentoEF();
            return items;
        }

        public IEnumerable<Iged> ObtenerListaUgelesSP()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Iged> ObtenerListaUgelesEF()
        {
            var items = listasAplicacion.ObtenerListaUgelesEF();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaSP(int idNaturalea)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaEF(int idNaturalea)
        {
            var items = listasAplicacion.ObtenerListaEventoRegistralPorIdNaturalezaEF(idNaturalea);
            return items;
        }
    }
}
