using System;
using Service;

namespace ServiceWithServiceBusRelay
{
    class ServiceWithRelay : IWho
    {
        public string Who()
        {
            // Implement Operation
            return "";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create Service Host

            // Add Service Endpoint with Service Bus Relay endpoint address

            // Create token provider

            // Add TransportClientEndpointBehavior

            // Open host

            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }
    }
}
