using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    public interface IClusterServiceBrokerStore: ICustomResourceWatcher<ClusterServiceBroker>
    {}
}
