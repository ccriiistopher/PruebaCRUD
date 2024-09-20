using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaCRUD.Dto;
using PruebaCRUD.Interfaces;
using PruebaCRUD.Models;

namespace PruebaCRUD.Controllers
{
    [ApiController]
    [Route("UserApi")]
    public class UserApiController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserApiController(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult CreateUser([FromForm] string Dni, [FromForm] string Nombre, [FromForm] string Apellido)
        {
            var userDto = new PostUserDto()
            {
                Dni = Dni,
                Nombre = Nombre,
                Apellido = Apellido
            };

            if (userDto == null) return BadRequest(ModelState);
            if (_userRepository.UserExists(userDto.Dni))
            {
                ModelState.AddModelError("", "El usuario ya existe.");
                ViewData.Add("label", "Usuario ya existe");
                ViewData.Add("message", "El usuario ya fue registrado anteriormente.");
                return View("Error");
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _mapper.Map<User>(userDto);
            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Ocurrió un error.");
                return StatusCode(500, ModelState);
            }
            ViewData.Add("title", "Usuario registrado");
            ViewData.Add("label", "Usuario registrado");
            ViewData.Add("message", "El usuario fue registrado con éxito.");
            return View("Result");
        }

        [HttpPost("UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromForm] int Id, [FromForm] string Dni, [FromForm] string Nombre, [FromForm] string Apellido, [FromQuery] int userId)
        {
            var userDto = new PutUserDto()
            {
                Id = Id,
                Nombre=Nombre,
                Apellido=Apellido,
                Dni=Dni
            };
            if (userDto == null) return BadRequest(ModelState);
            if(userDto.Id != userId)
            {
                ModelState.AddModelError("", "Los datos no coinciden.");
                return BadRequest(ModelState);
            }
            if (!_userRepository.UserExistsById(userId))
            {
                ModelState.AddModelError("", "El usuario no existe.");
                ViewData.Add("label", "Usuario no existe");
                ViewData.Add("message", "El usuario no existe.");
                return View("Error");
            }
            var user = _mapper.Map<User>(userDto);
            if (!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Ocurrió un error.");
                return StatusCode(500, ModelState);
            }
            ViewData.Add("title", "Información Actualizada");
            ViewData.Add("label", "Información actualizada");
            ViewData.Add("message", "La información del usuario se actualizó con éxito.");
            return View("Result");
        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser([FromQuery] int userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound(ModelState);
            }
            if (!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("", "Ocurrió un error.");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

    }
}
