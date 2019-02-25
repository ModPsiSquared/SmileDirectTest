using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmileDirect.SpaceXProxyService.Services;
using SmileDirect.SpaceXProxyService.DTOs;
using System;
using System.Collections.Generic;


namespace SmileDirect.SpaceXProxyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchPadController : ControllerBase
    {
        ISpaceXService _service;

        private readonly ILogger<LaunchPadController> _logger;

        public LaunchPadController(ISpaceXService service, ILogger<LaunchPadController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LaunchPad>> Get()
        {
            return Ok( _service.GetLaunchPads());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var item = _service.GetLaunchPad(id);

            if (item == null)
                return new NotFoundObjectResult("No launchpad data for " + id + ".");
            else
                return Ok(item);
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogInformation("User attempting to Create launchpad data and is unsupported.");
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _logger.LogInformation("User attempting to update launchpad data and is unsupported.");
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("User attempting to delete launchpad data and is unsupported.");
            throw new NotImplementedException();
        }
    }
}
