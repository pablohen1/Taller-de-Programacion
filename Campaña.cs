using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carteleria_Digital
{
   public class Campaña
    {
        [Key]     
        public Nullable<int> campañaID { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }

        public virtual ICollection<Imagen> imagens { get; set; }
    }
}
