using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;
using WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;
using WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Infrastructure.Api;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;

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
    .AddAuthentication(x =>
    {
        x.DefaultScheme = "Botifier.Auth";
    })
    .AddScheme<AuthenticationSchemeOptions, BotifierAuthHandler>("Botifier.Auth", null);

services
    .Configure<BotifierBotRegistryMongoDatabaseSettings>(configuration.GetSection("MongoDatabaseSettings"))
    .AddSingleton(sp => sp.GetRequiredService<IOptions<BotifierBotRegistryMongoDatabaseSettings>>().Value);

services.AddTransient<IRedditBotRepository, RedditBotRepository>();
services.AddTransient<IRedditBotRepository, RedditBotRepository>();

services.AddTransient<CreateRedditBotCommandHandler>();
services.AddTransient<EditRedditBotCredentialsCommandHandler>();
services.AddTransient<ListRedditBotsOfOwnerQueryHandler>();
services.AddTransient<AddNewPostInSubredditTriggerCommandHandler>();
services.AddTransient<AddBotUserNameMentionInCommentTriggerCommandHandler>();

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

app.UseHttpsRedirection();

app.Run();