using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Driver_Licenses")]
    public class DriverLicense
    {
        [Key]
        [Column("license_id")]
        public long LicenseId { get; set; }

        [Required]
        [Column("person_document_id")]
        public long PersonDocumentId { get; set; }

        [Required]
        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("license_number")]
        public string LicenseNumber { get; set; }

        [Required]
        [Column("license_issue_date")]
        public DateTime LicenseIssueDate { get; set; }

        [Column("license_expiry_date")]
        public DateTime? LicenseExpiryDate { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("license_category")]
        public string LicenseCategory { get; set; }

        [Column("penalty_points")]
        [Range(0, 13)]
        public int PenaltyPoints { get; set; } = 0;

        [ForeignKey("PersonDocumentId")]
        public virtual Document Document { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}