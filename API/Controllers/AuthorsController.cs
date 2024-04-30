using Microsoft.AspNetCore.Mvc;
using ELearn.Core;

namespace ELearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return Ok(authors);
        }
    }
}