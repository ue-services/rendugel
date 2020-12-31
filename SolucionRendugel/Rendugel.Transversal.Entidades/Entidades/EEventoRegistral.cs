using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EEventoRegistral
    {
        public int IdEventoRegistral { get; set; }
        public int? CodEvento { get; set; }
        public string DescEvento { get; set; }
        //public int? IdNaturaleza { get; set; }
        public ENaturaleza Naturaleza { get; set; }
    }
}
