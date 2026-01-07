using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("type_adreses")]
    public class TypeAdress
    {
        [Key]
        [Column("type_adress_id")]
        public long TypeAdressId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("type_adres_name")]
        public string TypeAdresName { get; set; }

        public virtual ICollection<PersonAdress> PersonAdresses { get; set; } = new HashSet<PersonAdress>();

        public virtual ICollection<MreoLocation> MreoLocations { get; set; } = new HashSet<MreoLocation>();

        public virtual ICollection<Factory> Factories { get; set; } = new HashSet<Factory>();
    }
}