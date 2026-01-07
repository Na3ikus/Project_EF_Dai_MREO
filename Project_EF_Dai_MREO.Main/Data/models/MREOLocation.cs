using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("MREO_Locations")]
    public class MreoLocation
    {
        [Key]
        [Column("mreo_location_id")]
        public long MreoLocationId { get; set; }

        [Required]
        [Column("type_adress_id")]
        public long TypeAdressId { get; set; }

        [Required]
        [Column("adress_id")]
        public long AdressId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("building")]
        public string Building { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("mreo_name")]
        public string MreoName { get; set; }

        [ForeignKey("TypeAdressId")]
        public virtual TypeAdress TypeAdress { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}