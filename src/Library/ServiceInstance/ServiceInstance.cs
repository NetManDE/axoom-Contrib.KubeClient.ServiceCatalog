using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstance : CustomResource<ServiceInstanceSpec, ServiceInstanceStatus>
    {
        public new static CustomResourceDefinition Definition { get; } = Crd.For(pluralName: "serviceinstances", kind: "ServiceInstance");

        public ServiceInstance()
            : base(Definition)
        {}

        public ServiceInstance(string @namespace, string name, ServiceInstanceSpec spec)
            : base(Definition, @namespace, name, spec)
        {}
    }
}
