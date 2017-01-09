using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Carteleria_Digital
{
   public class Banner
     
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bannerID { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }
        public ContenidoBanner unafuente { get; set; }

    }
}
