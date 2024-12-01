using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Collection
    {
        public int Id { get; set; }
        [Column("owner_id")]
        public int OwnerId { get; set; }
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
