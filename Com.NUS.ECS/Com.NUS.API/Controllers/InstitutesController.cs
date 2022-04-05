using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Threading.Tasks; 

namespace Com.NUS.API.Controllers
{
    [Route("api/v{version:apiVersion}/institutes")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class InstitutesController : ControllerBase
    {
        private readonly IInstituteService _svsInstitute;
        private readonly ILogger<InstitutesController> _logger;

        public InstitutesController(IInstituteService svsInstitute, ILogger<InstitutesController> logger)
        {
             _svsInstitute = svsInstitute;
            _logger = logger;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            var output = new List<VmInstitute>();
            return new JsonResult(output);
        }

        [HttpGet("{id}")]
        //[MapToApiVersion("1.0")]
        public IActionResult Get(int id)
        {
            _logger.LogTrace("Trace Log");
            _logger.LogDebug("Debug Log");
            _logger.LogInformation("Information Log");
            _logger.LogWarning("Warning Log");
            _logger.LogError("Error Log");
            _logger.LogCritical("Critical Log");


            var output = _svsInstitute.GetActiveInstitutes();
            output.Add(new VmInstitute { Name = "ABC" });
            return new JsonResult(output);
        }


        [HttpPost]
        public IActionResult Post([FromBody]VmInstitute institute)
        {
            var output = _svsInstitute.AddInstitute(institute); 
            return new JsonResult(output);
        }


        [HttpPut]
        public IActionResult Put(VmInstitute institute)
        {
            var output = _svsInstitute.AddInstitute(institute);
            return new JsonResult(output);
        }


        [HttpPatch]
        public IActionResult Patch(VmInstitute institute)
        {
            var output = _svsInstitute.AddInstitute(institute);
            return new JsonResult(output);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var output = "";
            return new JsonResult(output);
        }
    }

    [Route("api/v{version:apiVersion}/institutes")]
    [Produces("application/json")]
    [ApiController] 
    [ApiVersion("2.0")]
    public class Institutes2Controller : ControllerBase
    {
        private readonly IInstituteService _svsInstitute;
        private readonly ILogger<Institutes2Controller> _logger;

        public Institutes2Controller(IInstituteService svsInstitute, ILogger<Institutes2Controller> logger)
        {
            _svsInstitute = svsInstitute;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var output = new List<VmInstitute>();
            return new JsonResult(output);
        }

        [HttpGet("{id}")] 
        public IActionResult Get(int id)
        {
            var output = new List<VmInstitute>();
            output.Add(new VmInstitute { Name = "DEF" });
            return new JsonResult(output);
        }

    }
}
