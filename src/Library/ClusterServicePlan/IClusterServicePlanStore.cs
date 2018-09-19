using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    public interface IClusterServicePlanStore : ICustomResourceWatcher<ClusterServicePlan>
    {}
}
