using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("document_type")]
    public class DocumentType
    {
        [Key]
        [Column("document_type_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong DocumentTypeId { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("document_type")]
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
    }
}