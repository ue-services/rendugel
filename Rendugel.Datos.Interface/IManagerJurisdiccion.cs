using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerJurisdiccion
    {
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionDeUgelesPorDre(int IdDre);

        int ActualizarRegistrosDeJurisdiccion(List<JurisdiccionIged> listaJurisdiccion, List<EIged> listaIged);
        IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel);
        IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel);
    }
}
