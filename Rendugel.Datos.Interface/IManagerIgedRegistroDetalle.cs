using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Interface
{
    public interface IManagerIgedRegistroDetalle
    {
        int saveIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle);
        void updateIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle);
        void saveListaIgedRegistroDetalle(List<IgedRegistroDetalle> listaIgedRegistroDetalle);
        IgedRegistroDetalle getIgedRegistroDetallePorCodUgel(string codUgel);
        IgedRegistroDetalle getIgedRegistroDetallePorIdRegistro(int idRegistro);
        IgedRegistroDetalle getIgedRegistroDetalleOrigenPorIdRegistro(int idRegistro);
        int ActualizarRegDetalleOrigen(IgedRegistroDetalle igedRegistroDetalle);
    }
}
