using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerIgedBasicos
    {
        IgedBasicos ObtenerIgedBasicosPorIgedPorEstado(int idIged,bool estado);
        IgedBasicos ObtenerIgedBasicosPorIdRegistro(int idRegistro);
        int saveIgedBasicos(IgedBasicos igedBasicos);
        void updateIgedBasicos(IgedBasicos igedBasicos);
        void saveListaIgedBasicos(List<IgedBasicos> listaIgedBasicos);
        void darBajaIgedBasicos(int idIgedBasicos);
        int remplazaIgedBasicos(IgedBasicos igedBasicosABaja, IgedBasicos igedBasicosNuevo);
    }
}
