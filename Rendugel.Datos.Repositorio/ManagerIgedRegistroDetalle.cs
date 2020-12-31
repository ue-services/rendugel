using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerIgedRegistroDetalle : IManagerIgedRegistroDetalle, IDisposable
    {

        public void Dispose()
        {
            return;
        }

        public IgedRegistroDetalle getIgedRegistroDetalleOrigenPorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.IgedRegistroDetalle
                            join b in _context.Registro on a.IdRegistro equals b.IdRegistro
                            where b.IdRegistro == idRegistro  & a.EsOrigen == true
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).FirstOrDefault();
                /*select new ECentroPoblado
                {
                    IdUbigeo = a.IdUbigeo,
                    CodUbigeo = a.CodUbigeo,
                    Nombre = a.NomCcpp,
                    Distrito = new EDistrito { CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                };*/
                return item;
            }
        }

        public IgedRegistroDetalle getIgedRegistroDetallePorCodUgel(string codUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.IgedRegistroDetalle
                            join b in _context.Iged on a.IdIged equals b.IdIged                            
                            where b.CodIged == codUgel
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).FirstOrDefault();
                /*select new ECentroPoblado
                {
                    IdUbigeo = a.IdUbigeo,
                    CodUbigeo = a.CodUbigeo,
                    Nombre = a.NomCcpp,
                    Distrito = new EDistrito { CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                };*/
                return item;
            }
        }

        public IgedRegistroDetalle getIgedRegistroDetallePorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.IgedRegistroDetalle
                            join b in _context.Registro on a.IdRegistro equals b.IdRegistro
                            where b.IdRegistro == idRegistro
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).FirstOrDefault();
                /*select new ECentroPoblado
                {
                    IdUbigeo = a.IdUbigeo,
                    CodUbigeo = a.CodUbigeo,
                    Nombre = a.NomCcpp,
                    Distrito = new EDistrito { CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                };*/
                return item;
            }
        }

        public int saveIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedRegistroDetalle.Add(igedRegistroDetalle);
                _context.SaveChanges();
                return igedRegistroDetalle.IdIgedRegistro;
            }
        }

        public void saveListaIgedRegistroDetalle(List<IgedRegistroDetalle> listaIgedRegistroDetalle)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedRegistroDetalle.AddRange(listaIgedRegistroDetalle);
                _context.SaveChanges();
            }
        }

        public void updateIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedRegistroDetalle.Update(igedRegistroDetalle);
                _context.SaveChanges();
            }
        }

        public int ActualizarRegDetalleOrigen(IgedRegistroDetalle igedRegistroDetalle)
        {
            DateTime fechaHoy = DateTime.Now;
            //           string usuario = "40615837";
            IgedRegistroDetalle _igedRegistroDetalle = new IgedRegistroDetalle();
            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                       _igedRegistroDetalle = (from a in _context.IgedRegistroDetalle
                                                 where a.IdRegistro == igedRegistroDetalle.IdRegistro & a.IdIged == igedRegistroDetalle.IdIged & a.EsOrigen == true
                                                         & a.EsActivo == true & a.EsBorrado == false
                                                 select a).FirstOrDefault();

                        if (_igedRegistroDetalle != null)
                        {
                            _igedRegistroDetalle.FechaActualizacion = fechaHoy;
                            _igedRegistroDetalle.UsuActualizacion = igedRegistroDetalle.UsuCreacion;
                            _igedRegistroDetalle.EsActivo = false;
                            _igedRegistroDetalle.EsBorrado = true;

                            _context.IgedRegistroDetalle.UpdateRange(_igedRegistroDetalle);
                            _context.SaveChanges();
                        }                        

                        _context.IgedRegistroDetalle.Add(igedRegistroDetalle);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
                return igedRegistroDetalle.IdIgedRegistro;
            }
        }
    }
}
