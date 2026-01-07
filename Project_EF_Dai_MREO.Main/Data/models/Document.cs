using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        [Column("person_document_id")]
        public long PersonDocumentId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [Column("document_type_id")]
        public ulong DocumentTypeId { get; set; }

        [MaxLength(10)]
        [Column("document_series")]
        public string? DocumentSeries { get; set; }

        [Required]
        [Column("document_number")]
        public ulong DocumentNumber { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("issued")]
        public string Issued { get; set; }

        [Required]
        [Column("date_issued")]
        public DateTime DateIssued { get; set; }

        [Column("date_expiried")]
        public DateTime? DateExpiried { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<DriverLicense> DriverLicenses { get; set; }
    }
}