using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EventHandler
{
    public static class EventHandler
    {
        //Set StorageACountConnectionString in local.setting.json
        [FunctionName("EventHandler")]
        public static void Run([QueueTrigger("events", Connection = "StorageAccountConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
