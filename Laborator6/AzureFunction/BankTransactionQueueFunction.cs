using AzureFunction.Models;
using AzureFunction.Storage;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AzureFunction
{
    public static class BankTransactionQueueFunction
    {
        public const string QUEUE_NAME = "MY_QUEUE_NAME_HERE";
        
        public const string TABLE_STORAGE_CONNECTION_STRING = "STORAGE_ACCOUNT_CONNECTION_STRING_HERE";

        public const string MY_NAME = "MY_NAME_HERE";

        [FunctionName("BankTransactionQueueFunction")]
        public static void Run([ServiceBusTrigger(QUEUE_NAME, Connection = "ConnectionStringKey")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var bankTransactionRepository = new TableStorageService<BankTransaction>(log, TABLE_STORAGE_CONNECTION_STRING, $"{MY_NAME}BankTransaction");
            var bankTransactionStatisticsRepository = new TableStorageService<BankTransactionStatistics>(log, TABLE_STORAGE_CONNECTION_STRING, $"{MY_NAME}BankTransactionStatistics");  

            // deserialize myQueueItem


            // add transaction to table storage


            // update statistic


        }
    }
}
