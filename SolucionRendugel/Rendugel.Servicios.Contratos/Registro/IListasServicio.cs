using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Servicios.Contratos.Registro
{
    [ServiceContract]
    public interface IListasServicio
    {
        [OperationContract]
        IEnumerable<TipoIged> ObtenerListaTipoIgedSP();

        [OperationContract]
        IEnumerable<TipoIged> ObtenerListaTipoIgedEF();

        [OperationContract]
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoSP();

        [OperationContract]
        IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativoEF();

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralSP();

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralEF();

        [OperationContract]
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroSP();

        [OperationContract]
        IEnumerable<TipoRegistro> ObtenerListaTipoRegistroEF();

        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListasUbigeoSP();

        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListasUbigeoEF();

        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListaLocalidadSP();

        [OperationContract]
        IEnumerable<Ubigeo> ObtenerListaLocalidadEF();

        [OperationContract]
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoSP();

        [OperationContract]
        IEnumerable<TipoDocumento> ObtenerListaTipoDocumentoEF();

        [OperationContract]
        IEnumerable<Iged> ObtenerListaUgelesSP();

        [OperationContract]
        IEnumerable<Iged> ObtenerListaUgelesEF();

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaSP(int idNaturalea);

        [OperationContract]
        IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturalezaEF(int idNaturalea);
    }
}
