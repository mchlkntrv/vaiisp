using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Mineral
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Názov je povinnı.")]
        [StringLength(50, ErrorMessage = "Názov môe ma maximálne 50 znakov.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Chemickı vzorec je povinnı.")]
        [StringLength(50, ErrorMessage = "Chemickı vzorec môe ma maximálne 50 znakov.")]

        public string Formula { get; set; }

        [Required(ErrorMessage = "Informácie sú povinné.")]
        [StringLength(4000, ErrorMessage = "Informácie môu ma maximálne 4000 znakov.")]
        public string Information { get; set; }
    }
}
