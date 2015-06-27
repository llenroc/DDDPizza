using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using RestSharp;
using Twilio;

namespace DDDPizza.DomainServices
{
    public class MessagingService : IMessagingService
    {
        private readonly TwilioRestClient _twilioRestClient;
      

        public MessagingService(IRestClient restClient)
        {
            _twilioRestClient = new TwilioRestClient("ACaf6207e619a1c6209160c3aa5bb74c05", "1ec92c959ac3c5dcba8226e1d0edec6a");
        }

        public void NotifyDelivery(Order order)
        {
            _twilioRestClient.SendSmsMessage("8319700072", "8312724787", "Pizza was ordered!");
        }

    }
}
