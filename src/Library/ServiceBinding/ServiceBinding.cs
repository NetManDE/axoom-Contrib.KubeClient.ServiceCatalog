using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBinding : CustomResource<ServiceBindingSpec, ServiceBindingStatus>
    {
        public new static CustomResourceDefinition Definition { get; } = Crd.For(pluralName: "servicebindings", kind: "ServiceBinding");

        public ServiceBinding()
            : base(Definition)
        {}

        public ServiceBinding(string @namespace, string name, ServiceBindingSpec spec)
            : base(Definition, @namespace, name, spec)
        {}
    }
}
