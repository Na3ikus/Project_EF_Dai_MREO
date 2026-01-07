using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Positions")]
    public class Position
    {
        [Key]
        [Column("position_id")]
        public long PositionId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("position_name")]
        public string PositionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}