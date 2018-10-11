using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBroker : CustomResource<ClusterServiceBrokerSpec, ClusterServiceBrokerStatus>
    {
        public static CustomResourceDefinition<ClusterServiceBroker> Definition { get; } = Crd.For<ClusterServiceBroker>("clusterServiceBrokers");

        public ClusterServiceBroker()
        {}

        public ClusterServiceBroker(ClusterServiceBrokerSpec spec)
            : base(spec)
        {}
    }
}
