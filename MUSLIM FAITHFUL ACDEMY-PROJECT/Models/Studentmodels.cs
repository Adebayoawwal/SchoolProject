using System.Net;

namespace MUSLIM_FAITHFUL_ACDEMY_PROJECT.Models
{
    public class Studentmodels
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FamilyName { get; set; }
        public string SchoolName { get; set; }
    }
}
