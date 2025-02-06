using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }  

        [Required]
        [Column("mineral_id")]
        public int MineralId { get; set; }  

        [Required]
        [StringLength(1000, ErrorMessage = "Text komentára nemôže byť dlhší ako 1000 znakov.")]
        public string Text { get; set; }  

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Mineral? Mineral { get; set; }
    }
}
