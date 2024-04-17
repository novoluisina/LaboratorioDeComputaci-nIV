using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo_item.Entities;
using todo_item.Models;
using todo_item.Services.Interfaces;

namespace todo_item.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }

        [HttpGet("GetUserById{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

                if (user == null)
                {
                    return NotFound($"El usuario de ID: {id} no fue encontrado");
                }

                return Ok(user);
           
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);
                if (existingUser == null)
                {
                    return NotFound($"No se encontró ningún usuario con el ID: {id}");
                }
                _userService.DeleteUser(id);
                return Ok($"Usuario con ID: {id} eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserPostDto dto)
        {

                if (dto.Name == "string" || dto.Email == "string" || dto.Address=="string")
                {
                    return BadRequest("Usuario no creado, por favor completar los campos");
                }
                try
                {
                    var user = new User()
                    {
                        Email = dto.Email,
                        Name = dto.Name,
                        Address = dto.Address,
                        UserType = "User"
                    };
                    int id = _userService.CreateUser(user);
                    return Ok($"Usuario creado exitosamente con id: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            
   
        }
    }
}
