using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.Authentication.Application.Users.Login;
using WD.Botifier.Authentication.Application.Users.Signup;
using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Domain.Users.ClearPasswords;

namespace WD.Botifier.Authentication.Infrastructure.Api.Users.Controllers.Login;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly LoginCommandHandler _commandHandler;

    public LoginController(ILogger<LoginController> logger, LoginCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [HttpPost("auth/login", Name = "Login")]
    public async Task<IActionResult?> LoginAsync([FromBody] LoginHttpRequestBody requestBody)
    {
        var command = new LoginCommand(new Email(requestBody.Email), new ClearPassword(requestBody.Password));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match(
            success => Ok(new { AccessToken = success.AccessToken.Value}),
            error => Unauthorized(new ProblemDetails { Title = "Unauthorized.", Detail = "Login failed."}) as IActionResult
        );
    }
}