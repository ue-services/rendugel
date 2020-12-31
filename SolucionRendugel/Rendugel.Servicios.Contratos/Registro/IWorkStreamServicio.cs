using Rendugel.Transversal.Entidades;
using Rendugel.Transversal.Entidades.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Servicios.Contratos.Registro
{
    [ServiceContract]
    public interface IWorkStreamServicio
    {
        [WebInvoke(
            Method = "POST",
            //BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Upload",
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        UploadTempResponse Upload(Stream data);

        [WebInvoke(
            Method = "POST",
             UriTemplate = "/Download",
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream Download(EDocumento documento);

        /* [WebGet(UriTemplate = "/OpcionesUbigeo/{IdDre}", ResponseFormat = WebMessageFormat.Json)]
         [OperationContract]
         EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre);
        */
    }
}
