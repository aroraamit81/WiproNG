using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wipro.Api.Models;
using Wipro.BO;
using Wipro.DAL;

namespace Wipro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService TrainingService)
        {
            _trainingService = TrainingService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Training t)
        {
            try
            {
                Training newObject = _trainingService.AddNewTraining(t);
                return Ok(newObject);
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A server error occurred");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_trainingService.GetAllTrainings());
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A server error occurred");
            }
        }
    }
}