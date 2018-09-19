using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    public interface IServiceInstanceStore: ICustomResourceWatcher<ServiceInstance>
    {}
}
