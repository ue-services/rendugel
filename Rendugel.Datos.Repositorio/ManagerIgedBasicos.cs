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
    public class ManagerIgedBasicos : IManagerIgedBasicos, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IgedBasicos ObtenerIgedBasicosPorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.IgedBasicos
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdRegistro == idRegistro)
                    .FirstOrDefault();
                return item;
            }
        }

        public IgedBasicos ObtenerIgedBasicosPorIgedPorEstado(int idIged, bool estado)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.IgedBasicos
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdIged == idIged & x.EsActivo == estado)
                    .FirstOrDefault();
                return item;
            }
        }

        public int saveIgedBasicos(IgedBasicos igedBasicos)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedBasicos.Add(igedBasicos);
                _context.SaveChanges();
                return igedBasicos.IdIgedBasicos;
            }
        }

        public void updateIgedBasicos(IgedBasicos igedBasicos)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedBasicos.Update(igedBasicos);
                _context.SaveChanges();
            }
        }

        public void saveListaIgedBasicos(List<IgedBasicos> listaIgedBasicos)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.IgedBasicos.AddRange(listaIgedBasicos);
                _context.SaveChanges();
            }
        }

        public void darBajaIgedBasicos(int idIgedBasicos)
        {
            using (var _context = new rendugelDBContext())
            {
                var igedBasicos = _context.IgedBasicos
                     .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdIgedBasicos == idIgedBasicos)
                     .FirstOrDefault();
                igedBasicos.EsActivo = false;
                _context.SaveChanges();
            }
        }

        public int remplazaIgedBasicos(IgedBasicos igedBasicosABaja, IgedBasicos igedBasicosNuevo)
        {
            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            igedBasicosABaja.FechaActualizacion = fechaHoy;
            igedBasicosABaja.UsuActualizacion = usuario;
            igedBasicosABaja.EsActivo = false;
            igedBasicosABaja.EsBorrado = false;

            igedBasicosNuevo.FechaCreacion = fechaHoy;
            igedBasicosNuevo.UsuCreacion = usuario;
            igedBasicosNuevo.EsActivo = true;
            igedBasicosNuevo.EsBorrado = false;

            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.IgedBasicos.Update(igedBasicosABaja);
                        _context.SaveChanges();

                        _context.IgedBasicos.Add(igedBasicosNuevo);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return igedBasicosNuevo.IdIgedBasicos;
        }
        
    }
}
