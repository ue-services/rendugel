using Rendugel.Aplicacion.Interfaces;
using Rendugel.Transversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Web;
using System.Reflection;
using System.IO;

namespace Rendugel.Aplicacion.Registro
{
    public class Complementarias : IComplementarias
    {
        public EJurisdiccion GenerarEnunciadoJurisdiccion(EJurisdiccion eJurisdiccion)
        {
            //Para enunciado:
            string espacio = " ";
            string articulo1 = "el";
            string articulo2 = "la";
            string predicadoDistrito = "del distrito";
            string predicadoProvincia = "de la provincia";
            string predicadoRegión = "del departamento";
            string sujetoCcpp = "los centors poblados del distrito";
            string sujetoDistrito = "los distritos de la provincia";
            string sujetosProvincia = "las provincias del departamento";


                switch (eJurisdiccion.CodTerminoPertenencia)
                {
                    case 1: //COMPRENDE
                        switch (eJurisdiccion.Ubigeo.TipoUbigeo.CodTipoUbigeo)
                        {
                            case 4: //ccpp
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enCCPP = eJurisdiccion.Ubigeo.Nombre;
                                    eJurisdiccion.enDistrito = eJurisdiccion.Ubigeo.NomDistrito;
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              articulo1 + espacio + eJurisdiccion.Ubigeo.TipoUbigeo.DescTipoUbigeo +
                                                              espacio + eJurisdiccion.enCCPP + espacio + predicadoDistrito +
                                                              espacio + eJurisdiccion.enDistrito + espacio + predicadoProvincia +
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                                break;
                            case 3: //distrito   
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enCCPP = eJurisdiccion.TerminoCantidadJurisdiccion.DescTerminoCantidad; //todos
                                    eJurisdiccion.enDistrito = eJurisdiccion.Ubigeo.NomDistrito;
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio + 
                                                              eJurisdiccion.enCCPP + espacio + sujetoCcpp +  
                                                              espacio + eJurisdiccion.enDistrito + espacio + predicadoProvincia +
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                            case 2: //provincia
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enDistrito = eJurisdiccion.TerminoCantidadJurisdiccion.DescTerminoCantidad; //todos
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              eJurisdiccion.enDistrito + espacio + sujetoDistrito+                                                              
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                            case 1: // departamento (región)
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enProvincia = eJurisdiccion.TerminoCantidadJurisdiccion.DescTerminoCantidad; //todos
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              eJurisdiccion.enProvincia + espacio + sujetosProvincia +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                        }
                        break;
                    case 2: // INCLUYE
                    case 3: // EXCLUYE
                        switch (eJurisdiccion.Ubigeo.TipoUbigeo.CodTipoUbigeo)
                        {
                            case 4: //ccpp
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enCCPP = eJurisdiccion.Ubigeo.Nombre;
                                    eJurisdiccion.enDistrito = eJurisdiccion.Ubigeo.NomDistrito;
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              articulo1 + espacio + eJurisdiccion.Ubigeo.TipoUbigeo.DescTipoUbigeo +
                                                              espacio + eJurisdiccion.enCCPP + espacio + predicadoDistrito +
                                                              espacio + eJurisdiccion.enDistrito + espacio + predicadoProvincia +
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                            case 3: //distrito
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enDistrito = eJurisdiccion.Ubigeo.NomDistrito;
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio + 
                                                              articulo1 + espacio + eJurisdiccion.Ubigeo.TipoUbigeo.DescTipoUbigeo +
                                                              espacio + eJurisdiccion.enDistrito + espacio + predicadoProvincia +
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                            case 2: //provincia
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enProvincia = eJurisdiccion.Ubigeo.NomProvincia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              articulo2 + espacio + eJurisdiccion.Ubigeo.TipoUbigeo.DescTipoUbigeo +
                                                              espacio + eJurisdiccion.enProvincia + espacio + predicadoRegión +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                            case 1: // departamento (región)
                                    eJurisdiccion.terminoPertenencia = eJurisdiccion.TerminoPertenenciaJurisdiccion.DescTerminoPertenencia;
                                    eJurisdiccion.enRegion = eJurisdiccion.Ubigeo.NomRegion;
                                    eJurisdiccion.enunciado = eJurisdiccion.terminoPertenencia + espacio +
                                                              articulo1 + espacio + eJurisdiccion.Ubigeo.TipoUbigeo.DescTipoUbigeo +
                                                              espacio + eJurisdiccion.enRegion;
                            break;
                        }
                        break;
                    default:
                        break;
                }

                return eJurisdiccion;            
        }

        public ValidacionResponse validarExtension(string fileName, string extension)
        {
            ValidacionResponse respuesta = new ValidacionResponse();
            string _extension = Path.GetExtension(fileName);
            if (_extension == extension){ return new ValidacionResponse { result = true, message = "OK"};
            }
            return new ValidacionResponse { result = false, message = "Solo puede adjuntar archivos de extención " + extension };
        }

        public ValidacionResponse validarFidelidad(Stream dataResult)
        {
            long FileLen = dataResult.Length;
            byte[] input = new byte[FileLen];

            //Obteniendo el archivo en Base64String
            using (var memoryStream = new MemoryStream())
            {
                dataResult.CopyTo(memoryStream);
                input = memoryStream.ToArray();
            }
            /******************************Begin Valid PDF CORRUPTED************************************/
            if (input[0] != 0x25 || input[1] != 0x50 || input[2] != 0x44 || input[3] != 0x46)
            {
                return new ValidacionResponse { result = false, message = "El archivo que intenta cargar está corrupto" };
            }
            return new ValidacionResponse { result = true, message = "OK" };
        }

        public ValidacionResponse validarTamanio(Stream dataResult, long maximo) // en megas
        {
            ValidacionResponse respuesta = new ValidacionResponse();
            long fileLen = dataResult.Length;
            if (fileLen <= (maximo * 1048576)) 
            {
                return new ValidacionResponse { result = true, message = "OK" };
            }
            return new ValidacionResponse { result = false, message = "EL archivo a adjuntar debe ser menor a " + maximo + "MB" };
        }

    }
}

//Assembly localisationAssembly = Assembly.Load("Rendugel.Comun.Recursos.dll");
//ResourceManager rm = new ResourceManager("Rendugel.Comun.Recursos.App_LocalResources.mensajes",           //                   localisationAssembly);    //ResourceManager rm2 = new ResourceManager("Rendugel.Comun.Recursos.App_LocalResources.mensajes", typeof(Complementarias).Assembly);
//ResourceManager rm = new ResourceManager("Rendugel.Servicios.Host.g",
//                     Assembly.GetExecutingAssembly());
//string myvalue1 =rm.GetString("msnvalidpdfext");
//string myValue = HttpContext.GetGlobalResourceObject("mensajes", "msnvalidpdf").ToString(); 
