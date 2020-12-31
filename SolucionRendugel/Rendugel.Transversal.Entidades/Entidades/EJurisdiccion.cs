using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Transversal.Entidades
{
    public class EJurisdiccion
    {
        public int IdJurisdiccion { get; set; }
        public EUbigeo_ Ubigeo { get; set; }
        public string terminoPertenencia { get; set; } //COMPRENDE, EXCLUYE, INCLUYE
        public string enCCPP { get; set; } //SI EL TERMINO ES "COMPRENDE" Y EL TIPO DE UBIGEO ES CCPP 
                                           //=> VA [NOMBRE - CCPP] en campo "enCCP"
                                           //      [NOMBRE - DISTRITO] en campo "enDistrito"
                                           //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                           //      [NOMBRE - REGION] en campo "enRegión"
                                           //SI EL TERMINO ES "INCLUYE O EXCLUYE" Y EL TIPO ES CCPP
                                           //=> VA [NOMBRE - CCPP] en campo "enCCP"
                                           //      [NOMBRE - DISTRITO] en campo "enDistrito"
                                           //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                           //      [NOMBRE - REGION] en campo "enRegión"
                                           //
                                           //ENUNCIADO [TERMINO] + (espacio) + (el) + ubigeo.TipoUbigeo.Descrición 
                                           //           + (espacio) + [NOMBRE - CCPP] + (espacio) + (del distrito)
                                           //           + (espacio) + [NOMBRE - DISTRITO] + (espacio) + (de la provincia) 
                                           //           + (espacio) + [NOMBRE - PROVINCIA] + (espacio) + (del departamento)
                                           //           + (espacio) + [NOMBRE - REGION]

        public string enDistrito { get; set; }//SI EL TERMINO ES "COMPRENDE" Y EL TIPO DE UBIGEO ES DISTRITO 
                                              //=> VA "TODOS" EN EL CAMPO "enCCPP" y 
                                              //      [NOMBRE - DISTRITO] en campo "enDistrito"
                                              //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                              //      [NOMBRE - REGION] en campo "enRegión"
                                              //
                                              //ENUNCIADO [TERMINO] + (espacio) + [enCCPP] + (los centros poblados del distrito de) +                                              
                                              //           + (espacio) + [NOMBRE - DISTRITO] + (espacio) + (de la provincia) 
                                              //           + (espacio) + [NOMBRE - PROVINCIA] + (espacio) + (del departamento)
                                              //           + (espacio) + [NOMBRE - REGION]

                                                //SI EL TERMINO ES "INCLUYE O EXCLUYE" Y EL TIPO ES DISTRITO
                                                //      [NOMBRE - DISTRITO] en campo "enDistrito"
                                                //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                                //      [NOMBRE - REGION] en campo "enRegión"
                                                //
                                                //ENUNCIADO [TERMINO] + (espacio) + (el)+ ubigeo.TipoUbigeo.Descrición                                              
                                                //           + (espacio) + [NOMBRE - DISTRITO] + (espacio) + (de la provincia) 
                                                //           + (espacio) + [NOMBRE - PROVINCIA] + (espacio) + (del departamento)
                                                //           + (espacio) + [NOMBRE - REGION]

        public string enProvincia {get; set; } //SI EL TERMINO ES "COMPRENDE" Y EL TIPO DE UBIGEO ES PROVINCIA 
                                               //=> VA "TODOS" EN EL CAMPO "enDistritos" y 
                                               //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                               //      [NOMBRE - REGION] en campo "enRegión"
                                               //
                                               //ENUNCIADO [TERMINO] + (espacio) + [enDistrito] + (los distritos de la provincia de) +                                            
                                               //           + (espacio) + [NOMBRE - PROVINCIA] + (espacio) + (del departamento)
                                               //           + (espacio) + [NOMBRE - REGION]

                                               //SI EL TERMINO ES "INCLUYE O EXCLUYE" Y EL TIPO ES PROVINCIA
                                               //      [NOMBRE - PROVINCIA] en campo "enProvincia"
                                               //      [NOMBRE - REGION] en campo "enRegión"
                                               //
                                               //ENUNCIADO [TERMINO] + (espacio) + (la) + ubigeo.TipoUbigeo.Descrición
                                                //           + (espacio) + [NOMBRE - PROVINCIA] + (espacio) + (del departamento)
                                                //           + (espacio) + [NOMBRE - REGION]
        public string enRegion { get; set; }  //SI EL TERMINO ES "COMPRENDE" Y EL TIPO DE UBIGEO ES REGION 
                                              //=> VA "TODOS" EN EL CAMPO "enProvincia" y 
                                              //      [NOMBRE - REGION] en campo "enRegión"
                                              //
                                              //ENUNCIADO [TERMINO] + (espacio) + [enProvincia] + (las provincias del departamento de) +                                          
                                              //           + (espacio) + [NOMBRE - REGION]

                                              //SI EL TERMINO ES "INCLUYE O EXCLUYE" Y EL TIPO ES PROVINCIA
                                              //      [NOMBRE - REGION] en campo "enRegión"
                                              //
                                              //ENUNCIADO [TERMINO] + (espacio) + (el) ubigeo.TipoUbigeo.Descrición                                     
                                              //           + (espacio) + [NOMBRE - REGION]
        public string enunciado { get; set; }
        public int CodTerminoCantidad { get; set; } // 2: TODOS
        public int CodTerminoPertenencia { get; set; } // 1: COMPRENDE, 2: INCLUYE, 3: EXCLUYE
        public ETerminoCantidadJurisdiccion TerminoCantidadJurisdiccion { get; set; }
        public ETerminoPertenenciaJurisdiccion TerminoPertenenciaJurisdiccion { get; set; }
        public int? nivel { get; set; } // nivel: Provincia, distrito, centro poblado
    }
}
