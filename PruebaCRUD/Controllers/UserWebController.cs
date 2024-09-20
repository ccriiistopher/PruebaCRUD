using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaCRUD.Dto;
using PruebaCRUD.Interfaces;
using PruebaCRUD.Models;

namespace PruebaCRUD.Controllers
{
    [Route("/")]
    public class UserWebController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserWebController(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return View("Index", new UsersViewModel()
            {
                Users = users
            });
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type= typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(user == null)
            {
                return NotFound();
            }
            return View("User", user);
        }

        [HttpGet("{userId}/update")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUserUpdate(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user == null)
            {
                return NotFound();
            }
            return View("UserUpdate", user);
        }

        [HttpGet("create")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public IActionResult CreateUser()
        {
            
            return View("UserCreate");
        }
    }
}
