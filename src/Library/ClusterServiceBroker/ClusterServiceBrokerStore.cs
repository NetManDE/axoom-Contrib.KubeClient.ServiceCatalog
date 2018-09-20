using Contrib.KubeClient.CustomResources;
using Microsoft.Extensions.Logging;

namespace Kubernetes.ServiceCatalog.Models
{
    class ClusterServiceBrokerStore : CustomResourceWatcher<ClusterServiceBroker>, IClusterServiceBrokerStore
    {
        public ClusterServiceBrokerStore(ILogger logger, 
                                         ICustomResourceClient<ClusterServiceBroker> client, 
                                         CustomResourceDefinition<ClusterServiceBroker> crd) 
            : base(logger, client, crd)
        {}
    }
}