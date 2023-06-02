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
		public async Task<IActionResult> GetByStatus(int status)
		{
			var listUser = await _userServices.GetAll(status);
			// BadRequest, NotFound,...

			return Ok(listUser);
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
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
		public async Task<IActionResult> Post([FromBody] User user)
		{
			if (!await _userServices.Create(user))
			{
				return BadRequest();
			}

			return Ok();
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] User user)
		{
			if (!await _userServices.Update(user))
			{
				return BadRequest();
			}

			return Ok();
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (!await _userServices.Delete(id))
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
