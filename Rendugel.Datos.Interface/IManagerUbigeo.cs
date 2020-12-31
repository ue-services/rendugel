using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerUbigeo
    {
        /// <summary>
        ///
        /// </summary>
        ERegion ObtenerRegionPorDre(int IdDre);
        IEnumerable<EProvincia> ObtenerProvinciasPorRegion(string codUbigeoRegion);
        IEnumerable<EDistrito> ObtenerDistritosPorRegion(string codUbigeoRegion);
        IEnumerable<EDistrito> ObtenerDistritosPorProvincia(string codUbigeoProvincia);
        IEnumerable<EDistrito> ObtenerDistritosPorListaProvincias(List<EProvincia>listaProvincias);
        IEnumerable<EDistrito> ObtenerDistritosPorListaIdDistritos(List<EDistrito> listaIdDistritos);
        IEnumerable<EDistrito> ObtenerDistritosPorRegionNoIncluidosEnLasProvincias(string codUbigeoRegion, List<EProvincia> listaProvincias);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorListaDistrito(List<EDistrito> listaDistritos);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorListaCCPP(List<ECentroPoblado> listaCCPP);
        IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito);
    }
}
