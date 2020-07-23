using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Configuracion
    {
        public int IdConfiguracion { get; set; }
        public int? IdRol { get; set; }
        public int? IdFormulario { get; set; }
        public int? IdComponente { get; set; }
        public int? IdAccion { get; set; }
        public int? IdEstadoRegistro { get; set; }
        public bool? EsVisible { get; set; }
        public bool? EsEditable { get; set; }
        public bool? EsObligatorio { get; set; }
        public string ConfiguracionJson { get; set; }
        public string UsuCreacion { get; set; }
        public string FechaCreacion { get; set; }
        public string UsuActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual Accion IdAccionNavigation { get; set; }
        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual EstadoRegistro IdEstadoRegistroNavigation { get; set; }
        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
