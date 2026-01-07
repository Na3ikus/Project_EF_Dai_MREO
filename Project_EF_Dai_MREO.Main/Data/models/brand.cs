using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        [Column("brand_id")]
        public long BrandId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("brand_name")]
        public string BrandName { get; set; }

        public virtual ICollection<CarModel> Models { get; set; }
    }
}