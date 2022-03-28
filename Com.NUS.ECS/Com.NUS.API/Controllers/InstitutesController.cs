using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace Com.NUS.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
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

    }
}
