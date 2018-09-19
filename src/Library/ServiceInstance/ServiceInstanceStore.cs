using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstanceStore : CustomResourceWatcher<ServiceInstance>, IServiceInstanceStore
    {
        public ServiceInstanceStore(ILogger logger,
                                    ICustomResourceClient<ServiceInstance> client,
                                    CustomResourceDefinition<ServiceInstance> crd,
                                    string @namespace = "")
            : base(logger, client, crd, @namespace)
        {
        }
    }
}
