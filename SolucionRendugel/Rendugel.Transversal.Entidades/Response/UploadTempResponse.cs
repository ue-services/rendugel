using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades.Response
{
    public class UploadTempResponse
    {
        public EDocumentoTem data { get; set; }
        public bool result { get; set; }
        public string message { get; set; }
    }
}
