using CSProject.Auth.Interfaces;
using CSProject.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSProject.Auth.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private ITokenGenerator _tokenGen;
        public TokenController(ITokenGenerator tokenGen)
        {
            _tokenGen = tokenGen;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult Token([FromBody] UserInfo userInfo)
        {
            var accessToken = new AccessToken();
            accessToken.Token = _tokenGen.GenerateToken(userInfo);
            return Ok(accessToken);
        }
    }
}
