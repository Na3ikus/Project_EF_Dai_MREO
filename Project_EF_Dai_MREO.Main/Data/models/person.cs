using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaiMreo_models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        [Column("person_id")]
        public long PersonId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<PersonAdress> PersonAdresses { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

        public virtual ICollection<CarOwnersAction> CarOwnersActions { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<EmployeeContact> EmployeeContacts { get; set; }

        public virtual ICollection<Accident> Accidents { get; set; }
    }
}
