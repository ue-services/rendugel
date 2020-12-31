using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rendugel.Dominio.Entidades.Modelo;

namespace Rendugel.Datos.Modelo
{
    public partial class rendugelDBContext : DbContext
    {
        public rendugelDBContext()
        {
        }

        public rendugelDBContext(DbContextOptions<rendugelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accion { get; set; }
        public virtual DbSet<Bandeja> Bandeja { get; set; }
        public virtual DbSet<BandejaEstadoRegistro> BandejaEstadoRegistro { get; set; }
        public virtual DbSet<ClasificacionDocPorTipoSusCan> ClasificacionDocPorTipoSusCan { get; set; }
        public virtual DbSet<ClasificacionDocumento> ClasificacionDocumento { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<DependeciaUnidadEjecutora> DependeciaUnidadEjecutora { get; set; }
        public virtual DbSet<DependenciaUnidadEjecutora> DependenciaUnidadEjecutora { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<DocumentoDirector> DocumentoDirector { get; set; }
        public virtual DbSet<DocumentoRegistro> DocumentoRegistro { get; set; }
        public virtual DbSet<DocumentoSuspension> DocumentoSuspension { get; set; }
        public virtual DbSet<DocumentoTem> DocumentoTem { get; set; }
        public virtual DbSet<EstadoIged> EstadoIged { get; set; }
        public virtual DbSet<EstadoRegistro> EstadoRegistro { get; set; }
        public virtual DbSet<EventoRegistral> EventoRegistral { get; set; }
        public virtual DbSet<EventoXTipoIged> EventoXTipoIged { get; set; }
        public virtual DbSet<EventosDesencadenados> EventosDesencadenados { get; set; }
        public virtual DbSet<Formulario> Formulario { get; set; }
        public virtual DbSet<HIged> HIged { get; set; }
        public virtual DbSet<Iged> Iged { get; set; }
        public virtual DbSet<IgedBasicos> IgedBasicos { get; set; }
        public virtual DbSet<IgedMedioContacto> IgedMedioContacto { get; set; }
        public virtual DbSet<IgedRegistroDetalle> IgedRegistroDetalle { get; set; }
        public virtual DbSet<JurisdiccionIged> JurisdiccionIged { get; set; }
        public virtual DbSet<LocalIged> LocalIged { get; set; }
        public virtual DbSet<NaturalezaEvento> NaturalezaEvento { get; set; }
        public virtual DbSet<OrigenSuspencionCancelacion> OrigenSuspencionCancelacion { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<PersonalMedioContacto> PersonalMedioContacto { get; set; }
        public virtual DbSet<PliegoUnidadEjecutora> PliegoUnidadEjecutora { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RutaArchivos> RutaArchivos { get; set; }
        public virtual DbSet<SuspensionCancelación> SuspensionCancelación { get; set; }
        public virtual DbSet<TerminoCantidadJurisdiccion> TerminoCantidadJurisdiccion { get; set; }
        public virtual DbSet<TerminoPertenenciaJurisdiccion> TerminoPertenenciaJurisdiccion { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoIged> TipoIged { get; set; }
        public virtual DbSet<TipoLocal> TipoLocal { get; set; }
        public virtual DbSet<TipoMedioContacto> TipoMedioContacto { get; set; }
        public virtual DbSet<TipoPersonal> TipoPersonal { get; set; }
        public virtual DbSet<TipoPropiedad> TipoPropiedad { get; set; }
        public virtual DbSet<TipoRegistro> TipoRegistro { get; set; }
        public virtual DbSet<TipoSuspensionCancelacion> TipoSuspensionCancelacion { get; set; }
        public virtual DbSet<TipoUbigeo> TipoUbigeo { get; set; }
        public virtual DbSet<Ubigeo> Ubigeo { get; set; }
        public virtual DbSet<UnidadEjecutora> UnidadEjecutora { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=. ; Database=rendugelDB; user id=sa ; password = 12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accion>(entity =>
            {
                entity.HasKey(e => e.IdAccion);

                entity.ToTable("Accion", "configuracion");

                entity.Property(e => e.IdAccion).HasColumnName("Id_Accion");

                entity.Property(e => e.CodAccion).HasColumnName("Cod_Accion");

                entity.Property(e => e.DescAccion)
                    .HasColumnName("Desc_Accion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bandeja>(entity =>
            {
                entity.HasKey(e => e.IdBandeja);

                entity.ToTable("Bandeja", "configuracion");

                entity.Property(e => e.IdBandeja).HasColumnName("Id_Bandeja");

                entity.Property(e => e.CodBandeja).HasColumnName("Cod_Bandeja");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<BandejaEstadoRegistro>(entity =>
            {
                entity.HasKey(e => e.IdBandejaRegistro);

                entity.ToTable("Bandeja_EstadoRegistro", "configuracion");

                entity.Property(e => e.IdBandejaRegistro).HasColumnName("Id_BandejaRegistro");

                entity.Property(e => e.CodBandejaRegistro).HasColumnName("Cod_Bandeja_Registro");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdBandeja).HasColumnName("Id_Bandeja");

                entity.Property(e => e.IdEstadoRegistro).HasColumnName("Id_Estado_Registro");

                entity.HasOne(d => d.IdBandejaNavigation)
                    .WithMany(p => p.BandejaEstadoRegistro)
                    .HasForeignKey(d => d.IdBandeja)
                    .HasConstraintName("FK_Bandeja_EstadoRegistro_Bandeja");

                entity.HasOne(d => d.IdEstadoRegistroNavigation)
                    .WithMany(p => p.BandejaEstadoRegistro)
                    .HasForeignKey(d => d.IdEstadoRegistro)
                    .HasConstraintName("FK_Bandeja_EstadoRegistro_Estado_Registro");
            });

            modelBuilder.Entity<ClasificacionDocPorTipoSusCan>(entity =>
            {
                entity.HasKey(e => e.IdConfigTipo)
                    .HasName("PK_Componente");

                entity.ToTable("ClasificacionDocPorTipoSusCan", "configuracion");

                entity.Property(e => e.IdConfigTipo).HasColumnName("Id_ConfigTipo");

                entity.Property(e => e.CodConfigTipo).HasColumnName("Cod_ConfigTipo");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdClasificacionDoc).HasColumnName("Id_Clasificacion_Doc");

                entity.Property(e => e.IdTipoSuspCanc).HasColumnName("Id_Tipo_Susp_Canc");

                entity.HasOne(d => d.IdClasificacionDocNavigation)
                    .WithMany(p => p.ClasificacionDocPorTipoSusCan)
                    .HasForeignKey(d => d.IdClasificacionDoc)
                    .HasConstraintName("FK_ClasificacionDocPorTipoSusCan_Clasificacion_Documento");

                entity.HasOne(d => d.IdTipoSuspCancNavigation)
                    .WithMany(p => p.ClasificacionDocPorTipoSusCan)
                    .HasForeignKey(d => d.IdTipoSuspCanc)
                    .HasConstraintName("FK_ClasificacionDocPorTipoSusCan_Tipo_Suspension_Cancelacion");
            });

            modelBuilder.Entity<ClasificacionDocumento>(entity =>
            {
                entity.HasKey(e => e.IdClasificacionDoc);

                entity.ToTable("Clasificacion_Documento", "configuracion");

                entity.Property(e => e.IdClasificacionDoc).HasColumnName("Id_Clasificacion_Doc");

                entity.Property(e => e.CodClasificacionDoc).HasColumnName("Cod_Clasificacion_Doc");

                entity.Property(e => e.DescClasificacionDoc)
                    .HasColumnName("Desc_Clasificacion_Doc")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion);

                entity.ToTable("Configuracion", "configuracion");

                entity.Property(e => e.IdConfiguracion).HasColumnName("Id_Configuracion");

                entity.Property(e => e.ConfiguracionJson)
                    .HasColumnName("Configuracion_JSON")
                    .HasMaxLength(4000);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.EsEditable).HasColumnName("Es_Editable");

                entity.Property(e => e.EsObligatorio).HasColumnName("Es_Obligatorio");

                entity.Property(e => e.EsVisible).HasColumnName("Es_Visible");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdAccion).HasColumnName("Id_Accion");

                entity.Property(e => e.IdComponente).HasColumnName("Id_Componente");

                entity.Property(e => e.IdEstadoRegistro).HasColumnName("Id_Estado_Registro");

                entity.Property(e => e.IdFormulario).HasColumnName("Id_Formulario");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAccionNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdAccion)
                    .HasConstraintName("FK_Configuracion_Accion");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdComponente)
                    .HasConstraintName("FK_Configuracion_Componente");

                entity.HasOne(d => d.IdEstadoRegistroNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdEstadoRegistro)
                    .HasConstraintName("FK_Configuracion_Estado_Registro");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdFormulario)
                    .HasConstraintName("FK_Configuracion_Formulario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Configuracion)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Configuracion_Rol");
            });

            modelBuilder.Entity<DependeciaUnidadEjecutora>(entity =>
            {
                entity.HasKey(e => e.IdIgedEjecutora);

                entity.ToTable("Dependecia_Unidad_Ejecutora", "ficha");

                entity.Property(e => e.IdIgedEjecutora)
                    .HasColumnName("Id_IGED_Ejecutora")
                    .ValueGeneratedNever();

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdUnidadEjecutora).HasColumnName("Id_Unidad_Ejecutora");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.DependeciaUnidadEjecutora)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_Dependecia_Unidad_Ejecutora_IGED");

                entity.HasOne(d => d.IdUnidadEjecutoraNavigation)
                    .WithMany(p => p.DependeciaUnidadEjecutora)
                    .HasForeignKey(d => d.IdUnidadEjecutora)
                    .HasConstraintName("FK_Dependecia_Unidad_Ejecutora_Unidad_Ejecutora1");
            });

            modelBuilder.Entity<DependenciaUnidadEjecutora>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dependencia_Unidad_Ejecutora", "ficha");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdIgedEjecutora).HasColumnName("Id_IGED_Ejecutora");

                entity.Property(e => e.IdIgedRegistro).HasColumnName("Id_IGED_Registro");

                entity.Property(e => e.IdUnidadEjecutora).HasColumnName("Id_Unidad_Ejecutora");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("Documento", "transaccional");

                entity.Property(e => e.IdDocumento).HasColumnName("Id_Documento");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("Fecha_Emision")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnName("Fecha_Publicacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdClasificacionDoc).HasColumnName("Id_Clasificacion_Doc");

                entity.Property(e => e.IdTipoDoc).HasColumnName("Id_Tipo_Doc");

                entity.Property(e => e.NombreArchivo)
                    .HasColumnName("Nombre_Archivo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumento)
                    .HasColumnName("Nro_Documento")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ruta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasificacionDocNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdClasificacionDoc)
                    .HasConstraintName("FK_Documento_Clasificacion_Documento");

                entity.HasOne(d => d.IdTipoDocNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdTipoDoc)
                    .HasConstraintName("FK_Documento_Tipo_Documento");
            });

