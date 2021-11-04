﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.YourCV.Core.Data;
using Tahaluf.YourCV.Core.Repository;

namespace Tahalut.YourCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : Controller
    {
        private readonly IResumeService resumeService;
        public ResumeController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }
        [HttpPost]
        [Route("CreateResume")]
        [ProducesResponseType(typeof(Education), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateResume([FromBody] Resume resume)
        {
            return resumeService.CreateResume(resume);
        }

        [HttpGet]
        [Route("GetAllResume")]
        [ProducesResponseType(typeof(List<Education>), StatusCodes.Status200OK)]
        public List<Resume> GetAllResume()
        {
            return resumeService.GetALLResume();
        }

        [HttpGet]
        [Route("GetAllResumeById/{id}")]
        [ProducesResponseType(typeof(Education), StatusCodes.Status200OK)]
        public Resume GetAllResumeById(int id)
        {
            return resumeService.GetResumeById(id);
        }

        [HttpDelete]
        [Route("DeleteResume/{id}")]
        [ProducesResponseType(typeof(Education), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteResume(int id)
        {
            return resumeService.DeleteResume(id);
        }

        [HttpPut]
        [Route("UpdateResume")]
        [ProducesResponseType(typeof(Education), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateResume([FromBody] Resume resume)
        {
            return resumeService.UpdateResume(resume);
        }
    }
}
