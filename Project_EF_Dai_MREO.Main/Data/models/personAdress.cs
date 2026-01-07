using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("person_adress")]
    public class PersonAdress
    {
        [Key]
        [Column("person_adress_id")]
        public long PersonAdressId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

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

        [MaxLength(20)]
        [Column("room")]
        public string? Room { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("TypeAdressId")]
        public virtual TypeAdress TypeAdress { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }
    }
}