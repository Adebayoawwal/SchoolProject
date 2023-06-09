using System.ComponentModel;

namespace MUSLIM_FAITHFUL_ACDEMY_PROJECT.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Family Name")]
        public string FamilyName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string SchoolName { get; internal set; }

    }
}