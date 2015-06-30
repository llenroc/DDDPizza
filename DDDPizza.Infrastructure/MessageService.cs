using System;
using System.Configuration;
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
            _twilioRestClient = new TwilioRestClient(ConfigurationManager.AppSettings.Get("twilio:accountSid"), 
                                        ConfigurationManager.AppSettings.Get("twilio:authToken"));
        }

        public void NotifyDelivery(Order order)
        {
            var message = String.Format("{0} has placed an order for delivery.", order.Name);
            _twilioRestClient.SendSmsMessage("8315861310", "8319700072", message);
        }
    }
}
