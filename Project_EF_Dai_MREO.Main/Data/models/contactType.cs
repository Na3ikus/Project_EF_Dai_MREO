using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("contact_type")]
    public class ContactType
    {
        [Key]
        [Column("contact_type_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong ContactTypeId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("contact_type")]
        public string ContactTypeName { get; set; }

        public virtual ICollection<EmployeeContact> EmployeeContacts { get; set; }
    }
}