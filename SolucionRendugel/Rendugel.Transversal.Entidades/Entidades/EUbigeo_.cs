using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EUbigeo_
    {
        public int IdUbigeo { get; set; }
        public string CodUbigeo { get; set; }
        public string Nombre { get; set; }
        public ETipoUbigeo TipoUbigeo { get; set; }
        //public int? IdRegion { get; set; }
        public string CodRegion { get; set; }
        public string NomRegion { get; set; }
        //public int? IdProvincia { get; set; }
        public string CodProvincia { get; set; }
        public string NomProvincia { get; set; }
        //public int? IdDistrito { get; set; }
        public string CodDistrito { get; set; }
        public string NomDistrito { get; set; }
        //public int? IdCcpp { get; set; }
        public string CodCcpp { get; set; }
        public string NomCcpp { get; set; }
    }
}
