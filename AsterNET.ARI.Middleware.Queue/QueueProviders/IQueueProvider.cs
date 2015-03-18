﻿using System;

namespace AsterNET.ARI.Middleware.Queue.QueueProviders
{
    public interface IQueueProvider
    {
        IConsumer CreateConsumer(string queueName, string dialogId);
        IProducer CreateProducer(string queueName, string dialogId);
    }

    public interface IProducer
    {
        string QueueName { get; set; }
        string DialogId { get; set; }
        void PushToQueue(string message);
        void Close();
    }

    public interface IConsumer
    {
        /// <summary>
        ///     Gets or sets the name of the queue.
        /// </summary>
        /// <value>The name of the queue.</value>
        string QueueName { get; set; }

        string DialogId { get; set; }

        /// <summary>
        ///     Read a message from the queue.
        /// </summary>
        /// <param name="onDequeue">The action to take when receiving a message</param>
        /// <param name="onError">If an error occurs, provide an action to take.</param>
        /// <param name="exchangeName">Name of the exchange.</param>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="routingKeyName">Name of the routing key.</param>
        void ReadFromQueue(Action<string, IConsumer, ulong> onDequeue, Action<Exception, IConsumer, ulong> onError);

        void StopReading();
        void Close();
    }
}