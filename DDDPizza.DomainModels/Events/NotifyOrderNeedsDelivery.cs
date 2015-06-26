using System;
using DDDPizza.DomainModels.Interfaces;

namespace DDDPizza.DomainModels.Events
{
    public class NotifyOrderNeedsDelivery : IHandle<OrderNeedsDelivery>
    {
      

        public void Handle(OrderNeedsDelivery args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[EMAIL] Notification email sent to the delivery guy");
            Console.ResetColor();
            //args.Order.DateTimeStamp;
        }
    }
}