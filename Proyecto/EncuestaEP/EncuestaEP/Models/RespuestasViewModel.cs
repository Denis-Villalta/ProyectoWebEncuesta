using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncuestaEP.Models
{
    public class RespuestasViewModel
    {

        public int id_encuesta { get; set; }

        public List<Respuesta_Encabezado> lst_encabezado { get; set; }
    }
}