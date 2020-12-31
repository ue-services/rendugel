using System;
using System.Collections.Generic;

namespace Rendugel.Dominio.Entidades.Modelo
{
    public partial class TipoMedioContacto
    {
        public TipoMedioContacto()
        {
            IgedMedioContacto = new HashSet<IgedMedioContacto>();
            PersonalMedioContacto = new HashSet<PersonalMedioContacto>();
        }

        public int IdTipoMedioContacto { get; set; }
        public int? CodTipoMedio { get; set; }
        public string DescTipoMedio { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsBorrado { get; set; }

        public virtual ICollection<IgedMedioContacto> IgedMedioContacto { get; set; }
        public virtual ICollection<PersonalMedioContacto> PersonalMedioContacto { get; set; }
    }
}
