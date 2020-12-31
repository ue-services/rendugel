using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerIged : IManagerIged, IDisposable
    {
        public ManagerIged()
        {
        }

        public void Dispose()
        {
            return;
        }

        public Iged ObtenerIgedOrigenPorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Iged
                           join b in _context.IgedRegistroDetalle on a.IdIged equals b.IdIged
                           join c in _context.Registro on b.IdRegistro equals c.IdRegistro
                           where b.EsOrigen == true
                                 & c.IdRegistro == idRegistro
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                           select a;
                return item.FirstOrDefault();
            }
        }

        public Iged ObtenerIgedPorId(int idIged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;                
                return _context.Iged.Where(x => x.IdIged == idIged).FirstOrDefault();
            }
        }

        public IEnumerable<EIged> ObtenerListaCDIgedPorCodTipoIged(int codTipoIged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                var item = from a in _context.Iged
                           join b in _context.IgedBasicos on a.IdIged equals b.IdIged
                           join c in _context.TipoIged on a.IdTipoIged equals c.IdTipoIged
                           where c.CodTipoIged == codTipoIged 
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                           select new EIged
                           {
                               IdIged = a.IdIged,
                               CodIged = a.CodIged,
                               NomIged = b.NomIged,
                               CodTipoIged = c.CodTipoIged,
                               IdTipoIged = c.IdTipoIged
                           };
                return item.ToList();
            }            
        }

        public IEnumerable<EIged> ObtenerListaUgelesInvolucradas(int IdDre, int IdUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                var item = from a in _context.Iged
                           join b in _context.IgedBasicos on a.IdIged equals b.IdIged
                           join c in _context.TipoIged on a.IdTipoIged equals c.IdTipoIged
                           where c.CodTipoIged == 2  & b.IdDre == IdDre & a.IdIged!= IdUgel //crear enumerado
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                           select new EIged
                           {
                               IdIged = a.IdIged,
                               CodIged = a.CodIged,
                               NomIged = b.NomIged,
                               CodTipoIged = c.CodTipoIged,
                               IdTipoIged = c.IdTipoIged
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EIged> ObtenerListaUgelesInvolucradasPorUgel(int IdUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.IgedBasicos
                           join b in _context.IgedBasicos on a.IdDre equals b.IdDre
                           join c in _context.Iged on b.IdIged equals c.IdIged
                           join d in _context.TipoIged on c.IdTipoIged equals d.IdTipoIged
                           where a.IdIged == IdUgel & d.CodTipoIged == 2  & b.IdIged != IdUgel //crear enumerado
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                           select new EIged
                           {
                               IdIged = b.IdIged,
                               CodIged = c.CodIged,
                               NomIged = b.NomIged,
                               CodTipoIged = d.CodTipoIged,
                               IdTipoIged = d.IdTipoIged
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EIged> ObtenerListaUgelesPorDre(string codDre)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                var item = from a in _context.Iged
                           join b in _context.IgedBasicos on a.IdIged equals b.IdIged
                           join c in _context.TipoIged on a.IdTipoIged equals c.IdTipoIged
                           join d in _context.Iged on b.IdDre equals d.IdIged
                           where c.CodTipoIged == 2 & d.CodIged == codDre
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                                 & d.EsActivo ==true
                                 & d.EsBorrado == false
                           select new EIged
                           {
                               IdIged = a.IdIged,
                               CodIged = a.CodIged,
                               NomIged = b.NomIged,
                               CodTipoIged = c.CodTipoIged,
                               IdTipoIged = c.IdTipoIged
                           };
                return item.ToList();
            }
        }

        public int saveIged(Iged iged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Iged.Add(iged);
                _context.SaveChanges();
                return iged.IdIged;
            }
        }

        public void updateIged(Iged iged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Iged.Update(iged);
                _context.SaveChanges();
            }
        }
    }
}
