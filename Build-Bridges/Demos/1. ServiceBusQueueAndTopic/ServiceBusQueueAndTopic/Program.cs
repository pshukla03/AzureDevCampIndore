using System;

namespace ServiceBusQueueAndTopic
{
    using Microsoft.Azure;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static void Main(string[] args)
        {
            //RunQueueDemo();
            RunTopicDemo();

            Console.ReadLine();
        }

        private static void RunQueueDemo()
        {
            #region Create Queue

            var namespaceManager = NamespaceManager.CreateFromConnectionString(CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"));

            const string queueName = "TestQueue";
            var queueDescription = new QueueDescription(queueName)
            {
                MaxSizeInMegabytes = 5120,
                DefaultMessageTimeToLive = new TimeSpan(0, 1, 0)
            };

            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueDescription);
            }

            #endregion

            #region Send message to Queue

            var client = QueueClient.CreateFromConnectionString(
        CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), queueName);

            var message = new BrokeredMessage("Test Message");
            message.Properties["PartnerName"] = "Microsoft";
            client.Send(message);

            // Get service bus queue client

            // Create message, passing a string message for the body

            // Set some addtional custom app-specific properties

            // Send message to the queue

            #endregion

            #region Read message from Queue

            var options = new OnMessageOptions
            {
                AutoComplete = true,
                AutoRenewTimeout = TimeSpan.FromMinutes(1)
            };

            client.OnMessage(queuedMessage =>
            {
                try
                {
                    Console.WriteLine("Message Id:" + queuedMessage.MessageId);
                    Console.WriteLine("Message Body:" + queuedMessage.GetBody<string>());
                    Console.WriteLine("Partner Name:" + queuedMessage.Properties["PartnerName"]);

                    queuedMessage.Complete();
                }
                catch (Exception)
                {
                    queuedMessage.Abandon();
                }
            }, options);

            // Configure the callback options

            // Set callback to handle received messages

            // Process message from queue

            // Remove message from queue if successful or abandon if error

            #endregion
        }

        private static void RunTopicDemo()
        {
            #region Create Topic
            var namespaceManager = NamespaceManager.CreateFromConnectionString(
    CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"));

            const string topicName = "TestTopic";
            var topicDescription = new TopicDescription(topicName)
            {
                MaxSizeInMegabytes = 5120,
                DefaultMessageTimeToLive = new TimeSpan(0, 1, 0)
            };

            if (!namespaceManager.TopicExists(topicName))
            {
                namespaceManager.CreateTopic(topicDescription);
            }
            #endregion

            #region Create Subscriptions

            const string allMessagesSubscription = "AllMessages";
            if (!namespaceManager.SubscriptionExists(topicName, allMessagesSubscription))
            {
                namespaceManager.CreateSubscription(topicName, allMessagesSubscription);
            }

            const string highMessagesSubscription = "HighMessages";
            if (!namespaceManager.SubscriptionExists(topicName, highMessagesSubscription))
            {
                var highMessagesFilter = new SqlFilter("MessageNumber > 3");
                namespaceManager.CreateSubscription(topicName, highMessagesSubscription, highMessagesFilter);
            }

            const string lowMessagesSubscription = "LowMessages";
            if (!namespaceManager.SubscriptionExists(topicName, lowMessagesSubscription))
            {
                var lowMessagesFilter = new SqlFilter("MessageNumber <= 3");
                namespaceManager.CreateSubscription(topicName, lowMessagesSubscription, lowMessagesFilter);

            }


            #endregion

            #region Send message to Topic

            var client = TopicClient.CreateFromConnectionString(
        CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), topicName);

            for (var i = 0; i < 5; i++)
            {
                var topicMessage =
                new BrokeredMessage("Test message " + i);
                topicMessage.Properties["MessageNumber"] = i;
                client.Send(topicMessage);

            }
            // Get service bus topic client

            // Create message, passing a string message for the body

            // Set MessageNumber property

            // Send message to the topic

            #endregion

            #region Receive message from Topic

            var subscriptionClientAll = SubscriptionClient.CreateFromConnectionString(
    CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), topicName,
    allMessagesSubscription);

            var subscriptionClientHigh = SubscriptionClient.CreateFromConnectionString(
                CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), topicName,
                highMessagesSubscription);

            var subscriptionClientLow = SubscriptionClient.CreateFromConnectionString(
                CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), topicName,
                lowMessagesSubscription);

            var options = new OnMessageOptions
            {
                AutoComplete = false,
                AutoRenewTimeout = TimeSpan.FromMinutes(1)
            };

            subscriptionClientAll.OnMessage(message =>
            {
                ProcessTopicMessage(message, allMessagesSubscription);
            }, options);

            subscriptionClientHigh.OnMessage(message =>
            {
                ProcessTopicMessage(message, highMessagesSubscription);
            }, options);

            subscriptionClientLow.OnMessage(message =>
            {
                ProcessTopicMessage(message, lowMessagesSubscription);
            }, options);


            // Get subscription clients for all filters

            // Configure the callback options

            // Set callback to handle received messages

            // Process message from topic

            // Remove message from topic if successful or abandon if error

            #endregion
        }

        private static void ProcessTopicMessage(BrokeredMessage message, string messageSubscription)
        {
            try
            {
                Console.WriteLine("\n**{0}**", messageSubscription);
                Console.WriteLine("Body: " + message.GetBody<string>());
                Console.WriteLine("MessageID: " + message.MessageId);
                Console.WriteLine("Message Number: " +
                                    message.Properties["MessageNumber"]);

                message.Complete();
            }
            catch (Exception)
            {
                message.Abandon();
            }
        }

    }
}
