using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlanStore : CustomResourceWatcher<ClusterServicePlan>, IClusterServicePlanStore
    {
        public ClusterServicePlanStore(ILogger logger,
                                       ICustomResourceClient<ClusterServicePlan> client,
                                       CustomResourceDefinition<ClusterServicePlan> crd)
            : base(logger, client, crd)
        {}
    }
}
