using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFacil.Models
{
    [Table("USERS")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("USERNAME")]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("PASSWORD")]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
