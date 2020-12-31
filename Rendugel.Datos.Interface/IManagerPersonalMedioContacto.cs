using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerPersonalMedioContacto
    {
        PersonalMedioContacto ObtenerPersonalMedioContactoPorId(int id);
        int SavePersonalMedioContacto(PersonalMedioContacto personalMedioContacto);
        void UpdatePersonalMedioContacto(PersonalMedioContacto personalMedioContacto);
        void SaveListaPersonalMedioContacto(List<PersonalMedioContacto> listaPersonalMedioContacto);
        IEnumerable<PersonalMedioContacto> ObtenerListaIgelPersonalMedioContactoPorId(int idPersonal);
        int ActualizarRegistrosDeMediosContacto(List<PersonalMedioContacto> listaPersonalMedioContacto, int idPersonal);
    }
}
