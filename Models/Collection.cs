namespace MyMineral.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User Owner { get; set; }
    }
}
