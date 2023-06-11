using Microsoft.AspNetCore.Mvc;
using TUTOR_NET105_SU23.B2.BUS.Services.Implements;
using TUTOR_NET105_SU23.B2.BUS.Services.Interfaces;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController()
        {
            _userServices = new UserServices();
        }

        [HttpGet("[action]/{status}")]
        public async Task<IActionResult> GetAll(int status)
        {
            var listUser = await _userServices.GetAll(status);
            // BadRequest, NotFound,...

            return Ok(listUser);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userServices.GetById(id);
            // BadRequest, NotFound,...
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var result = await _userServices.Create(user);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] User user)
        {
            var result = await _userServices.Update(user);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userServices.Delete(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
