﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Route("UpdateUser")]
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


        [HttpGet]
        [Route("GetUserById/{id}")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]

        public List<User> GetUserById(int id)
        {
            return userService.GetUserById(id);
        }


        
        [HttpPost]
        [Route("upload")]
        public User Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileContent = ms.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);




                string attachmentFileName = $"{Guid.NewGuid().ToString("N")}_{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\DELL\\Desktop\\YourCv\\Tahaluf.YourCV.API\\Properties\\assets\\" + "images\\customers\\",attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return new User { PersonalPhoto = attachmentFileName };
            }
            catch (Exception e)
            {
                return null;
            }





        }
    }
}

