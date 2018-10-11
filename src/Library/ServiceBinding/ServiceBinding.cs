using System;
using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBinding : CustomResource<ServiceBindingSpec, ServiceBindingStatus>
    {
        public static CustomResourceDefinition<ServiceBinding> Definition { get; } = Crd.For<ServiceBinding>("serviceBindings");

        public ServiceBinding()
        {}

        public ServiceBinding(ServiceBindingSpec spec)
            : base(spec)
        {}
    }
}
