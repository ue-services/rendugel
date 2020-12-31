using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerDependenciaUnidadEjecutora
    {
        int saveDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutora);
        void updateDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutora);
        int RemplazarDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutoraABaja, DependeciaUnidadEjecutora dependenciaUnidadEjecutoraNueva);
        void DarBajaDependenciaUnidadEjecutora(int idDependencia);
        DependeciaUnidadEjecutora ObtenerDependenciaUnidadEjecutoraPorId(int idDependencia);
        DependeciaUnidadEjecutora ObtenerDependenciaUnidadEjecutoraActivaPorIdUgel(int idUgel);
    }
}
