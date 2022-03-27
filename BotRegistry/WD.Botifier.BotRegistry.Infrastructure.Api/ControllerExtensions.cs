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
        return new UserId(Guid.Parse("5b646cb7-06fd-4c29-b705-18c2ab398b1a"));
        return userIdClaim is null ? null : new UserId(Guid.Parse(userIdClaim.Value));
    }
}