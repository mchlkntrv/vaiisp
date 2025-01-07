using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
