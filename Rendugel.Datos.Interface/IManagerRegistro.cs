using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerRegistro
    {
        int saveRegistro(Registro registro);
        void updateRegistro(Registro registro);
        ResponseService elimarRegistro(int idRegistro);
        int saveDocumento(Documento documento);
        int saveIged(Iged iged);
        void updateIged(Iged iged);
        int saveIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle);
        int saveDocumentoRegistro(DocumentoRegistro documentoRegistro);

        void updateDocumento(Documento documento);

        int saveLocalIged(LocalIged localIged);
        int saveJurisdiccionIged(JurisdiccionIged jurisdiccionIged);
        int savePersona(Persona persona);
        int savePersonal(Personal personal);
        int savePersonalMedioContacto(PersonalMedioContacto personalMedioContacto);
        int saveIgedMedioContacto(IgedMedioContacto igelMedioContacto);
        int saveUnidadEjecutora(UnidadEjecutora unidadEjecutora);
        int saveDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependeciaUnidadEjecutora);
        int saveIgedBasicos(IgedBasicos igedBasicos);

        ResponseService saveRegistroProvisional(RegistroResponse registroResoponse);
        IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro);
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales(); 
        IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro);

        IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja);
        Registro _ObtenerRegistroPorId(int idRegistro);           
        IEnumerable<IgedRegistroDetalle>_ObtenerRegistroDetallePorIdRegistro(int idRegistro);
        IEnumerable<DocumentoRegistro> _ObtenerDocumentoRegistroPorIdRegistro(int idRegistro);
        ResponseService pasarADefinitivo(RegistroDefinitivoResponse registroDefinitivoResponse);

    }
}
