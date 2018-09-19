using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClassStore : CustomResourceWatcher<ClusterServiceClass>, IClusterServiceClassStore
    {
        public ClusterServiceClassStore(ILogger logger,
                                        ICustomResourceClient<ClusterServiceClass> client,
                                        CustomResourceDefinition<ClusterServiceClass> crd)
            : base(logger, client, crd)
        {}
    }
}