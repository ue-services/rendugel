using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerUbigeo : IManagerUbigeo, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorDistrito(EDistrito distrito)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                            where b.CodTipoUbigeo == 4 //CCPP => debería crearse un enumerado
                            & a.CodDistrito == distrito.CodUbigeo
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new ECentroPoblado
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomCcpp,
                               Distrito = new EDistrito { CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorListaCCPP(List<ECentroPoblado> listaCCPP)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           join c in listaCCPP on a.IdUbigeo equals c.IdUbigeo
                           where b.CodTipoUbigeo == 4 //CCPP => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new ECentroPoblado
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomCcpp,
                               Distrito = new EDistrito {CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<ECentroPoblado> ObtenerCCPPPorListaDistrito(List<EDistrito> listaDistritos)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where (from c in listaDistritos select c.CodUbigeo).Contains(a.CodDistrito)
                            & b.CodTipoUbigeo == 4 //CCPP => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new ECentroPoblado
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomCcpp,
                               Distrito = new EDistrito { CodUbigeo = a.CodDistrito, Nombre = a.NomDistrito }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorListaIdDistritos(List<EDistrito> listaIdDistritos)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           join c in listaIdDistritos on a.IdUbigeo equals c.IdUbigeo
                           where b.CodTipoUbigeo == 3 //Distrito => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EDistrito
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomDistrito,
                               Provincia = new EProvincia {IdUbigeo=a.IdProvincia?? default(int),  CodUbigeo = a.CodProvincia, Nombre = a.NomProvincia }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorListaProvincias(List<EProvincia> listaProvincias)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where (from c in listaProvincias select c.CodUbigeo).Contains(a.CodProvincia)
                            & b.CodTipoUbigeo == 3 //Distrito => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EDistrito
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomDistrito,
                               Provincia = new EProvincia { IdUbigeo = a.IdProvincia ?? default(int), CodUbigeo = a.CodProvincia, Nombre = a.NomProvincia }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorProvincia(string codUbigeoProvincia)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where a.CodProvincia == codUbigeoProvincia & b.CodTipoUbigeo == 3 //Provincia => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EDistrito
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomDistrito,
                               Provincia = new EProvincia { IdUbigeo = a.IdProvincia ?? default(int), CodUbigeo = a.CodProvincia, Nombre = a.NomProvincia }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorRegion(string codUbigeoRegion)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where a.CodRegion == codUbigeoRegion & b.CodTipoUbigeo == 3 //Distrito => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EDistrito
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomDistrito,
                               Provincia = new EProvincia { IdUbigeo = a.IdProvincia ?? default(int), CodUbigeo =a.CodProvincia, Nombre=a.NomProvincia}
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EDistrito> ObtenerDistritosPorRegionNoIncluidosEnLasProvincias(string codUbigeoRegion, List<EProvincia> listaProvincias)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where !(from c in listaProvincias select c.IdUbigeo).Contains(a.IdUbigeo)
                            & a.CodRegion == codUbigeoRegion & b.CodTipoUbigeo == 3 //Distrito => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EDistrito
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomDistrito,
                               Provincia = new EProvincia { IdUbigeo = a.IdProvincia ?? default(int), CodUbigeo = a.CodProvincia, Nombre = a.NomProvincia }
                           };
                return item.ToList();
            }
        }

        public IEnumerable<EProvincia> ObtenerProvinciasPorRegion(string codUbigeoRegion)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Ubigeo
                           join b in _context.TipoUbigeo on a.IdTipoUbigeo equals b.IdTipoUbigeo
                           where a.CodRegion == codUbigeoRegion & b.CodTipoUbigeo == 2 //Provincia => debería crearse un enumerado
                            & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new EProvincia
                           {
                               IdUbigeo = a.IdUbigeo,
                               CodUbigeo = a.CodUbigeo,
                               Nombre = a.NomProvincia,
                               Region= new ERegion { IdUbigeo = a.IdRegion ?? default(int), CodUbigeo =a.CodRegion, Nombre=a.NomRegion}
                           };
                return item.ToList();
            }
        }

        public ERegion ObtenerRegionPorDre(int IdDre)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.IgedBasicos
                           join b in _context.Ubigeo on a.IdDre equals b.IdUbigeo
                           where a.IdDre == IdDre & a.EsActivo == true & a.EsBorrado == false
                            & b.EsActivo == true & b.EsBorrado == false
                           select new ERegion
                           {
                               IdUbigeo = b.IdUbigeo,
                               CodUbigeo = b.CodUbigeo,
                               Nombre = b.NomRegion
                           };
                return item.FirstOrDefault();
            }
        }

    }
}
