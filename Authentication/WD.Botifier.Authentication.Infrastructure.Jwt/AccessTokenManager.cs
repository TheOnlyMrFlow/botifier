using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WD.Botifier.Authentication.Application.Ports;
using WD.Botifier.Authentication.Domain.Users;

namespace WD.Botifier.Authentication.Infrastructure.Jwt;

public class AccessTokenManager : IAccessTokenManager
{
    private readonly JwtConfig _config;
    private readonly SymmetricSecurityKey _symmertricSecurityKey;

    public AccessTokenManager(JwtConfig config)
    {
        _config = config;
        _symmertricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey));
    }

    public AccessToken Build(User user /* , IEnumerable<Claim> claims */)
    {
        var token = new JwtSecurityToken(
            _config.Issuer,
            _config.Audience,
            //claims.Concat(new [] {new Claim("userId", user.Id.ToString())}),
            expires: DateTime.UtcNow.AddMinutes(_config.ExpiryInMinutes),
            signingCredentials: new SigningCredentials(_symmertricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        return new AccessToken(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public bool IsValid(AccessToken accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _symmertricSecurityKey,
            ValidAudience = _config.Audience,
            ValidateAudience = true,
            ValidIssuer = _config.Issuer,
            ValidateIssuer = true
        };

        SecurityToken validatedToken;
        try
        {
            tokenHandler.ValidateToken(accessToken.Value, validationParameters, out validatedToken);
        }
        catch (Exception)
        {
            return false;
        }

        return validatedToken != null;
    }
}

public class JwtConfig
{
    public int ExpiryInMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}