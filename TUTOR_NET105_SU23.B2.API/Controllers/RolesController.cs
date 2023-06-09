using Microsoft.AspNetCore.Mvc;
using TUTOR_NET105_SU23.B2.BUS.Services.Implements;
using TUTOR_NET105_SU23.B2.BUS.Services.Interfaces;
using TUTOR_NET105_SU23.B2.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TUTOR_NET105_SU23.B2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleServices _roleServices;

        public RolesController()
        {
            _roleServices = new RoleServices();
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IActionResult> GetAll(int status)
        {
            var listRole = await _roleServices.GetAll(status);

            return Ok(listRole);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await _roleServices.GetById(id);

            return Ok(role);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            var result = await _roleServices.Create(role);

            return Ok(result);
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Role role)
        {
            // check ton tai
            if (await _roleServices.GetById(role.Id) == null)
            {
                return NotFound();
            }

            var result = await _roleServices.Update(role);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _roleServices.Delete(id);

            return Ok(result);
        }
    }
}
