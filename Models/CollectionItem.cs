using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class CollectionItem
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("collection_id")]
        public int CollectionId { get; set; }
        [Column("mineral_id")]
        public int MineralId { get; set; }
        [Column("added_at")]
        public DateTime AddedAt { get; set; } = DateTime.Now;
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("user_description")]
        public String? UserDescription { get; set; }

        public Mineral? Mineral { get; set; }
        public Collection? Collection { get; set; }

    }
}
