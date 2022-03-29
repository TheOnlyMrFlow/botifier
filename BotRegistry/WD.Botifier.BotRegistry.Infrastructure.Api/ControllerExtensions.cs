using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Infrastructure.Api;

public static class ControllerExtensions
{
    public static UserId? GetAuthenticatedUserId(this ControllerBase controller)
    {
        var userIdClaim = controller.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
        return userIdClaim is null ? null : new UserId(Guid.Parse(userIdClaim.Value));
    }
}