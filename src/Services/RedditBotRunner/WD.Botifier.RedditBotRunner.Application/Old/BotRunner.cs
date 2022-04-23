// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Hosting;
// using WD.Botifier.RedditBotRunner.Application.Ports;
// using WD.Botifier.RedditBotRunner.Domain.Triggers;
// using WD.Botifier.SeedWork;
//
// namespace WD.Botifier.RedditBotRunner.Application;
//
// public class BotRunner : BackgroundService
// {
//     private readonly Dictionary<TriggerId, IDisposable> _subscriptions = new ();
//     private readonly IRedditWatcher _redditWatcher;
//     private readonly TriggerExecutor _triggerExecutor;
//     private readonly IBotRegistryClient _botRegistryClient;
//     //private readonly IIntegrationEventBus _integrationEventBus;
//     
//     protected override async Task ExecuteAsync(CancellationToken cancellationToken)
//     {
//         try
//         {
//
//             foreach (var trigger in _botRegistryClient.FetchAllTriggers())
//             {
//                 if (trigger is NewPostInSubredditTrigger newPostInSubredditTrigger)
//                     AddTrigger(newPostInSubredditTrigger);
//
//                 // if (trigger is UserNameMentionInCommentTrigger userNameMentionInCommentTrigger) 
//                 //     AddTrigger(userNameMentionInCommentTrigger);
//
//                 // subscribe to integrationeventbus to add / remove triggers
//             }
//         }
//         catch (Exception e)
//         {
//             
//         }
//     }
//
//     public override async Task StopAsync(CancellationToken cancellationToken)
//     {
//         foreach (var triggerId in _subscriptions.Keys) 
//             RemoveTrigger(triggerId);
//     }
//     
//     public BotRunner(TriggerExecutor triggerExecutor, IRedditWatcher redditWatcher, IBotRegistryClient botRegistryClient)
//     {
//         _triggerExecutor = triggerExecutor;
//         _redditWatcher = redditWatcher;
//         _botRegistryClient = botRegistryClient;
//         //_integrationEventBus = integrationEventBus;
//     }
//
//     private void AddTrigger(NewPostInSubredditTrigger trigger)
//     {
//         var subscription = _redditWatcher.WatchNewPostsInSubreddit(trigger.Subreddits, post => _triggerExecutor.ExecuteAsync(trigger.Match(post)).GetAwaiter().GetResult());
//         
//         _subscriptions.Add(trigger.Id, subscription);
//     }
//
//     private void RemoveTrigger(TriggerId triggerId)
//     {
//         _subscriptions[triggerId].Dispose();
//         _subscriptions.Remove(triggerId);
//     }
// }