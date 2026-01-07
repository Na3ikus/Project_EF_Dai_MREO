using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Car_Owners_actions")]
    public class CarOwnersAction
    {
        [Key]
        [Column("car_owner_id")]
        public long CarOwnerId { get; set; }

        [Required]
        [Column("car_id")]
        public long CarId { get; set; }

        [Required]
        [Column("action_type_id")]
        public long ActionTypeId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [Column("ownership_start_date")]
        public DateTime OwnershipStartDate { get; set; }

        [Column("ownership_end_date")]
        public DateTime? OwnershipEndDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("registration_number")]
        public string RegistrationNumber { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("ActionTypeId")]
        public virtual ActionType ActionType { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}