using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WD.Botifier.RedditBotRunner.Application;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Infra.BotRegistryClient;
using WD.Botifier.RedditBotRunner.Infra.RedditApiClient.RedditWatcher;

CreateHostBuilder(args).Build().RunAsync().GetAwaiter().GetResult();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host
        .CreateDefaultBuilder(args)
        .ConfigureLogging(loggingBuilder => loggingBuilder.AddConsole())
        .ConfigureHostConfiguration(configBuilder =>
            configBuilder
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", true)
                .Build())
        .ConfigureServices((context, services) =>
            services
                .AddSingleton<IRedditWatcher, RedditWatcher>()
                .AddSingleton<IBotRegistryClient, BotRegistryClient>()
                .AddSingleton<TriggerExecutor>()
                .AddSingleton<WebhookCaller>()
                .AddHostedService<BotRunner>());