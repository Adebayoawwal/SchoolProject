using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUSLIM_FAITHFUL_ACDEMY_PROJECT.DataForStudent;
using MUSLIM_FAITHFUL_ACDEMY_PROJECT.Models;

namespace MUSLIM_FAITHFUL_ACDEMY_PROJECT.Controllers
{
    public class TeacherModelController : Controller
	{
		private readonly StudentDataToDatabase mvcDemoDbContext;

		public TeacherModelController(StudentDataToDatabase mvcDemoDbContext)
		{
			this.mvcDemoDbContext = mvcDemoDbContext;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var teacher = await mvcDemoDbContext.Teachermodel.ToListAsync();
			return View(teacher);
		}
		public IActionResult Add()
		{ 
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(TeacherModel TeacherTools)
		{
			var teacher = new TeacherModel
            {
				Id = Guid.NewGuid(),
				TeacherName = TeacherTools.TeacherName,
				TeacherPassword = TeacherTools.TeacherPassword,
				Email = TeacherTools.Email,
				ClassType = TeacherTools.ClassType
			};
		  await mvcDemoDbContext.Teachermodel.AddAsync(teacher);
			await mvcDemoDbContext.SaveChangesAsync();
			return Redirect("Index");
		}
		public async Task<IActionResult> Edit(Guid id)
		{
			var teacher = await mvcDemoDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

			if (teacher != null)
			{
				var viewModel = new TeacherModel()
				{
					Id = teacher.Id,
					TeacherName= teacher.Name,
					TeacherPassword = teacher.Password,
					Email = teacher.Email,
				};
				return await Task.Run(() => View("Edit", viewModel));
			}
			return RedirectToAction("Index");
		}
	}
}
