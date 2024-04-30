using ELearn.Core;
using Microsoft.AspNetCore.Mvc;
using ELearn.Core.Repositories;

namespace ELearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return Ok(courses);
        }
    }
}