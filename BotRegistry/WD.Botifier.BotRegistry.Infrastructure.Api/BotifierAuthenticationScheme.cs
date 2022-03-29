using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace WD.Botifier.BotRegistry.Infrastructure.Api;

public class BotifierAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IOptionsMonitor<AuthenticationSchemeOptions> _options;

    public BotifierAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _options = options;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var accessToken = GetAccessToken();
        if (accessToken is null)
            return AuthenticateResult.Fail("Missing Authorization Header");

        using var restClient = new RestClient();
        var validateTokenRequest = new RestRequest("https://localhost:7041/auth/validateToken", Method.Post).AddBody(new {AccessToken = accessToken}); 
        var claimsResponse = await restClient.ExecuteAsync<Dictionary<string, string>>(validateTokenRequest);
        if (!claimsResponse.IsSuccessful) 
            return AuthenticateResult.Fail("Unauthorized");
        
        var claimsPrincipal = new ClaimsPrincipal();
        var identity = new ClaimsIdentity("jwt");
        identity.AddClaims(claimsResponse.Data.Select(pair => new Claim(pair.Key, pair.Value)));
        claimsPrincipal.AddIdentity(identity);
        return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
    }

    private string? GetAccessToken()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var authHeaders) || authHeaders.FirstOrDefault() is var authHeader && authHeader is null)
            return null;
        
        return authHeader.Split(" ").LastOrDefault();
    }
}