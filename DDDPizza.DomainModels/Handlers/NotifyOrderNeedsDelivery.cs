﻿using Autofac.Events;
using DDDPizza.DomainModels.Events;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Handlers
{

    public class NotifyOrderNeedsDelivery : IHandleEvent<OrderNeedsDelivery>
    {

        private readonly IMessageService _messageService;

        public NotifyOrderNeedsDelivery(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Handle(OrderNeedsDelivery args)
        {
           _messageService.NotifyDelivery(args.Order);

        }
    }
}