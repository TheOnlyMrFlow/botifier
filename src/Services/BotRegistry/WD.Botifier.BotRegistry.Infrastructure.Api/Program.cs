using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WD.Botifier.BotRegistry.Application.DomainEventHandlers;
using WD.Botifier.BotRegistry.Application.RedditBots.AddBotUserNameMentionInCommentTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.AddNewPostInSubredditTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;
using WD.Botifier.BotRegistry.Application.RedditBots.CreateRedditBot;
using WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;
using WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;
using WD.Botifier.BotRegistry.Application.RedditBots.ListRedditBotsOfOwner;
using WD.Botifier.BotRegistry.Application.RedditBots.RemoveWebhookFromTrigger;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Events;
using WD.Botifier.BotRegistry.Infrastructure.Api;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb;
using WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots;
using WD.Botifier.Infra.IntegrationEventBus.RabbitMQ;
using WD.Botifier.SeedWork;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services
    .AddEndpointsApiExplorer()
    .AddLogging(logging => logging.AddConsole())
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

services.AddSingleton<DomainEventBus>();

services.AddTransient<IIntegrationEventBus, RabbitMqIntegrationEventBus>();

services.AddTransient<IRedditBotRepository, RedditBotRepository>();
services.AddTransient<IRedditBotRepository, RedditBotRepository>();

services.AddTransient<PublishIntegrationEventWhenBotIsCreatedDomainEventHandler>();

services.AddTransient<CreateRedditBotCommandHandler>();
services.AddTransient<EditRedditBotCredentialsCommandHandler>();
services.AddTransient<ListRedditBotsOfOwnerQueryHandler>();
services.AddTransient<GetRedditBotDetailsQueryHandler>();
services.AddTransient<AddNewPostInSubredditTriggerCommandHandler>();
services.AddTransient<AddBotUserNameMentionInCommentTriggerCommandHandler>();
services.AddTransient<AddWebhookToTriggerCommandHandler>();
services.AddTransient<RemoveWebhookFromTriggerCommandHandler>();

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

app.Services.GetService<DomainEventBus>()!.RegisterHandler<RedditBotCreatedDomainEvent>(@event =>
{
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetService<PublishIntegrationEventWhenBotIsCreatedDomainEventHandler>()!.HandleAsync(@event).GetAwaiter().GetResult();
});

app.Run();