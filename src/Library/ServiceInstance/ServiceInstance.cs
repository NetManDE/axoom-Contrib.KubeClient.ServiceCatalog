using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstance : CustomResource<ServiceInstanceSpec, ServiceInstanceStatus>
    {
        public static CustomResourceDefinition<ServiceInstance> Definition { get; } = Crd.For<ServiceInstance>("serviceInstances");

        public ServiceInstance()
        {}

        public ServiceInstance(ServiceInstanceSpec spec)
            : base(spec)
        {}
    }
}
