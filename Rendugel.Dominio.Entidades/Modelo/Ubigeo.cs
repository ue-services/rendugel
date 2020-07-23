using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class Ubigeo
    {
        public Ubigeo()
        {
            IgedBasicos = new HashSet<IgedBasicos>();
            JurisdiccionIged = new HashSet<JurisdiccionIged>();
        }

        public int IdUbigeo { get; set; }
        public string CodUbigeo { get; set; }
        public int? IdTipoUbigeo { get; set; }
        public int? IdRegion { get; set; }
        public string CodRegion { get; set; }
        public string NomRegion { get; set; }
        public int? IdProvincia { get; set; }
        public string CodProvincia { get; set; }
        public string NomProvincia { get; set; }
        public int? IdDistrito { get; set; }
        public string CodDistrito { get; set; }
        public string NomDistrito { get; set; }
        public int? IdCcpp { get; set; }
        public string NomCcpp { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual TipoUbigeo IdTipoUbigeoNavigation { get; set; }
        public virtual ICollection<IgedBasicos> IgedBasicos { get; set; }
        public virtual ICollection<JurisdiccionIged> JurisdiccionIged { get; set; }
    }
}
