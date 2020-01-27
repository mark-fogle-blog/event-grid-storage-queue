using System;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;

namespace EventSource
{
    class Program
    {
        static async Task Main()
        {
            //Event Grid Topic Access Key
            const string eventGridTopicKey = "";
            
            //event grid topic host name (i.e. [your event grid name].southcentralus-1.eventgrid.azure.net)
            const string eventGridTopicHostName = "";
            
            var topicCredentials = new TopicCredentials(eventGridTopicKey);
            var eventGridClient = new EventGridClient(topicCredentials);
            
            //Just loop and send event every 5 seconds
            while (true)
            {
                var eventTime = DateTime.UtcNow;
                Console.WriteLine($"{eventTime} - Sending event");
                var events = new[]
                {
                    new EventGridEvent
                    {
                        Id = Guid.NewGuid().ToString(),
                        Data = "Test",
                        Subject = "Test",
                        EventType = "Test",
                        DataVersion = "1.0",
                        EventTime = eventTime
                    }
                };

                await eventGridClient.PublishEventsAsync(eventGridTopicHostName, events);
                await Task.Delay(5000);
            }
        }
    }
}
