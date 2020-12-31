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
    public class ManagerEventoRegistral : IManagerEventoRegistral, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public EEventoRegistral ObtenerCDEventoRegistralPorCodigo(int codEvento)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.EventoRegistral
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.CodEvento == codEvento)
                    .Select(x => new EEventoRegistral { 
                            CodEvento = x.CodEvento?? default(int),
                            DescEvento = x.DescEvento,
                            IdEventoRegistral = x.IdEventoRegistral,
                            Naturaleza  =  new ENaturaleza{IdNaturaleza = x.IdNaturaleza?? default(int)}                                                   
                    })                    
                    .FirstOrDefault();
                return item;
            }
        }

        public IEnumerable<EEventoRegistral> ObtenerEventoRegistralPorConfiguracion(int codTipoRegistro, int codTipoIGED)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.EventoXTipoIged
                           join b in _context.TipoIged on a.IdTipoIged equals b.IdTipoIged
                           join c in _context.TipoRegistro on a.IdTipoRegistro equals c.IdTipoRegistro
                           join d in _context.NaturalezaEvento on a.IdNaturaleza equals d.IdNaturaleza
                           join e in _context.EventoRegistral on a.IdNaturaleza equals e.IdNaturaleza
                           where b.CodTipoIged == codTipoIGED & c.CodTipoRegistro == codTipoRegistro
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                                 & d.EsActivo == true
                                 & d.EsBorrado == false
                                 & e.EsActivo == true
                                 & e.EsBorrado == false
                           select new EEventoRegistral
                           {
                               IdEventoRegistral = e.IdEventoRegistral,
                               CodEvento = e.CodEvento ?? default(int),
                               DescEvento = e.DescEvento,
                               Naturaleza = new ENaturaleza
                               {
                                   IdNaturaleza = d.IdNaturaleza,
                                   CodNaturaleza = d.CodNaturaleza,
                                   DescNaturaleza = d.DescNaturaleza
                               }
                           };

                return item.ToList();
            }
        }

        public IEnumerable<EEventoRegistral> ObtenerEventosColaterales(int codEvento)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.EventosDesencadenados
                           join b in _context.EventoRegistral on a.IdEventoOriginal equals b.IdEventoRegistral
                           join c in _context.EventoRegistral on a.IdEventoColateral equals c.IdEventoRegistral
                           join d in _context.NaturalezaEvento on c.IdNaturaleza equals d.IdNaturaleza
                           where b.CodEvento == codEvento
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                                 & d.EsActivo == true
                                 & d.EsBorrado == false
                           select new EEventoRegistral
                           {
                               IdEventoRegistral = c.IdEventoRegistral,
                               CodEvento = c.CodEvento?? default(int),
                               DescEvento = c.DescEvento,
                               Naturaleza = new ENaturaleza
                               {
                                   IdNaturaleza = d.IdNaturaleza,
                                   CodNaturaleza = d.CodNaturaleza,
                                   DescNaturaleza = d.DescNaturaleza
                               }
                           };

                return item.ToList();
            }
        }
    }
}
