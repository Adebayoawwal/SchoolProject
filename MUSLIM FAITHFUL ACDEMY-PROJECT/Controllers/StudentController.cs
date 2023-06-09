using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUSLIM_FAITHFUL_ACDEMY_PROJECT.DataForStudent;
using MUSLIM_FAITHFUL_ACDEMY_PROJECT.Models;

namespace MUSLIM_FAITHFUL_ACDEMY_PROJECT.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataToDatabase mvcDemoDbContext;

        public StudentController(StudentDataToDatabase mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await mvcDemoDbContext.Students.ToListAsync();
            return View(students);
        }
        public IActionResult StudentView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StudentView(Studentmodels addStudentsRequest)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = addStudentsRequest.Name,
                Email = addStudentsRequest.Email,
				Password = addStudentsRequest.Password,
                FamilyName = addStudentsRequest.FamilyName,
                DateOfBirth = addStudentsRequest.DateOfBirth,
                SchoolName = addStudentsRequest.SchoolName
            };
            await mvcDemoDbContext.Students.AddAsync(student);
            await mvcDemoDbContext.SaveChangesAsync();
            return Redirect("Index");
        }

        [HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var employee = await mvcDemoDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

			if (employee != null)
			{
				var viewModel = new Studentmodels()
				{
				    id = employee.Id,
					Name = employee.Name,
					Email = employee.Email,
					Password = employee.Password,
					SchoolName = employee.SchoolName,
					FamilyName = employee.FamilyName,
					DateOfBirth = employee.DateOfBirth
				};
				return await Task.Run(() => View("save", viewModel));
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Studentmodels model)
		{
			var employee = await mvcDemoDbContext.Students.FindAsync(model.id);
			if (employee != null)
			{
				mvcDemoDbContext.Students.Remove(employee);
				await mvcDemoDbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