            modelBuilder.Entity<DocumentoDirector>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoDirector);

                entity.ToTable("Documento_Director", "ficha");

                entity.Property(e => e.IdDocumentoDirector).HasColumnName("Id_Documento_Director");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDocumento).HasColumnName("Id_Documento");

                entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentoDirector)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("FK_Documento_Director_Documento");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.DocumentoDirector)
                    .HasForeignKey(d => d.IdPersonal)
                    .HasConstraintName("FK_Documento_Director_Personal");
            });

            modelBuilder.Entity<DocumentoRegistro>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoRegistro);

                entity.ToTable("Documento_Registro", "transaccional");

                entity.Property(e => e.IdDocumentoRegistro).HasColumnName("Id_Documento_Registro");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDocumento).HasColumnName("Id_Documento");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentoRegistro)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("FK_Documento_Registro_Documento");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.DocumentoRegistro)
                    .HasForeignKey(d => d.IdRegistro)
                    .HasConstraintName("FK_Documento_Registro_Registro");
            });

            modelBuilder.Entity<DocumentoSuspension>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoSuspension);

                entity.ToTable("Documento_Suspension", "transaccional");

                entity.Property(e => e.IdDocumentoSuspension).HasColumnName("Id_Documento_Suspension");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDocumento).HasColumnName("Id_Documento");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdSuspCanc).HasColumnName("Id_Susp_Canc");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentoSuspension)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("FK_Documento_Suspension_Documento");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.DocumentoSuspension)
                    .HasForeignKey(d => d.IdRegistro)
                    .HasConstraintName("FK_Documento_Suspension_Registro");

                entity.HasOne(d => d.IdSuspCancNavigation)
                    .WithMany(p => p.DocumentoSuspension)
                    .HasForeignKey(d => d.IdSuspCanc)
                    .HasConstraintName("FK_Documento_Suspension_Suspension_Cancelación");
            });

            modelBuilder.Entity<DocumentoTem>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoTem);

                entity.ToTable("Documento_Tem", "transaccional");

                entity.Property(e => e.IdDocumentoTem).HasColumnName("Id_Documento_Tem");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Finalidad)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NombreArchivo)
                    .HasColumnName("Nombre_Archivo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ruta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoIged>(entity =>
            {
                entity.HasKey(e => e.IdEstadoIged);

                entity.ToTable("Estado_IGED", "maestra");

                entity.Property(e => e.IdEstadoIged).HasColumnName("Id_Estado_IGED");

                entity.Property(e => e.CodEstadoIged).HasColumnName("Cod_Estado_IGED");

                entity.Property(e => e.DescEstadoIged)
                    .HasColumnName("Desc_Estado_IGED")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<EstadoRegistro>(entity =>
            {
                entity.HasKey(e => e.IdEstadoRegistro);

                entity.ToTable("Estado_Registro", "maestra");

                entity.Property(e => e.IdEstadoRegistro).HasColumnName("Id_Estado_Registro");

                entity.Property(e => e.CodEstadoRegistro).HasColumnName("Cod_Estado_Registro");

                entity.Property(e => e.DescEstadoRegistro)
                    .HasColumnName("Desc_Estado_Registro")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<EventoRegistral>(entity =>
            {
                entity.HasKey(e => e.IdEventoRegistral);

                entity.ToTable("Evento_Registral", "maestra");

                entity.Property(e => e.IdEventoRegistral).HasColumnName("Id_Evento_Registral");

                entity.Property(e => e.CodEvento).HasColumnName("Cod_Evento");

                entity.Property(e => e.DescEvento)
                    .HasColumnName("Desc_Evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdNaturaleza).HasColumnName("Id_Naturaleza");

                entity.HasOne(d => d.IdNaturalezaNavigation)
                    .WithMany(p => p.EventoRegistral)
                    .HasForeignKey(d => d.IdNaturaleza)
                    .HasConstraintName("FK_Evento_Registral_Naturaleza_Evento1");
            });

            modelBuilder.Entity<EventoXTipoIged>(entity =>
            {
                entity.HasKey(e => e.IdEventoTipoIged);

                entity.ToTable("Evento_xTipo_IGED", "configuracion");

                entity.Property(e => e.IdEventoTipoIged).HasColumnName("Id_Evento_Tipo_Iged");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdNaturaleza).HasColumnName("Id_Naturaleza");

                entity.Property(e => e.IdTipoIged).HasColumnName("Id_Tipo_IGED");

                entity.Property(e => e.IdTipoRegistro).HasColumnName("Id_Tipo_Registro");

                entity.HasOne(d => d.IdNaturalezaNavigation)
                    .WithMany(p => p.EventoXTipoIged)
                    .HasForeignKey(d => d.IdNaturaleza)
                    .HasConstraintName("FK_Evento_xTipo_IGED_Naturaleza_Evento");

                entity.HasOne(d => d.IdTipoIgedNavigation)
                    .WithMany(p => p.EventoXTipoIged)
                    .HasForeignKey(d => d.IdTipoIged)
                    .HasConstraintName("FK_Evento_xTipo_IGED_Tipo_IGED");

                entity.HasOne(d => d.IdTipoRegistroNavigation)
                    .WithMany(p => p.EventoXTipoIged)
                    .HasForeignKey(d => d.IdTipoRegistro)
                    .HasConstraintName("FK_Evento_xTipo_IGED_Tipo_Registro");
            });

            modelBuilder.Entity<EventosDesencadenados>(entity =>
            {
                entity.HasKey(e => e.IdEventoDesencadenado);

                entity.ToTable("Eventos_Desencadenados", "configuracion");

                entity.Property(e => e.IdEventoDesencadenado).HasColumnName("Id_Evento_Desencadenado");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdEventoColateral).HasColumnName("Id_Evento_Colateral");

                entity.Property(e => e.IdEventoOriginal).HasColumnName("Id_Evento_Original");

                entity.HasOne(d => d.IdEventoColateralNavigation)
                    .WithMany(p => p.EventosDesencadenadosIdEventoColateralNavigation)
                    .HasForeignKey(d => d.IdEventoColateral)
                    .HasConstraintName("FK_Eventos_Desencadenados_Evento_Registral1");

                entity.HasOne(d => d.IdEventoOriginalNavigation)
                    .WithMany(p => p.EventosDesencadenadosIdEventoOriginalNavigation)
                    .HasForeignKey(d => d.IdEventoOriginal)
                    .HasConstraintName("FK_Eventos_Desencadenados_Evento_Registral");
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(e => e.IdFormulario);

                entity.ToTable("Formulario", "configuracion");

                entity.Property(e => e.IdFormulario).HasColumnName("Id_Formulario");

                entity.Property(e => e.CodFormulario).HasColumnName("Cod_Formulario");

                entity.Property(e => e.DescFormulario)
                    .HasColumnName("Desc_Formulario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HIged>(entity =>
            {
                entity.HasKey(e => e.IdIgedHist);

                entity.ToTable("hIGED", "historica");

                entity.Property(e => e.IdIgedHist).HasColumnName("Id_IGED_Hist");

                entity.Property(e => e.CodDre)
                    .HasColumnName("Cod_DRE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CodEstadoIged).HasColumnName("Cod_Estado_IGED");

                entity.Property(e => e.CodIged)
                    .HasColumnName("Cod_IGED")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CodTipoIged).HasColumnName("Cod_Tipo_IGED");

                entity.Property(e => e.DescEstadoIged)
                    .HasColumnName("Desc_Estado_IGED")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DescTipoIged)
                    .HasColumnName("Desc_Tipo_IGED")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDre).HasColumnName("Id_DRE");

                entity.Property(e => e.IdEstadoIged).HasColumnName("Id_Estado_IGED");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdIgedRegistro).HasColumnName("Id_IGED_Registro");

                entity.Property(e => e.IdTipoIged).HasColumnName("Id_Tipo_IGED");

                entity.Property(e => e.Locales).HasColumnType("xml");

                entity.Property(e => e.MediosContacto).HasColumnType("xml");

                entity.Property(e => e.NomDre)
                    .HasColumnName("Nom_DRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomIged)
                    .HasColumnName("Nom_IGED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Personal).HasColumnType("xml");

                entity.Property(e => e.Ubigeo).HasColumnType("xml");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.HIged)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_hIGED_IGED");

                entity.HasOne(d => d.IdIgedRegistroNavigation)
                    .WithMany(p => p.HIged)
                    .HasForeignKey(d => d.IdIgedRegistro)
                    .HasConstraintName("FK_hIGED_IGED_Registro_Detalle");
            });

            modelBuilder.Entity<Iged>(entity =>
            {
                entity.HasKey(e => e.IdIged);

                entity.ToTable("IGED", "ficha");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.CodIged)
                    .HasColumnName("Cod_IGED")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstadoIged).HasColumnName("Id_Estado_IGED");

                entity.Property(e => e.IdTipoIged).HasColumnName("Id_Tipo_IGED");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoIgedNavigation)
                    .WithMany(p => p.Iged)
                    .HasForeignKey(d => d.IdEstadoIged)
                    .HasConstraintName("FK_IGED_Estado_IGED");

                entity.HasOne(d => d.IdTipoIgedNavigation)
                    .WithMany(p => p.Iged)
                    .HasForeignKey(d => d.IdTipoIged)
                    .HasConstraintName("FK_IGED_Tipo_IGED");
            });

            modelBuilder.Entity<IgedBasicos>(entity =>
            {
                entity.HasKey(e => e.IdIgedBasicos);

                entity.ToTable("IGED_BASICOS", "ficha");

                entity.Property(e => e.IdIgedBasicos).HasColumnName("Id_IGED_Basicos");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.EsUeAutonoma).HasColumnName("Es_UE_Autonoma");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDre).HasColumnName("Id_DRE");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdUbigeo).HasColumnName("Id_Ubigeo");

                entity.Property(e => e.IdUnidadEjecutora).HasColumnName("Id_Unidad_Ejecutora");

                entity.Property(e => e.NomIged)
                    .HasColumnName("Nom_IGED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDreNavigation)
                    .WithMany(p => p.IgedBasicosIdDreNavigation)
                    .HasForeignKey(d => d.IdDre)
                    .HasConstraintName("FK_IGED_BASICOS_IGED1");

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.IgedBasicosIdIgedNavigation)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_IGED_BASICOS_IGED");

                entity.HasOne(d => d.IdUbigeoNavigation)
                    .WithMany(p => p.IgedBasicos)
                    .HasForeignKey(d => d.IdUbigeo)
                    .HasConstraintName("FK_IGED_BASICOS_Ubigeo");

                entity.HasOne(d => d.IdUnidadEjecutoraNavigation)
                    .WithMany(p => p.IgedBasicos)
                    .HasForeignKey(d => d.IdUnidadEjecutora)
                    .HasConstraintName("FK_IGED_BASICOS_Unidad_Ejecutora");
            });

            modelBuilder.Entity<IgedMedioContacto>(entity =>
            {
                entity.HasKey(e => e.IdMedioContactoIged)
                    .HasName("PK_IGEL_Medio_Contacto");

                entity.ToTable("IGED_Medio_Contacto", "ficha");

                entity.Property(e => e.IdMedioContactoIged).HasColumnName("Id_Medio_Contacto_IGED");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdTipoMedioContacto).HasColumnName("Id_Tipo_Medio_Contacto");

                entity.Property(e => e.Medio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.IgedMedioContacto)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_IGEL_Medio_Contacto_IGED");

                entity.HasOne(d => d.IdTipoMedioContactoNavigation)
                    .WithMany(p => p.IgedMedioContacto)
                    .HasForeignKey(d => d.IdTipoMedioContacto)
                    .HasConstraintName("FK_IGEL_Medio_Contacto_Tipo_Medio_Contacto");
            });

            modelBuilder.Entity<IgedRegistroDetalle>(entity =>
            {
                entity.HasKey(e => e.IdIgedRegistro);

                entity.ToTable("IGED_Registro_Detalle", "transaccional");

                entity.Property(e => e.IdIgedRegistro).HasColumnName("Id_IGED_Registro");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.EsOrigen).HasColumnName("Es_Origen");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDre).HasColumnName("Id_DRE");

                entity.Property(e => e.IdEventoRegistral).HasColumnName("Id_Evento_Registral");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoIged).HasColumnName("Id_Tipo_IGED");

                entity.Property(e => e.IdUbigeoIged).HasColumnName("Id_Ubigeo_IGED");

                entity.Property(e => e.Motivo).HasColumnType("text");

                entity.Property(e => e.NomIged)
                    .HasColumnName("Nom_IGED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventoRegistralNavigation)
                    .WithMany(p => p.IgedRegistroDetalle)
                    .HasForeignKey(d => d.IdEventoRegistral)
                    .HasConstraintName("FK_IGED_Registro_Detalle_Evento_Registral");

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.IgedRegistroDetalle)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_IGED_Registro_Detalle_IGED");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.IgedRegistroDetalle)
                    .HasForeignKey(d => d.IdRegistro)
                    .HasConstraintName("FK_IGED_Registro_Detalle_Registro");

                entity.HasOne(d => d.IdUbigeoIgedNavigation)
                    .WithMany(p => p.IgedRegistroDetalle)
                    .HasForeignKey(d => d.IdUbigeoIged)
                    .HasConstraintName("FK_IGED_Registro_Detalle_Ubigeo");
            });

            modelBuilder.Entity<JurisdiccionIged>(entity =>
            {
                entity.HasKey(e => e.IdJurisdiccion);

                entity.ToTable("Jurisdiccion_IGED", "ficha");

                entity.Property(e => e.IdJurisdiccion).HasColumnName("Id_Jurisdiccion");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTerminoCantidad).HasColumnName("Id_Termino_Cantidad");

                entity.Property(e => e.IdTerminoPertenencia).HasColumnName("Id_Termino_Pertenencia");

                entity.Property(e => e.IdUbigeo).HasColumnName("Id_Ubigeo");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.JurisdiccionIged)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_Jurisdiccion_IGED_IGED");

                entity.HasOne(d => d.IdTerminoCantidadNavigation)
                    .WithMany(p => p.JurisdiccionIged)
                    .HasForeignKey(d => d.IdTerminoCantidad)
                    .HasConstraintName("FK_Jurisdiccion_IGED_Termino_Cantidad_Jurisdiccion");

                entity.HasOne(d => d.IdTerminoPertenenciaNavigation)
                    .WithMany(p => p.JurisdiccionIged)
                    .HasForeignKey(d => d.IdTerminoPertenencia)
                    .HasConstraintName("FK_Jurisdiccion_IGED_Termino_Pertenencia_Jurisdiccion");

                entity.HasOne(d => d.IdUbigeoNavigation)
                    .WithMany(p => p.JurisdiccionIged)
                    .HasForeignKey(d => d.IdUbigeo)
                    .HasConstraintName("FK_Jurisdiccion_IGED_Ubigeo");
            });

            modelBuilder.Entity<LocalIged>(entity =>
            {
                entity.HasKey(e => e.IdLocalIged)
                    .HasName("PK_Local_IGEL");

                entity.ToTable("Local_IGED", "ficha");

                entity.Property(e => e.IdLocalIged).HasColumnName("Id_Local_IGED");

                entity.Property(e => e.DireccionLocal)
                    .HasColumnName("Direccion_Local")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoLocal).HasColumnName("Id_Tipo_Local");

                entity.Property(e => e.IdTipoPropiedad).HasColumnName("Id_Tipo_Propiedad");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.LocalIged)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_Local_IGEL_IGED");

                entity.HasOne(d => d.IdTipoLocalNavigation)
                    .WithMany(p => p.LocalIged)
                    .HasForeignKey(d => d.IdTipoLocal)
                    .HasConstraintName("FK_Local_IGEL_Tipo_Local");

                entity.HasOne(d => d.IdTipoPropiedadNavigation)
                    .WithMany(p => p.LocalIged)
                    .HasForeignKey(d => d.IdTipoPropiedad)
                    .HasConstraintName("FK_Local_IGEL_Tipo_Propiedad");
            });

            modelBuilder.Entity<NaturalezaEvento>(entity =>
            {
                entity.HasKey(e => e.IdNaturaleza);

                entity.ToTable("Naturaleza_Evento", "maestra");

                entity.HasComment("Agrupa los tipos de eventos registrales dentro de Creación, Modificación, Cierre u otros que pudieran existir");

                entity.Property(e => e.IdNaturaleza).HasColumnName("Id_Naturaleza");

                entity.Property(e => e.CodNaturaleza).HasColumnName("Cod_Naturaleza");

                entity.Property(e => e.DescNaturaleza)
                    .HasColumnName("Desc_Naturaleza")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<OrigenSuspencionCancelacion>(entity =>
            {
                entity.HasKey(e => e.IdOrigenSuspCanc)
                    .HasName("PK_Origen_Suspencion_Cancelacion_1");

                entity.ToTable("Origen_Suspencion_Cancelacion", "maestra");

                entity.Property(e => e.IdOrigenSuspCanc).HasColumnName("Id_Origen_Susp_Canc");

                entity.Property(e => e.CodTipoSuspCanc).HasColumnName("Cod_Tipo_Susp_Canc");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.ToTable("Parametro", "configuracion");

                entity.Property(e => e.IdParametro).HasColumnName("Id_Parametro");

                entity.Property(e => e.CodParametro).HasColumnName("Cod_Parametro");

                entity.Property(e => e.DescParamentro)
                    .HasColumnName("Desc_Paramentro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.ValorDecimal).HasColumnName("Valor_Decimal");

                entity.Property(e => e.ValorFecha)
                    .HasColumnName("Valor_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.ValorInt).HasColumnName("Valor_Int");

                entity.Property(e => e.ValorString)
                    .HasColumnName("Valor_String")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona", "transaccional");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.ApmPersona)
                    .HasColumnName("Apm_Persona")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AppPersona)
                    .HasColumnName("App_Persona")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DniPersona)
                    .HasColumnName("DNI_Persona")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.NomPersona)
                    .HasColumnName("Nom_Persona")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal);

                entity.ToTable("Personal", "ficha");

                entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdIged).HasColumnName("Id_IGED");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoPersonal).HasColumnName("Id_Tipo_Personal");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIgedNavigation)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.IdIged)
                    .HasConstraintName("FK_Personal_IGED");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_Personal_Persona");

                entity.HasOne(d => d.IdTipoPersonalNavigation)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.IdTipoPersonal)
                    .HasConstraintName("FK_Personal_Tipo_Personal");
            });

            modelBuilder.Entity<PersonalMedioContacto>(entity =>
            {
                entity.HasKey(e => e.IdMedioContactoPersonal);

                entity.ToTable("Personal_Medio_Contacto", "ficha");

                entity.Property(e => e.IdMedioContactoPersonal).HasColumnName("Id_Medio_Contacto_Personal");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoMedioContacto).HasColumnName("Id_Tipo_Medio_Contacto");

                entity.Property(e => e.Medio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.PersonalMedioContacto)
                    .HasForeignKey(d => d.IdPersonal)
                    .HasConstraintName("FK_Personal_Medio_Contacto_Personal");

                entity.HasOne(d => d.IdTipoMedioContactoNavigation)
                    .WithMany(p => p.PersonalMedioContacto)
                    .HasForeignKey(d => d.IdTipoMedioContacto)
                    .HasConstraintName("FK_Personal_Medio_Contacto_Tipo_Medio_Contacto");
            });

            modelBuilder.Entity<PliegoUnidadEjecutora>(entity =>
            {
                entity.HasKey(e => e.IdPliegoUnidadEjecutora);

                entity.ToTable("Pliego_Unidad_Ejecutora", "maestra");

                entity.Property(e => e.IdPliegoUnidadEjecutora).HasColumnName("Id_Pliego_Unidad_Ejecutora");

                entity.Property(e => e.CodPliegoUnidadEjecutora)
                    .HasColumnName("Cod_Pliego_Unidad_Ejecutora")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescPliegoUnidadEjecutora)
                    .HasColumnName("Desc_Pliego_Unidad_Ejecutora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.IdRegistro);

                entity.ToTable("Registro", "transaccional");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.CodRegistro)
                    .HasColumnName("Cod_Registro")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechAsiento)
                    .HasColumnName("Fech_Asiento")
                    .HasColumnType("date");

                entity.Property(e => e.FechCreacion)
                    .HasColumnName("Fech_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechModificacion)
                    .HasColumnName("Fech_Modificacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstadoRegistro).HasColumnName("Id_Estado_registro");

                entity.Property(e => e.IdTipoRegistro).HasColumnName("Id_Tipo_Registro");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoRegistroNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.IdEstadoRegistro)
                    .HasConstraintName("FK_Registro_Estado_Registro");

                entity.HasOne(d => d.IdTipoRegistroNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.IdTipoRegistro)
                    .HasConstraintName("FK_Registro_Tipo_Registro");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol", "configuracion");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.CodRol).HasColumnName("Cod_Rol");

                entity.Property(e => e.DescRol)
                    .HasColumnName("Desc_Rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RutaArchivos>(entity =>
            {
                entity.HasKey(e => e.IdRuta);

                entity.ToTable("Ruta_Archivos", "configuracion");

                entity.Property(e => e.IdRuta).HasColumnName("Id_Ruta");

                entity.Property(e => e.CodRuta).HasColumnName("Cod_Ruta");

                entity.Property(e => e.DescRuta)
                    .HasColumnName("Desc_ruta")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SuspensionCancelación>(entity =>
            {
                entity.HasKey(e => e.IdSuspCanc);

                entity.ToTable("Suspension_Cancelación", "transaccional");

                entity.Property(e => e.IdSuspCanc).HasColumnName("Id_Susp_Canc");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSuspension)
                    .HasColumnName("Fecha_Suspension")
                    .HasColumnType("date");

                entity.Property(e => e.IdOrigenSuspCanc).HasColumnName("Id_Origen_Susp_Canc");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoSuspCanc).HasColumnName("Id_Tipo_Susp_Canc");

                entity.Property(e => e.MotivoSuspension)
                    .HasColumnName("Motivo_Suspension")
                    .HasColumnType("text");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOrigenSuspCancNavigation)
                    .WithMany(p => p.SuspensionCancelación)
                    .HasForeignKey(d => d.IdOrigenSuspCanc)
                    .HasConstraintName("FK_Suspension_Cancelación_Origen_Suspencion_Cancelacion");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.SuspensionCancelación)
                    .HasForeignKey(d => d.IdRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suspension_Cancelación_Registro");

                entity.HasOne(d => d.IdTipoSuspCancNavigation)
                    .WithMany(p => p.SuspensionCancelación)
                    .HasForeignKey(d => d.IdTipoSuspCanc)
                    .HasConstraintName("FK_Suspension_Cancelación_Tipo_Suspension_Cancelacion");
            });

            modelBuilder.Entity<TerminoCantidadJurisdiccion>(entity =>
            {
                entity.HasKey(e => e.IdTerminoCantidad);

                entity.ToTable("Termino_Cantidad_Jurisdiccion", "configuracion");

                entity.Property(e => e.IdTerminoCantidad).HasColumnName("Id_Termino_Cantidad");

                entity.Property(e => e.CodTerminoCantidad).HasColumnName("Cod_Termino_Cantidad");

                entity.Property(e => e.DescTerminoCantidad)
                    .HasColumnName("Desc_Termino_Cantidad")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TerminoPertenenciaJurisdiccion>(entity =>
            {
                entity.HasKey(e => e.IdTerminoPertenencia);

                entity.ToTable("Termino_Pertenencia_Jurisdiccion", "configuracion");

                entity.Property(e => e.IdTerminoPertenencia).HasColumnName("Id_Termino_Pertenencia");

                entity.Property(e => e.CodTerminoPertenencia).HasColumnName("Cod_Termino_Pertenencia");

                entity.Property(e => e.DescTerminoPertenencia)
                    .HasColumnName("Desc_Termino_Pertenencia")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDoc);

                entity.ToTable("Tipo_Documento", "maestra");

                entity.Property(e => e.IdTipoDoc).HasColumnName("Id_Tipo_Doc");

                entity.Property(e => e.CodTipoDoc).HasColumnName("Cod_Tipo_Doc");

                entity.Property(e => e.DescTipoDoc)
                    .HasColumnName("Desc_Tipo_Doc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoIged>(entity =>
            {
                entity.HasKey(e => e.IdTipoIged);

                entity.ToTable("Tipo_IGED", "maestra");

                entity.Property(e => e.IdTipoIged).HasColumnName("Id_Tipo_IGED");

                entity.Property(e => e.CodTipoIged).HasColumnName("Cod_Tipo_IGED");

                entity.Property(e => e.DescTipoIged)
                    .HasColumnName("Desc_Tipo_IGED")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoLocal>(entity =>
            {
                entity.HasKey(e => e.IdTipoLocal);

                entity.ToTable("Tipo_Local", "maestra");

                entity.Property(e => e.IdTipoLocal).HasColumnName("Id_Tipo_Local");

                entity.Property(e => e.CodTipoLocal).HasColumnName("Cod_Tipo_Local");

                entity.Property(e => e.DescTipoLocal)
                    .HasColumnName("Desc_Tipo_Local")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoMedioContacto>(entity =>
            {
                entity.HasKey(e => e.IdTipoMedioContacto);

                entity.ToTable("Tipo_Medio_Contacto", "maestra");

                entity.Property(e => e.IdTipoMedioContacto).HasColumnName("Id_Tipo_Medio_Contacto");

                entity.Property(e => e.CodTipoMedio).HasColumnName("Cod_Tipo_Medio");

                entity.Property(e => e.DescTipoMedio)
                    .HasColumnName("Desc_Tipo_Medio")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoPersonal>(entity =>
            {
                entity.HasKey(e => e.IdTipoPersonal);

                entity.ToTable("Tipo_Personal", "maestra");

                entity.Property(e => e.IdTipoPersonal).HasColumnName("Id_Tipo_Personal");

                entity.Property(e => e.CodTipoPersonal).HasColumnName("Cod_Tipo_Personal");

                entity.Property(e => e.DescTipoPersonal)
                    .HasColumnName("Desc_Tipo_Personal")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoPropiedad>(entity =>
            {
                entity.HasKey(e => e.IdTipoPropiedad);

                entity.ToTable("Tipo_Propiedad", "maestra");

                entity.Property(e => e.IdTipoPropiedad).HasColumnName("Id_Tipo_Propiedad");

                entity.Property(e => e.CodTipoPropiedad).HasColumnName("Cod_Tipo_Propiedad");

                entity.Property(e => e.DescTipoPropiedad)
                    .HasColumnName("Desc_Tipo_Propiedad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoRegistro>(entity =>
            {
                entity.HasKey(e => e.IdTipoRegistro);

                entity.ToTable("Tipo_Registro", "maestra");

                entity.HasComment("1 Provisional, 2 Definitivo");

                entity.Property(e => e.IdTipoRegistro)
                    .HasColumnName("Id_Tipo_Registro")
                    .HasComment("Identificador único interno del registro, autoincremental");

                entity.Property(e => e.CodTipoRegistro)
                    .HasColumnName("Cod_Tipo_Registro")
                    .HasComment("Código que identifica al tipo de registro");

                entity.Property(e => e.DescTipoRegistro)
                    .HasColumnName("Desc_Tipo_Registro")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("Descripción del tipo de registro");

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoSuspensionCancelacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoSuspCanc)
                    .HasName("PK_Tipo_Suspension");

                entity.ToTable("Tipo_Suspension_Cancelacion", "maestra");

                entity.Property(e => e.IdTipoSuspCanc).HasColumnName("Id_Tipo_Susp_Canc");

                entity.Property(e => e.CodTipoSuspCanc).HasColumnName("Cod_Tipo_Susp_Canc");

                entity.Property(e => e.DescTipoSuspCanc)
                    .HasColumnName("Desc_Tipo_Susp_Canc")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<TipoUbigeo>(entity =>
            {
                entity.HasKey(e => e.IdTipoUbigeo);

                entity.ToTable("Tipo_Ubigeo", "maestra");

                entity.Property(e => e.IdTipoUbigeo).HasColumnName("Id_Tipo_Ubigeo");

                entity.Property(e => e.CodTipoUbigeo).HasColumnName("Cod_Tipo_Ubigeo");

                entity.Property(e => e.DescTipoUbigeo)
                    .HasColumnName("Desc_Tipo_Ubigeo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");
            });

            modelBuilder.Entity<Ubigeo>(entity =>
            {
                entity.HasKey(e => e.IdUbigeo);

                entity.ToTable("Ubigeo", "maestra");

                entity.Property(e => e.IdUbigeo).HasColumnName("Id_Ubigeo");

                entity.Property(e => e.CodCcpp)
                    .HasColumnName("Cod_CCPP")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodDistrito)
                    .HasColumnName("Cod_Distrito")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CodProvincia)
                    .HasColumnName("Cod_Provincia")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodRegion)
                    .HasColumnName("Cod_Region")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodUbigeo)
                    .HasColumnName("Cod_Ubigeo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.IdCcpp).HasColumnName("Id_CCPP");

                entity.Property(e => e.IdDistrito).HasColumnName("Id_Distrito");

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.IdRegion).HasColumnName("Id_Region");

                entity.Property(e => e.IdTipoUbigeo).HasColumnName("Id_Tipo_Ubigeo");

                entity.Property(e => e.NomCcpp)
                    .HasColumnName("Nom_CCPP")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomDistrito)
                    .HasColumnName("Nom_Distrito")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomProvincia)
                    .HasColumnName("Nom_Provincia")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomRegion)
                    .HasColumnName("Nom_Region")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUbigeoNavigation)
                    .WithMany(p => p.Ubigeo)
                    .HasForeignKey(d => d.IdTipoUbigeo)
                    .HasConstraintName("FK_Ubigeo_Tipo_Ubigeo");
            });

            modelBuilder.Entity<UnidadEjecutora>(entity =>
            {
                entity.HasKey(e => e.IdUnidadEjecutora);

                entity.ToTable("Unidad_Ejecutora", "maestra");

                entity.Property(e => e.IdUnidadEjecutora).HasColumnName("Id_Unidad_Ejecutora");

                entity.Property(e => e.CodUnidadEjecutora)
                    .HasColumnName("Cod_Unidad_Ejecutora")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DescUnidadEjecutora)
                    .HasColumnName("Desc_Unidad_Ejecutora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsActivo).HasColumnName("Es_Activo");

                entity.Property(e => e.EsBorrado).HasColumnName("Es_Borrado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPliegoUnidadEjecutora).HasColumnName("Id_Pliego_Unidad_Ejecutora");

                entity.Property(e => e.UsuActualizacion)
                    .HasColumnName("Usu_Actualizacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreacion)
                    .HasColumnName("Usu_Creacion")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPliegoUnidadEjecutoraNavigation)
                    .WithMany(p => p.UnidadEjecutora)
                    .HasForeignKey(d => d.IdPliegoUnidadEjecutora)
                    .HasConstraintName("FK_Unidad_Ejecutora_Pliego_Unidad_Ejecutora");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
