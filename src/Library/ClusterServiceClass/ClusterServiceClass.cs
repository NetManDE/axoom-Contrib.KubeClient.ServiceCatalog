using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClass : CustomResource<ClusterServiceClassSpec, ClusterServiceClassStatus>
    {
        public new static CustomResourceDefinition Definition { get; } = Crd.For(pluralName: "clusterServiceClasses", kind: "ClusterServiceClass");

        public ClusterServiceClass()
            : base(Definition)
        {}

        public ClusterServiceClass(string name, ClusterServiceClassSpec spec)
            : base(Definition, @namespace: null, name, spec)
        {}
    }
}
