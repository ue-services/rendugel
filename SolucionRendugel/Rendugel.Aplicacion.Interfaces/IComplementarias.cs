using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Aplicacion.Interfaces
{
    public interface IComplementarias
    {
        EJurisdiccion GenerarEnunciadoJurisdiccion(EJurisdiccion eJurisdiccion);
        ValidacionResponse validarExtension(string fileName, string extension);

        ValidacionResponse validarFidelidad(Stream dataResult);
        ValidacionResponse validarTamanio(Stream dataResult, long maximo);
    }


}
