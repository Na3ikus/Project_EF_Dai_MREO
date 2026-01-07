using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        [Column("login_id")]
        public long LoginId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("login")]
        public string LoginName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}