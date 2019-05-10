using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlanStatus
    {
        /// <summary>
        /// RemovedFromBrokerCatalog indicates that the broker removed the plan
        /// from its catalog.
        /// </summary>
        public bool RemovedFromBrokerCatalog { get; set; }
    }
}
