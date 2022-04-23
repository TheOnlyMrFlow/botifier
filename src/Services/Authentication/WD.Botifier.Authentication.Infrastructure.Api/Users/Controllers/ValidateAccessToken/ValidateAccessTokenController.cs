using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.Authentication.Application.Users.ValidateAccessToken;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Infrastructure.Api.Users.Controllers.ValidateAccessToken;

[ApiController]
public class ValidateAccessTokenController : ControllerBase
{
    private readonly ILogger<ValidateAccessTokenController> _logger;
    private readonly ValidateAccessTokenQueryHandler _queryHandler;

    public ValidateAccessTokenController(ILogger<ValidateAccessTokenController> logger, ValidateAccessTokenQueryHandler queryHandler)
    {
        _logger = logger;
        _queryHandler = queryHandler;
    }

    [HttpPost("auth/validateToken", Name = "Validate access token")]
    public IActionResult ValidateAccessToken([FromBody] ValidateAccessTokenHttpRequestBody requestBody)
    {
        var query = new ValidateAccessTokenQuery(new AccessToken(requestBody.AccessToken));

        return _queryHandler.Handle(query).Match<IActionResult>(
            decodedToken => Ok(decodedToken),
            invalidToken => Unauthorized()
            );
    }
}