﻿using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerTipoPersonal
    {
        ETipoPersonal ObtenerTipoPersonalPorCodigo(int codigo);
        IEnumerable<ETipoPersonal>ObtenerListaTiposPersonalDatosPersonal();
    }
}
