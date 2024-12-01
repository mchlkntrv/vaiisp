namespace MyMineral.Models
{
    public class CollectionItem
    {
        public int CollectionId { get; set; }
        public int MineralId { get; set; }   

        public Collection Collection { get; set; }
        public Mineral Mineral { get; set; }      
    }
}
