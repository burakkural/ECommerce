using ECommerce.Bussines.Abstract;
using ECommerce.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
           var result = await _userService.GetListAsync();
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] UserAddDto user)
        {
            var result = await _userService.AddAsync(user);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto user)
        {
            var result = await _userService.UpdateAsync(user);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result == false)
                return BadRequest(false);
            return Ok(result);
        }
    }
}
