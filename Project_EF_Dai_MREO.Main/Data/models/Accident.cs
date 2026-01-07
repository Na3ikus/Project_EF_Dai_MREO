using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Accidents")]
    public class Accident
    {
        [Key]
        [Column("accident_id")]
        public long AccidentId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [Column("car_id")]
        public long CarId { get; set; }

        [Required]
        [Column("address_type_id")]
        public long AddressTypeId { get; set; }

        [Required]
        [Column("adress_id")]
        public long AdressId { get; set; }

        [Required]
        [Column("accident_date")]
        public DateTime AccidentDate { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("accident_type")]
        public string AccidentType { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }
    }
}