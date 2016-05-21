﻿using System;

namespace SlimMessageBus.Core.Config
{
    public class MessageBusBuilder       
    {
        protected internal Lazy<HandlerResolverChain> ResolverChain = new Lazy<HandlerResolverChain>();

        public SimpleMessageBusBuilder SimpleMessageBus()
        {
            var builder = new SimpleMessageBusBuilder(this);
            return builder;
        }

        public MessageBusBuilder ResolveHandlersFrom(IHandlerResolver resolver)
        {
            ResolverChain.Value.Add(resolver);
            return this;
        }

        public virtual IMessageBus Build()
        {
            var bus = new SimpleMessageBus();
            if (ResolverChain.IsValueCreated)
            {
                bus.HandlerResolver = ResolverChain.Value;
            }
            return bus;
        }
    }
}
