using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        [Column("car_id")]
        public long CarId { get; set; }

        [Required]
        [Column("model_factory_id")]
        public long ModelFactoryId { get; set; }

        [Required]
        [Column("vehicle_type_id")]
        public long VehicleTypeId { get; set; }

        [Required]
        [Column("color_id")]
        public long ColorId { get; set; }

        [Required]
        [Column("production_date")]
        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("transmission_type")]
        public string TransmissionType { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("fuel_type")]
        public string FuelType { get; set; }

        [MaxLength(20)]
        [Column("second_fuel_type")]
        public string? SecondFuelType { get; set; }

        [MaxLength(17)]
        [Column("vin_number")]
        public string? VinNumber { get; set; }

        [MaxLength(50)]
        [Column("engine_serial_number")]
        public string? EngineSerialNumber { get; set; }

        [ForeignKey("ModelFactoryId")]
        public virtual ModelFactory ModelFactory { get; set; }

        [ForeignKey("VehicleTypeId")]
        public virtual VehicleType VehicleType { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        public virtual ICollection<CarOwnersAction> CarOwnersActions { get; set; }

        public virtual ICollection<Accident> Accidents { get; set; }
    }
}