using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.YourCV.Core.Data;
using Tahaluf.YourCV.Core.Service;

namespace Tahaluf.YourCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateUser([FromBody] User user)
        {
            return userService.CreateUser(user);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetAllUser()
        {
            return userService.GetAllUser();
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateUser([FromBody] User user)
        {
            return userService.UpdateUser(user);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]

        public bool DeleteUser(int id)
        {
            return userService.DeleteUser(id);
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]

        public List<User> GetUserById(User user)
        {
            return userService.GetUserById(user);
        }

    }
}
