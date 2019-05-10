using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlan : CustomResource<ClusterServicePlanSpec, ClusterServicePlanStatus>
    {
        public new static CustomResourceDefinition Definition { get; } = Crd.For(pluralName: "clusterserviceplans", kind: "ClusterServicePlan");

        public ClusterServicePlan()
            : base(Definition)
        {}

        public ClusterServicePlan(string name, ClusterServicePlanSpec spec)
            : base(Definition, @namespace: null, name, spec)
        {}
    }
}
