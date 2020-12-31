using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerIgedMedioContacto
    {
        IgedMedioContacto ObtenerIgedMedioContactoPorId(int id);
        int saveIgedMedioContacto(IgedMedioContacto igedMedioContacto);
        void updateIgedMedioContacto(IgedMedioContacto igedMedioContacto);
        void saveListaIgedMedioContacto(List<IgedMedioContacto> listaIgedMedioContacto);
        IEnumerable<IgedMedioContacto> ObtenerListaIgedMedioContactoPorUgel(string codUgel);
        int ActualizarRegistrosDeMediosContacto(List<IgedMedioContacto> listaIgedMediosContacto, int idIged);
    }
}
