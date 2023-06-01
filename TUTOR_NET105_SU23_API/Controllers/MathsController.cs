using Microsoft.AspNetCore.Mvc;

namespace Tutor_Net105_B1_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathsController : ControllerBase
    {
        [HttpGet("average")]
        public IActionResult Average(int num1, int num2, int num3)
        {
            float avg = (float)(num1 + num2 + num3) / 3; // int / int = int ; float / int = float;
            return Ok(avg);
        }
    }
}
