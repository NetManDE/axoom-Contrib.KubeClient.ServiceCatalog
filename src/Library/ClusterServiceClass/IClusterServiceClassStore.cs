using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    public interface IClusterServiceClassStore : ICustomResourceWatcher<ClusterServiceClass>
    {}
}
