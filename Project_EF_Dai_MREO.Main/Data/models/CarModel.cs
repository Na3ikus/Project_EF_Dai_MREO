using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Models")]
    public class CarModel
    {
        [Key]
        [Column("model_id")]
        public long ModelId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("model_name")]
        public string ModelName { get; set; }

        [Required]
        [Column("brand_id")]
        public long BrandId { get; set; }

        [Required]
        [Column("release_year")]
        public DateTime ReleaseYear { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ModelFactory> ModelFactories { get; set; }
    }
}