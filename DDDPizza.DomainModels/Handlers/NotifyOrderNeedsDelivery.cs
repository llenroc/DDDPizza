using System;
using System.Diagnostics;
using Autofac.Events;
using DDDPizza.DomainModels.Events;

namespace DDDPizza.DomainModels.Handlers
{

    public class NotifyOrderNeedsDelivery : IHandleEvent<OrderNeedsDelivery>
    {
      
        public void Handle(OrderNeedsDelivery args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Trace.Write("[EMAIL] Notification email sent to the delivery guy");
            Console.WriteLine("[EMAIL] Notification email sent to the delivery guy");
           
            Console.ResetColor();
            //args.Order.DateTimeStamp;
        }
    }
}