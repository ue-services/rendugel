using Rendugel.Datos.Interfaces;
using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Datos.Repositorio;

namespace Rendugel.Dominio
{
    public class ManagerGeneralRepositorio : IManagerGeneralRepositorio, IDisposable
    {
        //private readonly rendugelDBContext _context;

        public ManagerGeneralRepositorio()
        {
           // _context = context;
        }

        public void Dispose()
        {
            return;
        }
        public IEnumerable<TipoIged> ObtenerListaTipoIged()
        {
            using(var _context = new rendugelDBContext())
            {
                var item = _context.TipoIged.Where(x => x.EsActivo==true & x.EsBorrado==false).ToList();
                return item;
            }         
        }

        public IEnumerable<NaturalezaEvento> ObtenerListaNaturalezaActoAdministrativo()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.NaturalezaEvento.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistral()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.EventoRegistral.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<TipoRegistro> ObtenerListaTipoRegistro()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoRegistro.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<Ubigeo> ObtenerListasUbigeo()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Ubigeo.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<Ubigeo> ObtenerListaLocalidad()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Ubigeo.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<TipoDocumento> ObtenerListaTipoDocumento()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.TipoDocumento.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<Iged> ObtenerListaUgeles()
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                return item;
            }
        }

        public IEnumerable<EventoRegistral> ObtenerListaEventoRegistralPorIdNaturaleza(int idNaturalea)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.EventoRegistral.Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdNaturaleza==idNaturalea).ToList();
                return item;
            }
        }
  
    }
}
