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
    public class ManagerPersonal : IManagerPersonal, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public Personal getPersonalPorCodTipoPersona(int codTipoPersonal, string codUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.Personal
                           join b in _context.TipoPersonal on a.IdPersonal equals b.IdTipoPersonal
                           join c in _context.Iged on a.IdIged equals c.IdIged
                           where b.CodTipoPersonal == codTipoPersonal
                            & c.CodIged == codUgel
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                            & c.EsActivo == true & c.EsBorrado == false
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

        public Personal getPersonalPorCodTipoPersonaIdUgel(int codTipoPersonal, int idUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.Personal
                            join b in _context.TipoPersonal on a.IdPersonal equals b.IdTipoPersonal
                            where b.CodTipoPersonal == codTipoPersonal & a.IdIged == idUgel
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).FirstOrDefault();
                return item;
            }
        }

        public int actualizarPersonal(Personal personal)
        {
            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            Personal personalAnt = new Personal();

            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        personalAnt = (from a in _context.Personal                                    
                                    where a.IdPersonal == personal.IdTipoPersonal & a.IdIged ==personal.IdIged
                                            & a.IdPersona == personal.IdPersona
                                            & a.EsActivo == true & a.EsBorrado == false
                                    select a).FirstOrDefault();

                        personalAnt.UsuActualizacion = usuario;
                        personalAnt.FechaActualizacion = fechaHoy;
                        personalAnt.EsActivo = false;

                        _context.Personal.Update(personalAnt);
                        _context.SaveChanges();

                        _context.Personal.Add(personal);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
                return personal.IdPersonal;
            }
        }

        public int remplazarPersonal(Personal personalABaja, Personal personalNuevo)
        {
            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            personalABaja.FechaActualizacion = fechaHoy;
            personalABaja.UsuActualizacion = usuario;
            personalABaja.EsActivo = false;
            personalABaja.EsBorrado = false;

            personalNuevo.FechaCreacion = fechaHoy;
            personalNuevo.UsuCreacion = usuario;
            personalNuevo.EsActivo = true;
            personalNuevo.EsBorrado = false;

            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Personal.Update(personalABaja);
                        _context.SaveChanges();

                        _context.Personal.Add(personalNuevo);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();                       
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }                    
                }
            }
            return personalNuevo.IdPersonal;
        }

        public void saveListaPersonal(List<Personal> listaPersonal)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.Personal.AddRange(listaPersonal);
                _context.SaveChanges();
            }
        }

        public int savePersonal(Personal personal)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.Personal.Add(personal);
                _context.SaveChanges();
                return personal.IdPersonal;
            }
        }

        public void updatePersonal(Personal personal)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.Personal.Update(personal);
                _context.SaveChanges();
            }
        }
    }
}
