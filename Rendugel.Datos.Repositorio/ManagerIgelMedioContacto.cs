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
    public class ManagerIgelMedioContacto : IManagerIgelMedioContacto, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IgelMedioContacto ObtenerIgelMedioContactoPorId(int id)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.IgelMedioContacto
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdMedioContactoIged == id)
                    .FirstOrDefault();
                return item;
            }
        }

        public IEnumerable<IgelMedioContacto> ObtenerListaIgelMedioContactoPorUgel(string codUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = (from a in _context.IgelMedioContacto
                            join b in _context.Iged on a.IdIged equals b.IdIged
                            where b.CodIged == codUgel
                             & a.EsActivo == true & a.EsBorrado == false
                             & b.EsActivo == true & b.EsBorrado == false
                            select a).ToList();                
                return item;
            }
        }

        public int saveIgelMedioContacto(IgelMedioContacto igelMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgelMedioContacto.Add(igelMedioContacto);
                _context.SaveChanges();
                return igelMedioContacto.IdMedioContactoIged;
            }
        }

        public void updateIgelMedioContacto(IgelMedioContacto igelMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgelMedioContacto.Update(igelMedioContacto);
                _context.SaveChanges();
            }
        }
    }
}
