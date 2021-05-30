using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EncuestaEP.Models;

namespace EncuestaEP.Models
{
    public class CamposViewModel
    {

        public int id_encuesta { get; set; }

        public List<Campos> lst_campos { get; set; }



    }
}