using System;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Interfaces;
using Twilio;

namespace DDDPizza.Infrastructure
{
    public class MessageService : IMessageService
    {

        private readonly TwilioRestClient _twilioRestClient;

        public MessageService()
        {
            _twilioRestClient = new TwilioRestClient("ACaf6207e619a1c6209160c3aa5bb74c05", "1ec92c959ac3c5dcba8226e1d0edec6a");
        }

        public void NotifyDelivery(Order order)
        {
            var message = String.Format("{0} has placed an order for delivery.", order.Name);
            _twilioRestClient.SendSmsMessage("8315861310", "8319700072", message);
        }
    }
}
