//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestaEP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Campos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campos()
        {
            this.Respuesta_Detalle = new HashSet<Respuesta_Detalle>();
        }
    
        public int id { get; set; }
        public int id_encuesta { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public bool requerido { get; set; }
        public byte tipo { get; set; }
    
        public virtual Encuesta Encuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuesta_Detalle> Respuesta_Detalle { get; set; }
    }
}
