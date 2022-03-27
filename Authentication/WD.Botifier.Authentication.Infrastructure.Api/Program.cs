using Microsoft.Extensions.Options;
using WD.Botifier.Authentication.Application.Ports;
using WD.Botifier.Authentication.Application.Users.Login;
using WD.Botifier.Authentication.Application.Users.Signup;
using WD.Botifier.Authentication.Application.Users.ValidateAccessToken;
using WD.Botifier.Authentication.Domain.Users;
using WD.Botifier.Authentication.Infrastructure;
using WD.Botifier.Authentication.Infrastructure.Api.Middlewares;
using WD.Botifier.Authentication.Infrastructure.Passwordhasher;
using WD.Botifier.Authentication.Persistence.MongoDb;
using WD.Botifier.Authentication.Persistence.MongoDb.Users;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services
    //.AddSwaggerGen()
    .AddEndpointsApiExplorer()
    //.AddPersistenceServices(builder.Configuration)
    //.AddAuthServices(builder.Configuration)
    .AddLogging(logging => logging.AddConsole())
    //.AddUseCases()
    .AddControllers();

services
    .Configure<BotifierAuthenticationMongoDatabaseSettings>(configuration.GetSection("MongoDatabaseSettings"))
    .AddSingleton(sp => sp.GetRequiredService<IOptions<BotifierAuthenticationMongoDatabaseSettings>>().Value);
        
services.AddScoped<IUserRepository, UserRepository>();

services.AddTransient<SignupCommandHandler>();
services.AddTransient<LoginCommandHandler>();
services.AddTransient<ValidateAccessTokenQueryHandler>();

services.AddSingleton<IAccessTokenManager, AccessTokenManager>();
services.AddSingleton<IPasswordEncryptor, PasswordEncryptor>();

var jwtConfig = new JwtConfig();
configuration.GetSection("JwtConfig").Bind(jwtConfig);
services.AddSingleton<JwtConfig>(_ => jwtConfig);

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
//     
//     app.UseMiddleware<DevelopmentGlobalErrorHandlingMiddleware>();
// }
// else
// {
//     app.UseMiddleware<ProductionGlobalErrorHandlingMiddleware>();
// }

app.UseMiddleware<BusinessRuleValidationExceptionHandlingMiddleware>();

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();