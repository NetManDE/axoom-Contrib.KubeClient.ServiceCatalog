using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBroker : CustomResource<ClusterServiceBrokerSpec, ClusterServiceBrokerStatus>
    {
        public new static CustomResourceDefinition Definition { get; } = Crd.For(pluralName: "clusterServiceBrokers", kind: "ClusterServiceBroker");

        public ClusterServiceBroker()
            : base(Definition)
        {}

        public ClusterServiceBroker(string name, ClusterServiceBrokerSpec spec)
            : base(Definition, @namespace: null, name, spec)
        {}
    }
}
