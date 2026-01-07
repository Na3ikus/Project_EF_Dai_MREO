using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Action_Types")]
    public class ActionType
    {
        [Key]
        [Column("action_type_id")]
        public long ActionTypeId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("action_type_name")]
        public string ActionTypeName { get; set; }

        public virtual ICollection<CarOwnersAction> CarOwnersActions { get; set; }
    }
}