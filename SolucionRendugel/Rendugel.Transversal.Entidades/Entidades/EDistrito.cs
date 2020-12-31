using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EDistrito
    {
        public int IdUbigeo { get; set; }
        public string CodUbigeo { get; set; }
        public string Nombre { get; set; }
        public EProvincia Provincia { get; set; }
    }
}
