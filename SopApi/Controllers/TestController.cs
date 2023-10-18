using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopApi.Repositories;

namespace SopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepo;

        public TestController(ITestRepository repo)
        {
            _testRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTest()
        {
            try
            {
                return Ok(await _testRepo.GetAllTestAsync());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTestById(int id)
        {
            var test = await  _testRepo.GetTestAsync(id);
            return test == null ? NotFound(id) : Ok(test);
        }
    }
}
