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
    public class ManagerPersonalMedioContacto : IManagerPersonalMedioContacto, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public PersonalMedioContacto ObtenerPersonalMedioContactoPorId(int id)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.PersonalMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdMedioContactoPersonal == id)
                    .FirstOrDefault();
                return item;
            }
        }

        public IEnumerable<PersonalMedioContacto> ObtenerListaIgelPersonalMedioContactoPorId(int idPersonal)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.PersonalMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdPersonal == idPersonal)
                    .ToList();
                return item;
            }
        }

        public int SavePersonalMedioContacto(PersonalMedioContacto personalMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.PersonalMedioContacto.Add(personalMedioContacto);
                _context.SaveChanges();
                return personalMedioContacto.IdMedioContactoPersonal;
            }
        }

        public void UpdatePersonalMedioContacto(PersonalMedioContacto personalMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.PersonalMedioContacto.Update(personalMedioContacto);
                _context.SaveChanges();
            }
        }

        public void SaveListaPersonalMedioContacto(List<PersonalMedioContacto> listaPersonalMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.PersonalMedioContacto.AddRange(listaPersonalMedioContacto);
                _context.SaveChanges();
            }
        }

        public int ActualizarRegistrosDeMediosContacto(List<PersonalMedioContacto> listaPersonalMedioContacto, int idPersonal)
        {
            List<PersonalMedioContacto> listaPersonalMediosContactoEliminar = new List<PersonalMedioContacto>();
            List<PersonalMedioContacto> listaPersonalMediosContactoInsertar = new List<PersonalMedioContacto>();
            //IList<Iged>
            int result = 0;

            using (var _context = new rendugelDBContext())
            {
                listaPersonalMediosContactoEliminar = (from a in _context.PersonalMedioContacto
                                                   where !(from b in listaPersonalMedioContacto select b.IdMedioContactoPersonal).Contains(a.IdMedioContactoPersonal)
                                                   & a.EsActivo == true
                                                   & a.EsBorrado == false
                                                   & a.IdPersonal == idPersonal
                                                       select new PersonalMedioContacto
                                                   {
                                                       IdMedioContactoPersonal = a.IdMedioContactoPersonal,
                                                       IdPersonal = a.IdPersonal,
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

                listaPersonalMediosContactoInsertar = listaPersonalMedioContacto
                                            .Where(x => x.IdMedioContactoPersonal == 0)
                                            .ToList();
            }

            using (var _context = new rendugelDBContext())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.PersonalMedioContacto.AddRange(listaPersonalMediosContactoInsertar);
                        _context.SaveChanges();
                        _context.PersonalMedioContacto.UpdateRange(listaPersonalMediosContactoEliminar);
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
