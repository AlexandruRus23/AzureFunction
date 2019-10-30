using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using QueueConsoleApp.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace QueueConsoleApp
{
    class Program
    {
        public const string SERVICE_BUS_CONNECTION_STRING = "CONNECTION_STRING_HERE";
        public const string QUEUE_NAME = "MY_QUEUE_NAME_HERE";

        static void Main(string[] args)
        {
            while (true)
            {
                MainAsync().GetAwaiter().GetResult();
                Console.ReadLine();
            }            
        }

        private static async Task MainAsync()
        {
            var randomNumber = new Random().Next(1, 100);
            var message = new QueueMessage()
            {
                SenderName = GetSenderName(randomNumber),
                Ammount = randomNumber,
                DestinationAccount = Guid.NewGuid().ToString(),
                DestinationName = GetDestinationName(randomNumber)
            };
            
            Console.WriteLine($"Sending message:\n{message.ToString()}");
            
            // initialize queue client and send message here



        }

        private static string GetSenderName(int randomNumber)
        {
            switch(randomNumber % 3)
            {
                case 0:
                    return "Amanda Jefferson";
                case 1:
                    return "Elton James";
                default:
                    return "John Smith";
            }
        }

        private static string GetDestinationName(int randomNumber)
        {
            switch (randomNumber % 3)
            {
                case 0:
                    return (randomNumber / 10) % 2 == 0 ? "Elton" : "John";
                case 1:
                    return (randomNumber / 10 % 2) == 0 ? "Amanda" : "John";
                default:
                    return (randomNumber / 10 % 2) == 0 ? "Elton" : "Amanda";
            }
        }
    }
}
