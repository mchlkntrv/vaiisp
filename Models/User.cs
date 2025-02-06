using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Column("password_hash")]
        public string Password { get; set; }

        public string Salt { get; set; }

        public string Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Collection> Collections { get; set; }
    }
}
