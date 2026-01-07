using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("country_id")]
        public long CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("country_name")]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("citizenship")]
        public string Citizenship { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}