using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TC.GrupoTrinta.BlogNews.Application.Interfaces;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Infra.Identity;

namespace TC.GrupoTrinta.BlogNews.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _identityService;

        public AccountController(IAuthenticationService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationModel model)
        {
            var existsUser = await _identityService.ExistsUserAsync(model.UserName);

            if (!existsUser) return NotFound();

            var token = await _identityService.AuthenticationAsync(model.UserName, model.Password);
            var succeeded = token != null;
            
            return Ok(new
            {
                succeeded,
                accessToken = token
            });
        }
    }
}
