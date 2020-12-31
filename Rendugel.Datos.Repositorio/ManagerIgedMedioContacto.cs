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
    public class ManagerIgedMedioContacto : IManagerIgedMedioContacto, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IgedMedioContacto ObtenerIgedMedioContactoPorId(int id)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.IgedMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdMedioContactoIged == id)
                    .FirstOrDefault();
                return item;
            }
        }

        public IEnumerable<IgedMedioContacto> ObtenerListaIgedMedioContactoPorUgel(string codUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.IgedMedioContacto
                            join b in _context.Iged on a.IdIged equals b.IdIged
                            where b.CodIged == codUgel
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).ToList();                
                return item;
            }
        }

        public int saveIgedMedioContacto(IgedMedioContacto igedMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedMedioContacto.Add(igedMedioContacto);
                _context.SaveChanges();
                return igedMedioContacto.IdMedioContactoIged;
            }
        }

        public void saveListaIgedMedioContacto(List<IgedMedioContacto> listaIgedMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedMedioContacto.AddRange(listaIgedMedioContacto);
                _context.SaveChanges();
            }
        }

        public void updateIgedMedioContacto(IgedMedioContacto igedMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedMedioContacto.Update(igedMedioContacto);
                _context.SaveChanges();
            }
        }

        public int ActualizarRegistrosDeMediosContacto(List<IgedMedioContacto> listaIgedMediosContacto, int idIged)
        {
            // Primero separar los registros a actualizar (tienen id >0)
            // luego obtener los registros actuales de la BD
            // Separar los que no estan en la lista actualizar, separarlos a una lista Eliminar.
            // Tenemos 2 listas: , Listainsertar, ListaEliminar.

            List<IgedMedioContacto> listaIgedMediosContactoEliminar = new List<IgedMedioContacto>();
            List<IgedMedioContacto> listaIgedMediosContactoInsertar = new List<IgedMedioContacto>();
            //IList<Iged>
            int result = 0;

            using (var _context = new rendugelDBContext())
            {
                listaIgedMediosContactoEliminar = (from a in _context.IgedMedioContacto
                                             where !(from b in listaIgedMediosContacto select b.IdMedioContactoIged).Contains(a.IdMedioContactoIged)
                                             & a.EsActivo == true
                                             & a.EsBorrado == false
                                             & a.IdIged == idIged
                                                   select new IgedMedioContacto
                                                   {
                                                       IdMedioContactoIged = a.IdMedioContactoIged,
                                                       IdIged = a.IdIged,
                                                       IdTipoMedioContacto = a.IdTipoMedioContacto,
                                                       Descripcion = a.Descripcion,
                                                       Medio = a.Medio,
                                                       IdRegistro = a.IdRegistro,
                                                       UsuCreacion = a.UsuCreacion,
                                                       FechaCreacion = a.FechaCreacion,
                                                       UsuActualizacion = "",   //Aqui va el usuario logueado
                                                       FechaActualizacion = DateTime.Now,
                                                       EsActivo = false,
                                                       EsBorrado = true
                                                   }
                                             
                                             ).ToList();

                listaIgedMediosContactoInsertar = listaIgedMediosContacto
                                            .Where(x => x.IdMedioContactoIged == 0)
                                            .ToList();
            }

            using (var _context = new rendugelDBContext())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.IgedMedioContacto.AddRange(listaIgedMediosContactoInsertar);
                        _context.SaveChanges();
                        _context.IgedMedioContacto.UpdateRange(listaIgedMediosContactoEliminar);
                        _context.SaveChanges();

                        transaction.Commit();
                        result = 1;
                        System.Windows.Forms.MessageBox.Show("Transaction Ok!");
                    }
                    catch (Exception exp)
                    {
                        transaction.Rollback();
                        result = 0;
                        System.Windows.Forms.MessageBox.Show("Transaction Error!: " + exp.Message);
                    }
                }
            }
            return result;
        }
    }
}
