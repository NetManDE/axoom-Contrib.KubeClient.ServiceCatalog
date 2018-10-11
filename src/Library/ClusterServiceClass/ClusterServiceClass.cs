using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClass : CustomResource<ClusterServiceClassSpec, ClusterServiceClassStatus>
    {
        public static CustomResourceDefinition<ClusterServiceClass> Definition { get; } = Crd.For<ClusterServiceClass>("clusterServiceClasses");

        public ClusterServiceClass()
        {}

        public ClusterServiceClass(ClusterServiceClassSpec spec)
            : base(spec)
        {}
    }
}
