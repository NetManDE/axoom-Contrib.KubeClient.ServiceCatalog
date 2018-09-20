using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingStore: CustomResourceWatcher<ServiceBinding>, IServiceBindingStore
    {
        public ServiceBindingStore(ILogger logger,
                                   ICustomResourceClient<ServiceBinding> client,
                                   CustomResourceDefinition<ServiceBinding> crd,
                                   string @namespace = "")
            : base(logger, client, crd, @namespace)
        {}
    }
}
