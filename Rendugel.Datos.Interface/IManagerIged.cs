using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerIged
    {
        /// <summary>
        ///La inclusión CD en el nombre de la función indica "Codigo, Descripción",
        /// es decir, para el caso, obtener lista de códigos y descripciones de "Iged" por código de tipoIged
        /// </summary>
        IEnumerable<EIged> ObtenerListaCDIgedPorCodTipoIged(int codTipoIged);
        IEnumerable<EIged> ObtenerListaUgelesInvolucradas(int IdDre, int IdUgel); //todas las ugeles de la DRE, excepto la ugel del registro.
        IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(int IdUgel);
        IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre);
        int saveIged(Iged iged);
        void updateIged(Iged iged);
        Iged ObtenerIgedPorId(int idIged);
        Iged ObtenerIgedOrigenPorIdRegistro(int idRegistro);

    }
}
