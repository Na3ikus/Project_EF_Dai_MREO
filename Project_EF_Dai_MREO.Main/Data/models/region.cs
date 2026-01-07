using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("regions")]
    public class Region
    {
        [Key]
        [Column("region_id")]
        public long RegionId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("region_name")]
        public string RegionName { get; set; }

        [Required]
        [Column("country_id")]
        public long CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}