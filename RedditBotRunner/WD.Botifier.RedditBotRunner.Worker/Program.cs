using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WD.Botifier.RedditBotRunner.Application;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Infra.BotRegistryClient;
using WD.Botifier.RedditBotRunner.Infra.RedditApIClient;

CreateHostBuilder(args).Build().RunAsync().GetAwaiter().GetResult();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host
        .CreateDefaultBuilder(args)
        .ConfigureLogging(loggingBuilder => loggingBuilder.AddConsole())
        .ConfigureHostConfiguration(configBuilder =>
            configBuilder
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build())
        .ConfigureServices((context, services) =>
            services
                .Configure<RedditApiClientFactoryConfiguration>(options => context.Configuration.GetSection("AppCredentials").Bind(options))
                .AddSingleton(sp => sp.GetRequiredService<IOptions<RedditApiClientFactoryConfiguration>>().Value)
                .AddSingleton<IAuthfulRedditApiFactory, RedditApiClientFactory>()
                .AddSingleton<IAuthlessRedditApiFactory, RedditApiClientFactory>()
                .AddSingleton<IBotRegistryClient, BotRegistryClient>()
                .AddSingleton<WebhookCaller>()
                .AddHostedService<BotOrchestrator>());