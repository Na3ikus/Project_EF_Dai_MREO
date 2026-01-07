using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("city")]
    public class City
    {
        [Key]
        [Column("city_id")]
        public long CityId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("city_name")]
        public string CityName { get; set; }

        [Required]
        [Column("region_id")]
        public long RegionId { get; set; }

        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }

        public virtual ICollection<Adress> Adresses { get; set; }
    }
}