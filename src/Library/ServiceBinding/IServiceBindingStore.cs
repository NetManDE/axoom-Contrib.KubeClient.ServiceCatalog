using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    public interface IServiceBindingStore : ICustomResourceWatcher<ServiceBinding>
    {}
}
