using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoMedioContacto
    {
        public TipoMedioContacto()
        {
            IgelMedioContacto = new HashSet<IgelMedioContacto>();
            PersonalMedioContacto = new HashSet<PersonalMedioContacto>();
        }

        public int IdTipoMedioContacto { get; set; }
        public int? CodTipoTelefono { get; set; }
        public string DescTipoTelefono { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<IgelMedioContacto> IgelMedioContacto { get; set; }
        public virtual ICollection<PersonalMedioContacto> PersonalMedioContacto { get; set; }
    }
}
