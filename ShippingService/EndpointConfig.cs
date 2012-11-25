using NServiceBus;

namespace ShippingService 
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://nservicebus.com/GenericHost.aspx
	*/
	public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Server
    {
        public void Init()
        {
            Configure.With()
                .CastleWindsorBuilder()
                .XmlSerializer()
                .MsmqTransport()
                .RavenSubscriptionStorage()
                .UnicastBus()
                .CreateBus()
                .Start();
        }
    }
}