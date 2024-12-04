using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Mineral
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "N�zov je povinn�.")]
        [StringLength(50, ErrorMessage = "N�zov m��e ma� maxim�lne 50 znakov.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Chemick� vzorec je povinn�.")]
        [StringLength(50, ErrorMessage = "Chemick� vzorec m��e ma� maxim�lne 50 znakov.")]

        public string Formula { get; set; }

        [Required(ErrorMessage = "Inform�cie s� povinn�.")]
        [StringLength(4000, ErrorMessage = "Inform�cie m��u ma� maxim�lne 4000 znakov.")]
        public string Information { get; set; }
    }
}
