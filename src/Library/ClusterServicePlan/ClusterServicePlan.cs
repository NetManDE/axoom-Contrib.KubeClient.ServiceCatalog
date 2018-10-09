using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlan : CustomResource<ClusterServicePlanSpec, ClusterServicePlanStatus>
    {
        public static CustomResourceDefinition<ClusterServicePlan> Definition { get; } = Crd.For<ClusterServicePlan>();

        public ClusterServicePlan()
        {}

        public ClusterServicePlan(ClusterServicePlanSpec spec)
            : base(spec)
        {}
    }
}
