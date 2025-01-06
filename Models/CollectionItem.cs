using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CollectionItem
    {
        [Column("collection_id")]
        public int CollectionId { get; set; }
        [Column("mineral_id")]
        public int MineralId { get; set; }
    }
}
