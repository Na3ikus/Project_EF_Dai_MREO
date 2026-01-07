using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("employee_contact")]
    public class EmployeeContact
    {
        [Key]
        [Column("employee_contact_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong EmployeeContactId { get; set; }

        [Required]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [Column("contact_type_id")]
        public ulong ContactTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("contact")]
        public string Contact { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [ForeignKey("ContactTypeId")]
        public virtual ContactType ContactType { get; set; }
    }
}