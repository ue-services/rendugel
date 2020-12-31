using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerLocalIged
    {
        int saveLocalIged(LocalIged localIged);
        void updateLocalIged(LocalIged localIged);
        void saveListaLocalIged(List<LocalIged> listaLocalIged);
    }
}
