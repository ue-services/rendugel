using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerPersonal
    {
        int savePersonal(Personal personal);
        void updatePersonal(Personal personal);
        void saveListaPersonal(List<Personal> listaPersonal);
        Personal getPersonalPorCodTipoPersona(int codTipoPersonal, string codUgel);
        Personal getPersonalPorCodTipoPersonaIdUgel(int codTipoPersonal, int idUgel);
        int remplazarPersonal(Personal personalABaja, Personal personalNuevo);
        int actualizarPersonal(Personal personal);
    }
}
