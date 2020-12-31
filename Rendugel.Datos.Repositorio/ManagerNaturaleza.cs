using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerNaturaleza : IManagerNaturaleza, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorCodigo(int codNaturaleza)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.NaturalezaEvento
                        .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodNaturaleza== codNaturaleza)
                        .Select(x => new ENaturaleza
                        {
                            IdNaturaleza = x.IdNaturaleza,
                            CodNaturaleza = x.CodNaturaleza,
                            DescNaturaleza = x.DescNaturaleza
                        })
                        .FirstOrDefault();
                return item;
            }
        }

        public ENaturaleza ObtenerCDNaturalezaActoAdministrativoPorEvento(int codEvento)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.NaturalezaEvento
                           join b in _context.EventoRegistral on a.IdNaturaleza equals b.IdNaturaleza
                           where a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & b.CodEvento == codEvento
                           select new ENaturaleza
                           {
                               IdNaturaleza = a.IdNaturaleza,
                               CodNaturaleza = a.CodNaturaleza,
                               DescNaturaleza = a.DescNaturaleza
                           };

                return item.FirstOrDefault();
            }
        }
    }
}
