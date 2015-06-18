using System;

namespace ServiceBusQueueAndTopic
{
    class Program
    {
        static void Main(string[] args)
        {
            RunQueueDemo();
            RunTopicDemo();

            Console.ReadLine();
        }

        private static void RunQueueDemo()
        {
            #region Create Queue

            // Create the queue if it does not exist already

            #endregion

            #region Send message to Queue

            // Get service bus queue client

            // Create message, passing a string message for the body

            // Set some addtional custom app-specific properties

            // Send message to the queue

            #endregion

            #region Read message from Queue

            // Configure the callback options

            // Set callback to handle received messages

            // Process message from queue

            // Remove message from queue if successful or abandon if error

            #endregion
        }

        private static void RunTopicDemo()
        {
            #region Create Topic
            // Create the topic if it does not exist already
            #endregion

            #region Create Subscriptions

            // Create subscription with default(Match All) filter

            // Create subscription with Sql filters: HighMessages and LowMessages

            #endregion

            #region Send message to Topic

            // Get service bus topic client

            // Create message, passing a string message for the body

            // Set MessageNumber property

            // Send message to the topic

            #endregion

            #region Receive message from Topic

            // Get subscription clients for all filters

            // Configure the callback options

            // Set callback to handle received messages

            // Process message from topic

            // Remove message from topic if successful or abandon if error

            #endregion
        }
    }
}
