using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Employee_Documents")]
    public class EmployeeDocument
    {
        [Key]
        [Column("employee_document_id")]
        public long EmployeeDocumentId { get; set; }

        [Required]
        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Required]
        [Column("document_type_id")]
        public ulong DocumentTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("document_number")]
        public string DocumentNumber { get; set; }

        [Required]
        [Column("issue_date")]
        public DateTime IssueDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("issued_by")]
        public string IssuedBy { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }
    }
}