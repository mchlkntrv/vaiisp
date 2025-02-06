using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Collection
    {
        public int Id { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "VyplÚte n·zov kolekcie.")]
        [StringLength(50, ErrorMessage = "N·zov kolekcie mÙûe maù najviac 50 znakov.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Popis kolekcie mÙûe maù najviac 1000 znakov.")]
        public string? Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public User? Owner { get; set; }

        [JsonIgnore]
        public List<CollectionItem>? CollectionItems { get; set; }
    }
}
