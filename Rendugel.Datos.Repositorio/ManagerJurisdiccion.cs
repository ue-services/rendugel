using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerJurisdiccion : IManagerJurisdiccion, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public int ActualizarRegistrosDeJurisdiccion(List<JurisdiccionIged> listaJurisdiccion, List<EIged> listaIged)
        {
            // Primero separar los registros a actualizar (tienen IdJurisdicción >0)
            // luego obtener los registros actuales de la BD
            // Separar los que no estan en la lista actualizar, separarlos a una lista JurisdiccionEliminar.
            // Tenemos 3 listas: ListaActualizar, Listainsertar, ListaEliminar.

            IList<JurisdiccionIged> listaJurisdiccionEliminar = new List<JurisdiccionIged>();
            IList<JurisdiccionIged> listaJurisdiccionEliminar2 = new List<JurisdiccionIged>();
            IList<JurisdiccionIged> listaJurisdiccionInsertar = new List<JurisdiccionIged>();
            //IList<Iged>
            int result = 0;

            using (var _context = new rendugelDBContext())
            {
                
                // Tomar los valores no se encuentran en la otra entidad, usando leftJoin
                //listaJurisdiccionEliminar2 = (from a in _context.JurisdiccionIged
                //                             join b in ListaJurisdiccion on a.IdJurisdiccion equals b.IdJurisdiccion
                //                             into leftTable
                //                             from c in leftTable.DefaultIfEmpty()
                //                             where // c == null 
                //                              a.EsActivo == true & 
                //                             & a.EsBorrado == false
                //                             select a).ToList();

                // Corregir para filtrar las ugeles seleccionadas.
                listaJurisdiccionEliminar = (from a in _context.JurisdiccionIged
                                             where !(from b in listaJurisdiccion select b.IdJurisdiccion).Contains(a.IdJurisdiccion)
                                             & a.EsActivo == true
                                             & a.EsBorrado == false
                                             & (from c in listaIged select c.IdIged).Contains(a.IdIged)
                                             select new JurisdiccionIged
                                             {
                                                 IdJurisdiccion = a.IdJurisdiccion,
                                                 IdIged = a.IdIged,
                                                 IdTerminoPertenencia = a.IdTerminoPertenencia,
                                                 IdTerminoCantidad =a.IdTerminoCantidad,
                                                 IdUbigeo = a.IdUbigeo,
                                                 IdRegistro = a.IdRegistro,
                                                 UsuCreacion = a.UsuCreacion,
                                                 FechaCreacion = a.FechaCreacion,
                                                 UsuActualizacion = "",   //Aqui va el usuario logueado
                                                 FechaActualizacion = DateTime.Now,
                                                 EsActivo = false,
                                                 EsBorrado = true
                                             }
                                             
                                             ).ToList();

                listaJurisdiccionInsertar = listaJurisdiccion
                                            .Where(x => x.IdJurisdiccion == 0)
                                            //.Select(x=> new JurisdiccionIged {
                                            //    IdJurisdiccion = x.IdJurisdiccion,
                                            //    IdIged = x.IdIged,
                                            //    IdTerminoPertenencia = x.IdTerminoPertenencia,
                                            //    IdTerminoCantidad = x.IdTerminoCantidad,
                                            //    IdUbigeo = x.IdUbigeo,
                                            //    IdIgedRegistro = x.IdIgedRegistro,
                                            //    UsuCreacion = "", //Aqui va el usuario logueado
                                            //    FechaCreacion = DateTime.Now,
                                            //    //UsuActualizacion = "",   
                                            //    //FechaActualizacion = 
                                            //    EsActivo = true,
                                            //    EsBorrado = false
                                            //    })
                                            .ToList();
            }


            using (var _context = new rendugelDBContext())
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.JurisdiccionIged.AddRange(listaJurisdiccionInsertar);
                        _context.SaveChanges();
                        _context.JurisdiccionIged.UpdateRange(listaJurisdiccionEliminar);
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

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionDeUgelesPorDre(int IdDre)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.JurisdiccionIged
                           join b in _context.Ubigeo on a.IdUbigeo equals b.IdUbigeo
                           join c in _context.Iged on a.IdIged equals c.IdIged
                           join d in _context.TipoUbigeo on b.IdTipoUbigeo equals d.IdTipoUbigeo
                           join e in _context.IgedBasicos on c.IdIged equals e.IdIged
                           join f in _context.TerminoCantidadJurisdiccion on a.IdTerminoCantidad equals f.IdTerminoCantidad
                           join g in _context.TerminoPertenenciaJurisdiccion on a.IdTerminoPertenencia equals g.IdTerminoPertenencia
                           where e.IdDre == IdDre
                                & a.EsActivo == true & a.EsBorrado == false
                                & b.EsActivo == true & b.EsBorrado == false
                                & c.EsActivo == true & c.EsBorrado == false
                                & d.EsActivo == true & d.EsBorrado == false
                                & e.EsActivo == true & e.EsBorrado == false
                                & f.EsActivo == true & f.EsBorrado == false
                                & g.EsActivo == true & g.EsBorrado == false
                           select new EJurisdiccion
                           {
                               IdJurisdiccion = a.IdJurisdiccion,
                               Ubigeo = new EUbigeo_
                               {
                                   IdUbigeo = b.IdUbigeo,
                                   CodUbigeo = b.CodUbigeo,
                                   Nombre = d.CodTipoUbigeo==1? b.NomRegion: (d.CodTipoUbigeo == 2 ? b.NomProvincia : (d.CodTipoUbigeo == 3 ? b.NomDistrito :(d.CodTipoUbigeo == 4 ? b.NomCcpp :""))),
                                   TipoUbigeo = new ETipoUbigeo
                                               {
                                                   IdTipoUbigeo = d.IdTipoUbigeo,
                                                   CodTipoUbigeo = d.CodTipoUbigeo ?? default(int),
                                                   DescTipoUbigeo = d.DescTipoUbigeo
                                               },
                                   CodCcpp = b.CodCcpp,
                                   NomCcpp= b.NomCcpp,
                                   CodDistrito= b.CodDistrito,
                                   NomDistrito= b.NomDistrito,
                                   CodProvincia = b.CodProvincia,
                                   NomProvincia= b.NomProvincia,
                                   CodRegion= b.CodRegion,
                                   NomRegion= b.NomRegion
                               },
                               CodTerminoCantidad = f.CodTerminoCantidad?? default(int),
                               CodTerminoPertenencia = g.CodTerminoPertenencia?? default(int)
                           };
                return item.ToList();
            }          

        }

        public IEnumerable<IgedJurisdiccionResponse> ObtenerJurisdiccionUgelPorListaUgeles(List<EIged> listaUgel)
        {
            List<IgedJurisdiccionResponse> listaIgedJurisdiccionResponse = new List<IgedJurisdiccionResponse>();
            foreach (EIged ugel in listaUgel)
            {
                IgedJurisdiccionResponse igedJurisdiccionResponse = new IgedJurisdiccionResponse();
                igedJurisdiccionResponse.JurisdiccionUgel = this.ObtenerJurisdiccionUgelPorIdUgel(ugel.IdIged ?? default(int));
                igedJurisdiccionResponse.Ugel = ugel;
                    /*new EUgel
                {
                    IdIged = ugel.IdIged,
                    CodIged = ugel.CodIged,||
                    NomIged = ugel.NomIged,
                    TipoIged = new ETipoIged
                    {
                        IdTipoIged = ugel.IdTipoIged ?? default(int),
                        CodTipoIged = ugel.CodTipoIged,
                        DescTipoIged = ugel.DescTipoIged
                    },
                    EstadoIged = null
                };       */

                listaIgedJurisdiccionResponse.Add(igedJurisdiccionResponse);
            };
                     
            return listaIgedJurisdiccionResponse;
        }

        public IEnumerable<EJurisdiccion> ObtenerJurisdiccionUgelPorIdUgel(int IdUgel)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.JurisdiccionIged
                           //join b in listaUgel on a.IdIged equals b.IdIged
                           join c in _context.Ubigeo on a.IdUbigeo equals c.IdUbigeo
                           join d in _context.TipoUbigeo on c.IdTipoUbigeo equals d.IdTipoUbigeo
                           join e in _context.TerminoCantidadJurisdiccion on a.IdTerminoCantidad equals e.IdTerminoCantidad
                           join f in _context.TerminoPertenenciaJurisdiccion on a.IdTerminoPertenencia equals f.IdTerminoPertenencia
                           where a.IdIged == IdUgel
                                & a.EsActivo == true & a.EsBorrado == false
                                & c.EsActivo == true & c.EsBorrado == false
                                & d.EsActivo == true & d.EsBorrado == false
                                & e.EsActivo == true & e.EsBorrado == false
                                & f.EsActivo == true & f.EsBorrado == false
                           select new EJurisdiccion
                           {
                               IdJurisdiccion = a.IdJurisdiccion,
                               Ubigeo = new EUbigeo_
                               {
                                   IdUbigeo = c.IdUbigeo,
                                   CodUbigeo = c.CodUbigeo,
                                   Nombre = d.CodTipoUbigeo == 1 ? c.NomRegion : (d.CodTipoUbigeo == 2 ? c.NomProvincia : (d.CodTipoUbigeo == 3 ? c.NomDistrito : (d.CodTipoUbigeo == 4 ? c.NomCcpp : ""))),
                                   TipoUbigeo = new ETipoUbigeo
                                   {
                                       IdTipoUbigeo = d.IdTipoUbigeo,
                                       CodTipoUbigeo = d.CodTipoUbigeo ?? default(int),
                                       DescTipoUbigeo = d.DescTipoUbigeo
                                   },
                                   CodCcpp = c.CodCcpp,
                                   NomCcpp = c.NomCcpp,
                                   CodDistrito = c.CodDistrito,
                                   NomDistrito = c.NomDistrito,
                                   CodProvincia = c.CodProvincia,
                                   NomProvincia = c.NomProvincia,
                                   CodRegion = c.CodRegion,
                                   NomRegion = c.NomRegion
                               },
                               CodTerminoCantidad = e.CodTerminoCantidad ?? default(int),
                               CodTerminoPertenencia = f.CodTerminoPertenencia ?? default(int),
                               TerminoCantidadJurisdiccion = new ETerminoCantidadJurisdiccion
                               {
                                   IdTerminoCantidad = e.IdTerminoCantidad,
                                   CodTerminoCantidad = e.CodTerminoCantidad,
                                   DescTerminoCantidad = e.DescTerminoCantidad
                               },
                               TerminoPertenenciaJurisdiccion = new ETerminoPertenenciaJurisdiccion
                               {
                                   IdTerminoPertenencia = f.IdTerminoPertenencia,
                                   CodTerminoPertenencia = f.CodTerminoPertenencia,
                                   DescTerminoPertenencia = f.DescTerminoPertenencia
                               }
                           };
                return item.ToList();
            }
        }
    }
}
