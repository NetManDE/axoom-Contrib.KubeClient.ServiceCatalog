using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClassStatus
    {
        /// <summary>
        /// RemovedFromBrokerCatalog indicates that the broker removed the service from its
        /// catalog.
        /// </summary>
        public bool RemovedFromBrokerCatalog { get; set; }
    }
}
