using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Colors")]
    public class Color
    {
        [Key]
        [Column("color_id")]
        public long ColorId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("color_name")]
        public string ColorName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}