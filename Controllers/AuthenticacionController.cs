using BookStore.BLL.Interfaces;
using BookStore.BLL.Services;
using BookStore.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticacionController : ControllerBase
    {
        private readonly IAuthorizacionService _authorizacionService;

        public AuthenticacionController(IAuthorizacionService authorizacionService)
        {
            _authorizacionService = authorizacionService;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionRequest authorization)
        {
            var authorization_result = await _authorizacionService.ReturnToken(authorization);
            if (authorization_result == null) return Unauthorized();

            return Ok(authorization_result);

        }
    }
}
