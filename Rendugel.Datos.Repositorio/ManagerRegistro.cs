using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerRegistro : IManagerRegistro, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public IEnumerable<EIgedRegistroDetalle> ObtenerRegistroDetallePorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.IgedRegistroDetalle
                           join b in _context.Iged on a.IdIged equals b.IdIged
                           join c in _context.Iged on a.IdDre equals c.IdIged
                           join d in _context.TipoIged on a.IdTipoIged equals d.IdTipoIged
                           join e in _context.EventoRegistral on a.IdEventoRegistral equals e.IdEventoRegistral
                           join f in _context.Ubigeo on a.IdUbigeoIged equals f.IdUbigeo
                           join g in _context.EstadoIged on b.IdEstadoIged equals g.IdEstadoIged
                           join h in _context.IgedBasicos on c.IdIged equals h.IdIged
                           join i in _context.NaturalezaEvento on e.IdNaturaleza equals i.IdNaturaleza
                           join j in _context.TipoUbigeo on f.IdTipoUbigeo equals j.IdTipoUbigeo
                           where a.IdRegistro == idRegistro //ENUMEADO (PENDIENTE)
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
                                 & f.EsActivo == true
                                 & f.EsBorrado == false
                                 & g.EsActivo == true
                                 & g.EsBorrado == false
                                 & h.EsActivo == true
                                 & h.EsBorrado == false
                                 & i.EsActivo == true
                                 & i.EsBorrado == false
                                 & j.EsActivo == true
                                 & j.EsBorrado == false
                           select new EIgedRegistroDetalle
                           {
                               IdIgedRegistro = a.IdIgedRegistro,
                               EsOrigen = a.EsOrigen,
                               NomIged = a.NomIged,                               
                               Ugel = new EUgel
                               {
                                   IdIged = b.IdIged,
                                   CodIged = b.CodIged,
                                   NomIged = a.NomIged,
                                   EstadoIged = new EEstadoIged { IdEstadoIged= g.IdEstadoIged, 
                                                                  CodEstadoIged= g.CodEstadoIged, 
                                                                  DescEstadoIged = g.DescEstadoIged
                                                                }
                               },
                               Dre = new EIged
                               {
                                   IdIged = c.IdIged,
                                   CodIged = c.CodIged,
                                   NomIged = h.NomIged
                               } ,
                               TipoIged = new ETipoIged
                               {
                                   IdTipoIged = d.IdTipoIged,
                                   CodTipoIged = d.CodTipoIged,
                                   DescTipoIged = d.DescTipoIged
                               },
                               EventoRegistral = new EEventoRegistral
                               {
                                   IdEventoRegistral = e.IdEventoRegistral,
                                   CodEvento = e.CodEvento,
                                   DescEvento = e.DescEvento,      
                                   Naturaleza = new ENaturaleza
                                               {   IdNaturaleza= i.IdNaturaleza,
                                                   CodNaturaleza = i.CodNaturaleza,
                                                   DescNaturaleza = i.DescNaturaleza
                                               }
                               },
                               Ubigeo = new EUbigeo 
                               { 
                                   IdUbigeo = f.IdUbigeo,
                                   CodUbigeo = f.CodUbigeo,
                                   IdTipoUbigeo = j.IdTipoUbigeo,
                                   CodTipoUbigeo = j.CodTipoUbigeo
                               },
                               region = new ERegion 
                               {
                                    IdUbigeo = f.IdRegion?? default (int),
                                    CodUbigeo = f.CodRegion,
                                    Nombre = f.NomRegion
                               },
                               provincia = new EProvincia 
                               {
                                   IdUbigeo = f.IdProvincia ?? default(int),
                                   CodUbigeo = f.CodProvincia,
                                   Nombre = f.NomProvincia
                               },
                               distrito = new EDistrito 
                               {
                                   IdUbigeo = f.IdDistrito ?? default(int),
                                   CodUbigeo = f.CodDistrito,
                                   Nombre = f.NomDistrito
                               }
                           };
                //items = item.ToList();
                return item.ToList();
            }                
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionales()
        {
            //Obtener todos los registros del tipo provisional en estado pendiente Tipo:1 Estado:1
           /* List<ERegistroBandeja> items = new List<ERegistroBandeja>();
            List<EIgedRegistroDetalle> _listaDetalle = new List<EIgedRegistroDetalle>();
            EIgedRegistroDetalle _registroDetalle = new EIgedRegistroDetalle();
            _registroDetalle.IdIgedRegistro = 0;
            _registroDetalle.EsOrigen = false;
            _registroDetalle.NomIged = "";
            _registroDetalle.Ugel = null;
            _registroDetalle.Ubigeo = null;
            _registroDetalle.region = null;
            _registroDetalle.provincia = null;
            _registroDetalle.distrito = null;
            _registroDetalle.TipoIged = null;
            _registroDetalle.Dre = null;
            _registroDetalle.EventoRegistral = null;

            _listaDetalle.Add(_registroDetalle);*/

            using (var _context = new rendugelDBContext())
            {
                //var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                var item = from a in _context.Registro
                           join b in _context.EstadoRegistro on a.IdEstadoRegistro equals b.IdEstadoRegistro
                           join c in _context.TipoRegistro on a.IdTipoRegistro equals c.IdTipoRegistro
                           join d in _context.DocumentoRegistro on a.IdRegistro equals d.IdRegistro
                           join e in _context.Documento on d.IdDocumento equals e.IdDocumento
                           join f in _context.TipoDocumento on e.IdTipoDoc equals f.IdTipoDoc
                           join g in _context.ClasificacionDocumento on e.IdClasificacionDoc equals g.IdClasificacionDoc
                           where b.CodEstadoRegistro == 1 //ENUMEADO (PENDIENTE)
                                 & c.CodTipoRegistro == 1  //ENUMERADO (PROVISIONAL)
                                 & g.CodClasificacionDoc == 1
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
                                 & f.EsActivo == true
                                 & f.EsBorrado == false
                                 & g.EsActivo == true
                                 & g.EsBorrado == false

                           select new ERegistroBandeja
                           {
                               IdRegistro = a.IdRegistro,
                               CodRegistro = a.CodRegistro,
                               Estado = b.DescEstadoRegistro,
                               CodTipoRegistro = c.CodTipoRegistro,
                               UsuCreacion = a.UsuCreacion,
                               EstadoRegistro = new EEstadoRegistro
                               {
                                   IdEstadoRegistro = b.IdEstadoRegistro,
                                   CodEstadoRegistro = b.CodEstadoRegistro,
                                   DescEstadoRegistro = b.DescEstadoRegistro
                               },
                               TipoRegistro = new ETipoRegistro
                               {
                                   IdTipoRegistro = c.IdTipoRegistro,
                                   CodTipoRegistro = c.CodTipoRegistro,
                                   DescTipoRegistro = c.DescTipoRegistro
                               },
                               DocumentoResolutivo = new EDocumento
                               {
                                   IdDocumento = e.IdDocumento,
                                   NroDocumento = e.NroDocumento,
                                   NombreArchivo = e.NombreArchivo,
                                   Ruta = e.Ruta,
                                   FechaEmision = e.FechaEmision,
                                   FechaPublicacion = e.FechaPublicacion,
                                   TipoDocumento = new ETipoDocumento
                                   {
                                       IdTipoDoc = f.IdTipoDoc,
                                       CodTipoDoc = f.CodTipoDoc,
                                       DescTipoDoc = f.DescTipoDoc
                                   }
                               },
                              // ListaDetalle = _listaDetalle.ToList()
                           };
                //items = item.ToList();
                return item.ToList();
            }


            //ERegistroBandeja registroBandeja = new ERegistroBandeja();

            //registroBandeja.IdRegistro = 1;
            //registroBandeja.CodRegistro = "000001";          

            //items.Add(registroBandeja);

            //return items.ToList();
        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosProvisionalesPoTipoEstado(List<ETipoRegistro> listTipoRegistro, List<EEstadoRegistro> listEstadoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = _context.Iged.Where(x => x.EsActivo == true & x.EsBorrado == false).ToList();
                var item = from a in _context.Registro
                           join b in _context.EstadoRegistro on a.IdEstadoRegistro equals b.IdEstadoRegistro
                           join c in _context.TipoRegistro on a.IdTipoRegistro equals c.IdTipoRegistro
                           //join ltr in listTipoRegistro.ToList() on c.CodTipoRegistro equals ltr.CodTipoRegistro
                           join c2 in _context.EstadoRegistro on a.IdEstadoRegistro equals c2.IdEstadoRegistro
                           //join ler in listEstadoRegistro on c2.CodEstadoRegistro equals ler.CodEstadoRegistro
                           join d in _context.DocumentoRegistro on a.IdRegistro equals d.IdRegistro   //AQUI HAY QUE HACER UNA MODIFICACIÓN PARA QUE SOLO SALGA UN REGISTRO DE DOCUMENTO
                           join e in _context.Documento on d.IdDocumento equals e.IdDocumento
                           join f in _context.TipoDocumento on e.IdTipoDoc equals f.IdTipoDoc
                           join g in _context.ClasificacionDocumento on e.IdClasificacionDoc equals g.IdClasificacionDoc
                           where (from l1 in listTipoRegistro select l1.CodTipoRegistro).Contains(c.CodTipoRegistro)
                                 & (from l2 in listEstadoRegistro select l2.CodEstadoRegistro).Contains(c2.CodEstadoRegistro)
                                 & g.CodClasificacionDoc == 1
                                 & a.EsActivo == true
                                 & a.EsBorrado == false
                                 & b.EsActivo == true
                                 & b.EsBorrado == false
                                 & c.EsActivo == true
                                 & c.EsBorrado == false
                                 & c2.EsActivo == true
                                 & c2.EsBorrado == false
                                 & d.EsActivo == true
                                 & d.EsBorrado == false
                                 & e.EsActivo == true
                                 & e.EsBorrado == false
                                 & f.EsActivo == true
                                 & f.EsBorrado == false
                                 & g.EsActivo == true
                                 & g.EsBorrado == false

                           select new ERegistroBandeja
                           {
                               IdRegistro = a.IdRegistro,
                               CodRegistro = a.CodRegistro,
                               Estado = b.DescEstadoRegistro,
                               CodTipoRegistro = c.CodTipoRegistro,
                               UsuCreacion = a.UsuCreacion,
                               EstadoRegistro = new EEstadoRegistro
                               {
                                   IdEstadoRegistro = b.IdEstadoRegistro,
                                   CodEstadoRegistro = b.CodEstadoRegistro,
                                   DescEstadoRegistro = b.DescEstadoRegistro
                               },
                               TipoRegistro = new ETipoRegistro
                               {
                                   IdTipoRegistro = c.IdTipoRegistro,
                                   CodTipoRegistro = c.CodTipoRegistro,
                                   DescTipoRegistro = c.DescTipoRegistro
                               },
                               DocumentoResolutivo = new EDocumento
                               {
                                   IdDocumento = e.IdDocumento,
                                   NroDocumento = e.NroDocumento,
                                   NombreArchivo = e.NombreArchivo,
                                   Ruta = e.Ruta,
                                   FechaEmision = e.FechaEmision,
                                   FechaPublicacion = e.FechaPublicacion,
                                   TipoDocumento = new ETipoDocumento
                                   {
                                       IdTipoDoc = f.IdTipoDoc,
                                       CodTipoDoc = f.CodTipoDoc,
                                       DescTipoDoc = f.DescTipoDoc
                                   }
                               },
                               Acciones = new EAcciones
                               {
                                   Editar = c.CodTipoRegistro==1?true:false,   // true,
                                   Suspender = c.CodTipoRegistro == 1 ? true : false,
                                   Cancelar = c.CodTipoRegistro == 1 ? true : false,
                                   PasarADefenitivo = c.CodTipoRegistro == 1 ? true : false

                               }
                               // ListaDetalle = _listaDetalle.ToList()
                           };
                //items = item.ToList();
                return item.ToList();
            }

        }

        public IEnumerable<ERegistroBandeja> ObtenerRegistrosPorBandeja(EBandeja bandeja)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = from a in _context.Registro
                           join b in _context.EstadoRegistro on a.IdEstadoRegistro equals b.IdEstadoRegistro
                           join c in _context.TipoRegistro on a.IdTipoRegistro equals c.IdTipoRegistro
                           join d in _context.DocumentoRegistro on a.IdRegistro equals d.IdRegistro   //AQUI HAY QUE HACER UNA MODIFICACIÓN PARA QUE SOLO SALGA UN REGISTRO DE DOCUMENTO
                           join e in _context.Documento on d.IdDocumento equals e.IdDocumento
                           join f in _context.TipoDocumento on e.IdTipoDoc equals f.IdTipoDoc
                           join g in _context.ClasificacionDocumento on e.IdClasificacionDoc equals g.IdClasificacionDoc
                           join h in _context.BandejaEstadoRegistro on b.IdEstadoRegistro equals h.IdEstadoRegistro
                           join i in _context.Bandeja on h.IdBandeja equals i.IdBandeja
                           where i.IdBandeja == bandeja.IdBandeja
                                 & g.CodClasificacionDoc == 1
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
                                 & f.EsActivo == true
                                 & f.EsBorrado == false
                                 & g.EsActivo == true
                                 & g.EsBorrado == false
                                 & h.EsActivo == true
                                 & h.EsBorrado == false
                                 & i.EsActivo == true
                                 & i.EsBorrado == false

                           select new ERegistroBandeja
                           {
                               IdRegistro = a.IdRegistro,
                               CodRegistro = a.CodRegistro,
                               Estado = b.DescEstadoRegistro,
                               CodTipoRegistro = c.CodTipoRegistro,
                               UsuCreacion = a.UsuCreacion,
                               EstadoRegistro = new EEstadoRegistro
                               {
                                   IdEstadoRegistro = b.IdEstadoRegistro,
                                   CodEstadoRegistro = b.CodEstadoRegistro,
                                   DescEstadoRegistro = b.DescEstadoRegistro
                               },
                               TipoRegistro = new ETipoRegistro
                               {
                                   IdTipoRegistro = c.IdTipoRegistro,
                                   CodTipoRegistro = c.CodTipoRegistro,
                                   DescTipoRegistro = c.DescTipoRegistro
                               },
                               DocumentoResolutivo = new EDocumento
                               {
                                   IdDocumento = e.IdDocumento,
                                   NroDocumento = e.NroDocumento,
                                   NombreArchivo = e.NombreArchivo,
                                   Ruta = e.Ruta,
                                   FechaEmision = e.FechaEmision,
                                   FechaPublicacion = e.FechaPublicacion,
                                   TipoDocumento = new ETipoDocumento
                                   {
                                       IdTipoDoc = f.IdTipoDoc,
                                       CodTipoDoc = f.CodTipoDoc,
                                       DescTipoDoc = f.DescTipoDoc
                                   }
                               },
                               Acciones = new EAcciones
                               {
                                   Editar = (c.CodTipoRegistro == 1 && b.CodEstadoRegistro==1) ? true : false,   // true,
                                   Suspender = (c.CodTipoRegistro == 1 && b.CodEstadoRegistro==1) ? true : false,
                                   Cancelar = (c.CodTipoRegistro == 1 && (b.CodEstadoRegistro == 1 || b.CodEstadoRegistro == 3)) ? true : false,             
                                   PasarADefenitivo = (c.CodTipoRegistro == 1 && b.CodEstadoRegistro == 1) ? true : false

                               }
                           };
                return item.ToList();
            }

        }

        public ResponseService pasarADefinitivo(RegistroDefinitivoResponse registroDefinitivoResponse)
        {
            ResponseService responseService = new ResponseService();
            int idRegistro = 0;
            //int idRegistroDefinitivo = 0;

            DateTime fechaHoy = DateTime.Now;
            //string usuario = "40615837";
            idRegistro = registroDefinitivoResponse.IdRegistro;
            //Obtenemos el registro provisional a modificar
            Registro registroProvisional = new Registro();

                responseService.MensajePrincipal = "";
                responseService.idRegistro = idRegistro;
                responseService.ResultValid = false;                
            
                return responseService;  
        }

        public int saveDependenciaUnidadEjecutora(DependeciaUnidadEjecutora dependeciaUnidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DependeciaUnidadEjecutora.Add(dependeciaUnidadEjecutora);
                _context.SaveChanges();
                return dependeciaUnidadEjecutora.IdIgedEjecutora;
            }
        }

        public int saveDocumento(Documento documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Documento.Add(documento);
                _context.SaveChanges();
                return documento.IdDocumento;
            }
        }

        public int saveDocumentoRegistro(DocumentoRegistro documentoRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.DocumentoRegistro.Add(documentoRegistro);
                _context.SaveChanges();
                return documentoRegistro.IdDocumentoRegistro;
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

        public int saveIgedBasicos(IgedBasicos igedBasicos)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.IgedBasicos.Add(igedBasicos);
                _context.SaveChanges();
                return igedBasicos.IdIgedBasicos;
            }
        }

        public int saveIgedMedioContacto(IgedMedioContacto igedMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.IgedMedioContacto.Add(igedMedioContacto);
                _context.SaveChanges();
                return igedMedioContacto.IdMedioContactoIged;
            }
        }

        public int saveIgedRegistroDetalle(IgedRegistroDetalle igedRegistroDetalle)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.IgedRegistroDetalle.Add(igedRegistroDetalle);
                _context.SaveChanges();
                return igedRegistroDetalle.IdIgedRegistro;
            }

        }

        public int saveJurisdiccionIged(JurisdiccionIged jurisdiccionIged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.JurisdiccionIged.Add(jurisdiccionIged);
                _context.SaveChanges();
                return jurisdiccionIged.IdJurisdiccion;
            }
        }

        public int saveLocalIged(LocalIged localIged)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.LocalIged.Add(localIged);
                _context.SaveChanges();
                return localIged.IdLocalIged;
            }
        }

        public int savePersona(Persona persona)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Persona.Add(persona);
                _context.SaveChanges();
                return persona.IdPersona;
            }
        }
    

        public int savePersonal(Personal personal)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Personal.Add(personal);
                _context.SaveChanges();
                return personal.IdPersonal;
            }
        }

        public int savePersonalMedioContacto(PersonalMedioContacto personalMedioContacto)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.PersonalMedioContacto.Add(personalMedioContacto);
                _context.SaveChanges();
                return personalMedioContacto.IdMedioContactoPersonal;
            }
        }

        public int saveRegistro(Registro registro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Registro.Add(registro);
                _context.SaveChanges();
                return registro.IdRegistro;
            }
        }

        public ResponseService saveRegistroProvisional(RegistroResponse registroResoponse)
        {
            int idRegistro = 0;
            int idDocumento = 0;
            int idUgel = 0;
            int idDocumentoRegistro = 0;
            int idRegistroDetalle = 0;


            DateTime fechaCreacion = DateTime.Now;
            string usuario = "40615837";

            Registro registro = new Registro();
            registro.CodRegistro = "00000000";
            registro.EsActivo = true;
            registro.EsBorrado = false;
            registro.FechaCreacion = fechaCreacion;
            registro.UsuCreacion = usuario;
            registro.IdEstadoRegistro = 2; //ENUMERADO (PENDIENTE)
            registro.IdTipoRegistro = registroResoponse.TipoRegistro.IdTipoRegistro;

            idRegistro = this.saveRegistro(registro);

            //ACTUALIZAR EL CÓDIGO DE REGISTRO
            registro.IdRegistro = idRegistro;
            registro.CodRegistro = idRegistro.ToString();
            this.updateRegistro(registro);
            ///

            Documento documento = new Documento();
                documento.IdDocumento = registroResoponse.DocumentoResolutivo.IdDocumento; 
                //documento.Temporal = false;
                documento.NombreArchivo = registroResoponse.DocumentoResolutivo.NombreArchivo;
                documento.Ruta = registroResoponse.DocumentoResolutivo.Ruta;
                documento.FechaEmision = registroResoponse.DocumentoResolutivo.FechaEmision;
                documento.FechaPublicacion = registroResoponse.DocumentoResolutivo.FechaPublicacion;
                documento.NroDocumento = registroResoponse.DocumentoResolutivo.NroDocumento;
                documento.IdTipoDoc = registroResoponse.DocumentoResolutivo.TipoDocumento.IdTipoDoc;
                documento.IdClasificacionDoc = 1;
                documento.FechaCreacion = fechaCreacion;
                documento.UsuCreacion = usuario;
                documento.EsActivo = true;
                documento.EsBorrado = false;

            this.updateDocumento(documento);
            idDocumento = documento.IdDocumento; //this.saveDocumento(documento);

            Iged iged = new Iged();
                iged.EsActivo = true;
                iged.EsBorrado = false;
                iged.FechaCreacion = fechaCreacion;
                iged.UsuCreacion = usuario;
                iged.CodIged = registroResoponse.CodUgel;
                iged.IdEstadoIged = 3; //ENUMERADO
                iged.IdTipoIged = 2; //ENUMERADO


            idUgel = this.saveIged(iged);

            DocumentoRegistro documentoRegistro = new DocumentoRegistro();
                documentoRegistro.EsActivo = true;
                documentoRegistro.EsBorrado = false;
                documentoRegistro.FechaCreacion = fechaCreacion;
                documentoRegistro.UsuCreacion = usuario;
                documentoRegistro.IdDocumento = idDocumento;
                documentoRegistro.IdRegistro = idRegistro;

            idDocumentoRegistro = this.saveDocumentoRegistro(documentoRegistro);


            IgedRegistroDetalle igedRegistroDetalle = new IgedRegistroDetalle();
                igedRegistroDetalle.EsActivo = true;
                igedRegistroDetalle.EsBorrado = false;
                igedRegistroDetalle.EsOrigen = true;
                igedRegistroDetalle.FechaCreacion = fechaCreacion;
                igedRegistroDetalle.UsuCreacion = usuario;
                igedRegistroDetalle.NomIged = registroResoponse.NombreUgel;
                igedRegistroDetalle.IdUbigeoIged = registroResoponse.Ubigeo.IdUbigeo;
                igedRegistroDetalle.IdTipoIged = registroResoponse.TipoIged.IdTipoIged;
                igedRegistroDetalle.IdDre = registroResoponse.Dre.IdIged;
                igedRegistroDetalle.IdEventoRegistral = registroResoponse.EventoRegistral.IdEventoRegistral;
                igedRegistroDetalle.IdRegistro = idRegistro;
                igedRegistroDetalle.IdIged = idUgel;

            idRegistroDetalle = this.saveIgedRegistroDetalle(igedRegistroDetalle);

            ResponseService responseService = new ResponseService();

            responseService.MensajePrincipal = "Los datos se guardaron correctamente";
            responseService.idRegistro = idRegistro;
            responseService.ResultValid = true;
            
            return  responseService;
        }

        public int saveUnidadEjecutora(UnidadEjecutora unidadEjecutora)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.UnidadEjecutora.Add(unidadEjecutora);
                _context.SaveChanges();
                return unidadEjecutora.IdUnidadEjecutora;
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

        public void updateRegistro(Registro registro)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Registro.Update(registro);
                _context.SaveChanges();               
            }
        }

        public void updateDocumento(Documento documento)
        {
            using (var _context = new rendugelDBContext())
            {
                //var item = 0;
                _context.Documento.Update(documento);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DocumentoRegistro> _ObtenerDocumentoRegistroPorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                    var item = _context.DocumentoRegistro
                        .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdRegistro == idRegistro)
                        .ToList();
                    return item;                   
            }
        }

        public IEnumerable<IgedRegistroDetalle> _ObtenerRegistroDetallePorIdRegistro(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.IgedRegistroDetalle
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdRegistro == idRegistro)
                    .ToList();
                return item;
            }
        }

        public Registro _ObtenerRegistroPorId(int idRegistro)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Registro
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.IdRegistro == idRegistro)
                    .FirstOrDefault();
                return item;
            }
        }

        public ResponseService elimarRegistro(int idRegistro)
        {
            ResponseService response= new ResponseService();
            Registro registroEliminar = new Registro();

            DateTime fechaHoy = DateTime.Now;
            string usuario = "40615837";

            using (var _context = new rendugelDBContext())
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try{
                    registroEliminar = _context.Registro.Where(x => x.IdRegistro == idRegistro)
                        .FirstOrDefault();

                    if (registroEliminar is null){
                        response.ResultValid = true;
                        response.MensajePrincipal = "El registro que desea eliman no existe";
                        return response;
                    }

                    registroEliminar.EsActivo = false;
                    registroEliminar.EsBorrado = true;
                    registroEliminar.UsuActualizacion = usuario;
                    registroEliminar.FechaActualizacion = fechaHoy;

                    _context.Registro.Update(registroEliminar);
                    //_context.SaveChanges();

                    List<IgedRegistroDetalle> detalles = new List<IgedRegistroDetalle>();                    
                    detalles = _context.IgedRegistroDetalle
                                    .Where(x => x.IdRegistro == idRegistro).ToList();
                    foreach (IgedRegistroDetalle detalleEliminar in detalles)
                    {
                        detalleEliminar.EsActivo = false;
                        detalleEliminar.EsBorrado = true;
                        detalleEliminar.UsuActualizacion = usuario;
                        detalleEliminar.FechaActualizacion = fechaHoy;

                        _context.IgedRegistroDetalle.Update(detalleEliminar);
                        //_context.SaveChanges();
                    }
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    response.ResultValid = true;
                    response.MensajePrincipal = "Los datos se eliminaron correctamente";
                    response.idRegistro = idRegistro;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    response.ResultValid = true;
                    response.MensajePrincipal = e.Message;
                }
            }
        return response;
        }

    }
}
