using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Required]
        [Column("mreo_location_id")]
        public long MreoLocationId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("termination_date")]
        public DateTime? TerminationDate { get; set; }

        [Required]
        [Column("position_id")]
        public long PositionId { get; set; }

        [Required]
        [Column("salary_per_month", TypeName = "decimal(8,2)")]
        public decimal SalaryPerMonth { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        [ForeignKey("MreoLocationId")]
        public virtual MreoLocation MreoLocation { get; set; }

        public virtual ICollection<DriverLicense> DriverLicenses { get; set; }

        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
    }
}