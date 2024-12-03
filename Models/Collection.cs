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

        [Required(ErrorMessage = "Vyplòte názov kolekcie.")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public User? Owner { get; set; }
    }
}
