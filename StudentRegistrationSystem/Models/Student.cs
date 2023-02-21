using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationSystem.Models {
    public class Student {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ParentName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
