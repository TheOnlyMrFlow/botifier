using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WD.Botifier.Authentication.Application.Users.Signup;
using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Domain.Users.ClearPasswords;

namespace WD.Botifier.Authentication.Infrastructure.Api.Users.Controllers.Signup;

[ApiController]
public class SignupController : ControllerBase
{
    private readonly ILogger<SignupController> _logger;
    private readonly SignupCommandHandler _commandHandler;

    public SignupController(ILogger<SignupController> logger, SignupCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [HttpPost("auth/signup", Name = "Signup")]
    public async Task<IActionResult?> Signup([FromBody] SignupHttpRequestBody requestBody)
    {
        var command = new SignupCommand(new Email(requestBody.Email), new ClearPassword(requestBody.Password));

        var result = await _commandHandler.HandleAsync(command);

        return result.Match(
            success => Created(string.Empty, null),
            emailExistsError => Conflict(new ProblemDetails { Title = "Conflict.", Detail = "Email already exists"}) as IActionResult
        );
    }
}