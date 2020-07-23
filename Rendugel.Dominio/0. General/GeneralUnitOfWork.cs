using Rendugel.Datos.Modelo;
using Rendugel.Datos.Repositorio;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Dominio
{
    public class GeneralUnitOfWork: IGeneralUnitOfWork
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new rendugelDBContext());

        #region Listas

        public IEnumerable<TipoIged> ObtenerListaTipoIged()
        {
            var items = unitOfWork.ExecuteReader<TipoIged>("[USP_RENDUGEL_LISTA_TIPOIGED]", null).ToList();
            return items;
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativo()
        {
            var items = unitOfWork.ExecuteReader<NaturalezaEvento>("[USP_RENDUGEL_LISTA_NATURALEZAACTOADMINISTRATIVO]", null).ToList();
            return items;
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistral()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistro()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidad()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumento()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Iged> ObtenerListaUgeles()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}