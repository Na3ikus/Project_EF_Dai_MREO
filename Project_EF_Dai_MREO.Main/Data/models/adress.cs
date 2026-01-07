using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("adress")]
    public class Adress
    {
        [Key]
        [Column("adress_id")]
        public long AdressId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("adress_name")]
        public string AdressName { get; set; }

        [Required]
        [Column("city_id")]
        public long CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual ICollection<PersonAdress> PersonAdresses { get; set; }

        public virtual ICollection<MreoLocation> MreoLocations { get; set; }

        public virtual ICollection<Factory> Factories { get; set; }

        public virtual ICollection<Accident> Accidents { get; set; }
    }
}