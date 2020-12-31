using Rendugel.Servicios.Contratos.Registro;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
//using System.Net.Http.Formatting;
//using Microsoft.Net.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Web;
using System.Net.Mime;
using System.ServiceModel.Web;
using HttpMultipartParser;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Rendugel.Aplicacion.Registro;
using Rendugel.Transversal.Entidades.Response;

namespace Rendugel.Servicios.Servicio.Registro
{
    public class WorkStreamServicio : IWorkStreamServicio
    {
        readonly ComunRegistro comunRegistro = new ComunRegistro();
        public Stream Download(EDocumento documento)
        {
               /* EUser user = new EUser
                {
                    nameId = "40615837",j
                    IdUser = 0
                };*/

                /*documento = new EDocumento
                {
                    NombreArchivo = "DeCreacion.pdf",
                 };*/

                string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];
                var path = Path.Combine(rutaBase, documento.Ruta);
                var fullPath = Path.Combine(path, documento.NombreArchivo);

                FileStream f = new FileStream(fullPath, FileMode.Open);
                int length = (int)f.Length;

                WebOperationContext.Current.OutgoingResponse.ContentLength = length;
                byte[] buffer = new byte[length];
                int sum = 0;
                int count;
                while ((count = f.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;
                }
                f.Close();
                return new MemoryStream(buffer);
        }
        
        /* public EOpcionesUbigeo ObtenerOpcionesUbigeo(string IdDre)
{
    throw new NotImplementedException();
}*/

