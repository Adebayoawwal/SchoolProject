using Microsoft.EntityFrameworkCore;
using MUSLIM_FAITHFUL_ACDEMY_PROJECT.Models;

namespace MUSLIM_FAITHFUL_ACDEMY_PROJECT.DataForStudent
{
    public class StudentDataToDatabase : DbContext
    {
        public StudentDataToDatabase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherModel> Teachermodel { get; set; }
    }
}
