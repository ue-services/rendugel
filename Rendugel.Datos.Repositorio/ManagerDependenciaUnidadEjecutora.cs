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
    public class ManagerDependenciaUnidadEjecutora : IManagerDependenciaUnidadEjecutora, IDisposable
    {
        
        public void Dispose()
        {
            return;
        }

        public DependeciaUnidadEjecutora ObtenerDependenciaUnidadEjecutoraActivaPorIdUgel(int idUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.DependeciaUnidadEjecutora
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdIged == idUgel & x.EsActivo== true)
                    .FirstOrDefault();
                return item;
            }
        }

        public DependeciaUnidadEjecutora ObtenerDependenciaUnidadEjecutoraPorId(int idDependencia)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.DependeciaUnidadEjecutora
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdIgedEjecutora == idDependencia)
                    .FirstOrDefault();
                return item;
            }
        }

        public int saveDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.DependeciaUnidadEjecutora.Add(dependenciaUnidadEjecutora);
                _context.SaveChanges();
                return dependenciaUnidadEjecutora.IdIgedEjecutora;
            }
        }

        public void updateDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.DependeciaUnidadEjecutora.Update(dependenciaUnidadEjecutora);
                _context.SaveChanges();
            }
        }

        public void DarBajaDependenciaUnidadEjecutora(int idDependencia)
        {
            using (var _context = new rendugelDBContext())
            {
                var dependenciaUE = _context.DependeciaUnidadEjecutora
                     .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdIgedEjecutora == idDependencia)
                     .FirstOrDefault();
                dependenciaUE.EsActivo = false;
                _context.SaveChanges();
            }
        }

        public int RemplazarDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependenciaUnidadEjecutoraABaja, DependeciaUnidadEjecutora dependenciaUnidadEjecutoraNueva)
        {
            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            dependenciaUnidadEjecutoraABaja.FechaActualizacion = fechaHoy;
            dependenciaUnidadEjecutoraABaja.UsuActualizacion = usuario;
            dependenciaUnidadEjecutoraABaja.EsActivo = false;
            dependenciaUnidadEjecutoraABaja.EsBorrado = false;

            dependenciaUnidadEjecutoraNueva.FechaCreacion = fechaHoy;
            dependenciaUnidadEjecutoraNueva.UsuCreacion = usuario;
            dependenciaUnidadEjecutoraNueva.EsActivo = true;
            dependenciaUnidadEjecutoraNueva.EsBorrado = false;

            using (var _context = new rendugelDBContext())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.DependeciaUnidadEjecutora.Update(dependenciaUnidadEjecutoraABaja);
                        _context.SaveChanges();

                        _context.DependeciaUnidadEjecutora.Add(dependenciaUnidadEjecutoraNueva);
                        _context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return dependenciaUnidadEjecutoraNueva.IdIgedEjecutora;
        }
    }
}
