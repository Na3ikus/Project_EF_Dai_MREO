using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Factories")]
    public class Factory
    {
        [Key]
        [Column("factory_id")]
        public long FactoryId { get; set; }

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
        [Column("factory_name")]
        public string FactoryName { get; set; }

        [ForeignKey("TypeAdressId")]
        public virtual TypeAdress TypeAdress { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }

        public virtual ICollection<ModelFactory> ModelFactories { get; set; }
    }
}