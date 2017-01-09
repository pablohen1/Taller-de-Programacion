using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carteleria_Digital
{
   public class Imagen
    {
        [Key]
        public int imagenID { get; set; }
        public string ubicacionImagen { get; set; }
        public int duracion { get; set; }

    }
}