        public UploadTempResponse Upload(Stream data)        {

            // Boundary is auto-detected but can also be specified.
            //var parser = new MultipartFormDataParser(data, Encoding.UTF8
            EUser user = new EUser
                { nameId = "_",
                  IdUser=0
                };

            //EDocumento documento = new EDocumento();
            EDocumentoTem documentoTem = new EDocumentoTem();

            string descTipoFuncion; // = "DeCreacion"; //"DeDesignacionDirector"          

            UploadTempResponse uploadTempResponse = new UploadTempResponse();
            Complementarias complementarias = new Complementarias();

            var parser = MultipartFormDataParser.Parse(data);

            //Parámetros
            string username = parser.GetParameterValue("usuario");
            string finalidad = parser.GetParameterValue("finalidad");
            string idDocumentoTemString = parser.GetParameterValue("idDocumentoTem");
            int _idDocumentoTem = 0;

            if (idDocumentoTemString != null && idDocumentoTemString != "" && idDocumentoTemString!="0")
            {
                _idDocumentoTem = int.Parse(idDocumentoTemString);

                /*uploadTempResponse.result = false;
                uploadTempResponse.message = _idDocumento.ToString() + " **";
                uploadTempResponse.data = null;
                
                return uploadTempResponse;*/
            }            

            user.nameId = username;
            descTipoFuncion = username + finalidad;

            // Files are stored in a list:
            var file = parser.Files.First();
            string filename = file.FileName;

            //******Validar la extención****
            ValidacionResponse validarExtension = new ValidacionResponse();
            validarExtension = complementarias.validarExtension(filename, ".pdf");           
            if (!(validarExtension.result))
            {
                uploadTempResponse.result = false;
                uploadTempResponse.message = validarExtension.message;
                uploadTempResponse.data = null;

                return uploadTempResponse;
            }
            
            Stream dataResult = file.Data;
            //******Validar la tamaño****

            ValidacionResponse validarTamanio = new ValidacionResponse();
            validarTamanio = complementarias.validarTamanio(dataResult, 1);
            if (!(validarTamanio.result))
            {
                uploadTempResponse.result = false;
                uploadTempResponse.message = validarTamanio.message;
                uploadTempResponse.data = null;

                return uploadTempResponse;
            }

            ValidacionResponse validarFidelidad = new ValidacionResponse();
            validarFidelidad = complementarias.validarFidelidad(dataResult);
            if (!(validarFidelidad.result))
            {
                uploadTempResponse.result = false;
                uploadTempResponse.message = validarFidelidad.message;
                uploadTempResponse.data = null;

                return uploadTempResponse;
            }

            string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];
            //Crear un nombre temporal_aleatorio. combinación de fecha + random
            try
            {
                var ruta = Path.Combine("Temporales", user.nameId);
                var path = Path.Combine(rutaBase, ruta);
                
                // SI EL DIRECTORIO DE USUARIO NO EXISTE: CREA.
                if (!(Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                }

                //SI DIRECTORIO EXISTE:
                if ((Directory.Exists(path)))
                {
                    //CREA EL NOMBRE DEL ARCHIVO
                    var newFileName = descTipoFuncion + ".pdf";
                    //var fullPath = @"logo-minedu3.pdf";
                    var fullPath = Path.Combine(path, newFileName);

                    try
                    {
                        if (File.Exists(fullPath))
                        {
                            FileInfo fi2 = new FileInfo(fullPath);
                            fi2.Delete();
                        }
                    }
                    catch (Exception e) {
                        newFileName = descTipoFuncion + "1" + ".pdf";
                        fullPath = Path.Combine(path, newFileName);
                    }
                   
                    using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        try
                        {
                            dataResult.Seek(0, SeekOrigin.Begin);
                            //dataResult.CopyTo(fileStream, input.Length);
                            dataResult.CopyTo(fileStream);
                            //fileStream.Flush();

                            //EClasificacionDocumento clasificacion = new EClasificacionDocumento();
                            //clasificacion.IdClasificacionDoc = 1;
                            //ETipoDocumento tipoDocumento = new ETipoDocumento();
                            //tipoDocumento.IdTipoDoc = 1;
                            documentoTem.IdDocumentoTem = _idDocumentoTem;
                            documentoTem.NombreArchivo = newFileName; // fileStream.Name;
                            documentoTem.Ruta = ruta;// path.ToString();
                            documentoTem.Finalidad = finalidad;
                            //documento.Temporal = true;                            
                            //documento.ClasificacionDocumento = clasificacion; //Resolutivo, cambiar esto depues.
                            //documento.NroDocumento = "1234567891";
                            //documento.TipoDocumento = tipoDocumento;                            
                            try
                            {
                                EDocumentoTem _documentoTem = new EDocumentoTem();
                                uploadTempResponse = comunRegistro.GrabarDatosDocumentoTemporal(documentoTem);
                                //uploadTempResponse.result = true;
                                //uploadTempResponse.message = "OK";
                                //uploadTempResponse.data = _documentoTem;
                                return uploadTempResponse;
                            }
                            catch (Exception e)
                            {
                                uploadTempResponse.result = false;
                                uploadTempResponse.message = e.Message.ToString()
                                                            + e.Source.ToString()
                                                            + e.Data.ToString()
                                                            + "Error al grabar"
                                                            + " id: " + documentoTem.IdDocumentoTem.ToString()
                                                            + " Nombre: " + documentoTem.NombreArchivo
                                                            + " Ruta:" + documentoTem.Ruta
                                                            + " Finalidad: " + documentoTem.Finalidad;
                                uploadTempResponse.data = null;
                                return uploadTempResponse;
                            }                                                    

                        }
                        catch (Exception e)
                        {
                            uploadTempResponse.result = false;
                            uploadTempResponse.message = e.Message.ToString() + "Error al intentar copiar el archivo" 
                                                        + " id: " + documentoTem.IdDocumentoTem.ToString() 
                                                        + " Nombre: " + documentoTem.NombreArchivo 
                                                        + " Ruta:" + documentoTem.Ruta
                                                        + " Finalidad: " + documentoTem.Finalidad;
                            uploadTempResponse.data = null;

                            return uploadTempResponse;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
            //return resp + " tamaño: " + FileLen.ToString(); // "OK-Ana " + filename; 
            uploadTempResponse.result = false;
            uploadTempResponse.message = "Ocurrio Algo";
            uploadTempResponse.data = null;
            return uploadTempResponse;
        }

       /* public string UploadBackup(Stream data)
        {

            // Boundary is auto-detected but can also be specified.
            //var parser = new MultipartFormDataParser(data, Encoding.UTF8
            EUser user = new EUser
            {
                nameId = "40615837",
                IdUser = 0
            };
            EDocumento documento = new EDocumento();            

            string descTipoFuncion = "DeCreacion2"; //DeDesignacionDirector
             

            string resp = "_";
            var parser = MultipartFormDataParser.Parse(data);

            
            // Files are stored in a list:
            var file = parser.Files.First();
            string filename = file.FileName;
            Stream dataResult = file.Data;

            string extension = Path.GetExtension(file.FileName);

            string rutaBase = ConfigurationManager.AppSettings["URL_FILE_SERVER"];
            long FileLen = dataResult.Length;

            byte[] input = new byte[FileLen];

            //Obteniendo el archivo en Base64String
            using (var memoryStream = new MemoryStream())
            {
                file.Data.CopyTo(memoryStream);
                input = memoryStream.ToArray();
            }

            /////Begin Valid PDF CORRUPTED/////
            if (input[0] != 0x25 || input[1] != 0x50 || input[2] != 0x44 || input[3] != 0x46)
            {
                //fuResp.Success = false;
                //fuResp.Message = "No es posible cargar un documento corrupto.";
                //return Ok(fuResp);
                resp = "No es posible cargar un documento corrupto.";
                return resp;
            }
            /////End Valid PDF CORRUPTED/////

            //Crear un nombre temporal_aleatorio. combinación de fecha + random
            try
            {
                var path = Path.Combine(rutaBase, user.nameId);

                // SI EL DIRECTORIO DE USUARIO NO EXISTE: CREA.
                if (!(Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                }

                //SI DIRECTORIO EXISTE:
                if ((Directory.Exists(path)))
                {
                    //CREA EL NOMBRE DEL ARCHIVO
                    var newFileName = descTipoFuncion + ".pdf";
                    //var fullPath = @"logo-minedu3.pdf";
                    var fullPath = Path.Combine(path, newFileName);

                    try
                    {
                        if (File.Exists(fullPath))
                        {
                            FileInfo fi2 = new FileInfo(fullPath);
                            fi2.Delete();
                        }
                    }
                    catch (Exception e)
                    {
                        newFileName = descTipoFuncion + "1" + ".pdf";
                        fullPath = Path.Combine(path, newFileName);
                    }

                    using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        try
                        {
                            dataResult.Seek(0, SeekOrigin.Begin);
                            //dataResult.CopyTo(fileStream, input.Length);
                            dataResult.CopyTo(fileStream);
                            //fileStream.Flush();
                            resp = " ok -copiado";
                        }
                        catch (Exception e)
                        {
                            resp = e.Message.ToString();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }




            //fileStream.Dispose();
            //var fileStream = File.Create("F:\\copiarAqui");
            //dataResult.CopyTo(fileStream);
            //fileStream.Close();

            //string username = parser.GetParameterValue("username");
            //string password = parser.GetParameterValue("password");
            //string username = parser.Parameters["username"].Data;
            //string password = parser.Parameters["password"].Data;

            //return username + " - " + password;

            return resp + " tamaño: " + FileLen.ToString(); // "OK-Ana " + filename;

            //var streamContent = new StreamContent(data);

            //string contentType = WebOperationContext.Current.IncomingRequest.ContentType;
            //streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

            //var provider = streamContent.ReadAsFormDataAsync();

            //provider.Result.ToString();
            //    return provider.ToString();

            //string username = null;
            //string password = null;

            //MultipartParser parser = new MultipartParser(stream);

            ///HttpMultipartParser parser = new HttpMultipartParser(data);
            //if (parser.Success)
            //{
            //   username = HttpUtility.UrlDecode(parser.Parameters["username"]);
            //    password = HttpUtility.UrlDecode(parser.Parameters["password"]);
            //}

            //Console.Write("hola");
            //throw new NotImplementedException();
        }

        */
        
    }
}
