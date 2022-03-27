using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WD.Botifier.SeedWork;

namespace WD.Botifier.Authentication.Infrastructure.Api.Middlewares;

public class BusinessRuleValidationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public BusinessRuleValidationExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<BusinessRuleValidationExceptionHandlingMiddleware> logger)
    {
        try
        {
            await _next(context);
            
        }
        catch (BusinessRuleValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            var body = new ProblemDetails {Title = "Conflict.", Detail = ex.Details, Status = (int)HttpStatusCode.Conflict, Type = ex.BrokenRule.GetType().Name};
            await context.Response.WriteAsync(JsonConvert.SerializeObject(body));
        }
    }
}