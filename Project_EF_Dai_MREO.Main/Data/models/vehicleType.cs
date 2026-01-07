using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Vehicle_Types")]
    public class VehicleType
    {
        [Key]
        [Column("vehicle_type_id")]
        public long VehicleTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("type_name")]
        public string TypeName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}