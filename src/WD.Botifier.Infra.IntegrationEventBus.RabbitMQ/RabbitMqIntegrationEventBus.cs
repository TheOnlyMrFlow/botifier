using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WD.Botifier.SeedWork;
using RabbitMQ.Client;

namespace WD.Botifier.Infra.IntegrationEventBus.RabbitMQ;

public class RabbitMqIntegrationEventBus : IIntegrationEventBus
{
    private const string BrokerName = ""; //"botifier_event_bus";
    
    public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
    {
        var factory = new ConnectionFactory { HostName = "rabbitmq" }; 
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var queueName = @event.GetType().Name;
        if (queueName.EndsWith("IntegrationEvent"))
            queueName = queueName[..^"IntegrationEvent".Length];
        else if (queueName.EndsWith("Event"))
            queueName = queueName[..^"Event".Length];

        channel.QueueDeclare(queueName, false, false, false, null);
        
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        channel.BasicPublish(BrokerName, queueName, null, body);

        return Task.CompletedTask;
    }
}