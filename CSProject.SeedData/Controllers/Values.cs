using Microsoft.AspNetCore.Mvc;

namespace CSProject.SeedData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Values : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
