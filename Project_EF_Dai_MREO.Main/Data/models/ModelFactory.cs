using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Model_Factory")]
    public class ModelFactory
    {
        [Key]
        [Column("model_factory_id")]
        public long ModelFactoryId { get; set; }

        [Required]
        [Column("model_id")]
        public long ModelId { get; set; }

        [Required]
        [Column("factory_id")]
        public long FactoryId { get; set; }

        [Required]
        [Column("production_start_date")]
        public DateTime ProductionStartDate { get; set; }

        [Column("production_end_date")]
        public DateTime? ProductionEndDate { get; set; }

        [ForeignKey("ModelId")]
        public virtual CarModel Model { get; set; }

        [ForeignKey("FactoryId")]
        public virtual Factory Factory { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}