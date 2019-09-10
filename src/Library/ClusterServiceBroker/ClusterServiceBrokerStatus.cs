using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBrokerStatus
    {
        public ServiceBrokerCondition[] Conditions { get; set; }

        /// <summary>
        /// ReconciledGeneration is the 'Generation' of the ServiceBrokerSpec that
        /// was last processed by the controller. The reconciled generation is updated
        /// even if the controller failed to process the spec.
        /// </summary>
        public long ReconciledGeneration { get; set; }

        /// <summary>
        /// OperationStartTime is the time at which the current operation began.
        /// </summary>
        public DateTime? OperationStartTime { get; set; }

        /// <summary>
        /// LastCatalogRetrievalTime is the time the Catalog was last fetched from
        /// the Service Broker
        /// </summary>
        public DateTime? LastCatalogRetrievalTime { get; set; }
    }
}
