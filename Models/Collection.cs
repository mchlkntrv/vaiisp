using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Collection
    {
        public int Id { get; set; }
        [Column("owner_id")]
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User Owner { get; set; }
    }
}
