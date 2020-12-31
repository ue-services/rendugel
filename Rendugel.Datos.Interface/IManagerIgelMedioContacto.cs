using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerIgelMedioContacto
    {
        IgelMedioContacto ObtenerIgelMedioContactoPorId(int id);
        int saveIgelMedioContacto(IgelMedioContacto igelMedioContacto);
        void updateIgelMedioContacto(IgelMedioContacto igelMedioContacto);
        IEnumerable<IgelMedioContacto> ObtenerListaIgelMedioContactoPorUgel(string codUgel);
    }
}
