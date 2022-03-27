using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WD.Botifier.BotRegistry.Application.Bots;
using WD.Botifier.BotRegistry.Domain.Bots;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.Bots;

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
    .Configure<BotifierBotRegistryMongoDatabaseSettings>(configuration.GetSection("MongoDatabaseSettings"))
    .AddSingleton(sp => sp.GetRequiredService<IOptions<BotifierBotRegistryMongoDatabaseSettings>>().Value);

services.AddTransient<IBotRepository, BotRepository>();
services.AddTransient<IBotRepository, BotRepository>();

services.AddTransient<CreateBotCommandHandler>();

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

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();