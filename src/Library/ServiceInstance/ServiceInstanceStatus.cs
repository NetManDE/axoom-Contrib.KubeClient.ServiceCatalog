using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstanceStatus
    {
        /// <summary>
        /// Conditions is an array of ServiceInstanceConditions capturing aspects of an
        /// ServiceInstance's status.
        /// </summary>
        public ServiceInstanceCondition[] Conditions { get; private set; } = new ServiceInstanceCondition[0];

        /// <summary>
        /// AsyncOpInProgress is set to true if there is an ongoing async operation
        /// against this ServiceInstance in progress.
        /// </summary>
        public bool AsyncOpInProgress { get; set; }

        /// <summary>
        /// OrphanMitigationInProgress is set to true if there is an ongoing orphan
        /// mitigation operation against this ServiceInstance in progress.
        /// </summary>
        public bool OrphanMitigationInProgress { get; set; }

        /// <summary>
        /// LastOperation is the string that the broker may have returned when
        /// an async operation started, it should be sent back to the broker
        /// on poll requests as a query param.
        /// </summary>
        public string LastOperation { get; set; }

        /// <summary>
        /// DashboardURL is the URL of a web-based management user interface for
        /// the service instance.
        /// </summary>
        public string DashboardURL { get; set; }

        /// <summary>
        /// CurrentOperation is the operation the Controller is currently performing
        /// on the ServiceInstance.
        /// </summary>
        public ServiceInstanceOperation CurrentOperation { get; set; }

        /// <summary>
        /// ReconciledGeneration is the 'Generation' of the serviceInstanceSpec that
        /// was last processed by the controller. The reconciled generation is updated
        /// even if the controller failed to process the spec.
        /// Deprecated: use ObservedGeneration with conditions set to true to find
        /// whether generation was reconciled.
        /// </summary>
        public long ReconciledGeneration { get; set; }

        /// <summary>
        /// ObservedGeneration is the 'Generation' of the serviceInstanceSpec that
        /// was last processed by the controller. The observed generation is updated
        /// whenever the status is updated regardless of operation result.
        /// </summary>
        public long ObservedGeneration { get; set; }

        /// <summary>
        /// OperationStartTime is the time at which the current operation began.
        /// </summary>
        public DateTime? OperationStartTime { get; set; }

        /// <summary>
        /// InProgressProperties is the properties state of the ServiceInstance when
        /// a Provision, Update or Deprovision is in progress.
        /// </summary>
        public ServiceInstancePropertiesState InProgressProperties { get; set; }

        /// <summary>
        /// ExternalProperties is the properties state of the ServiceInstance which the
        /// broker knows about.
        /// </summary>
        public ServiceInstancePropertiesState ExternalProperties { get; set; }

        /// <summary>
        /// ProvisionStatus describes whether the instance is in the provisioned state.
        /// </summary>
        public ServiceInstanceProvisionStatus ProvisionStatus { get; set; }

        /// <summary>
        /// DeprovisionStatus describes what has been done to deprovision the
        /// ServiceInstance.
        /// </summary>
        public ServiceInstanceDeprovisionStatus DeprovisionStatus { get; set; }

        /// <summary>
        /// DefaultProvisionParameters are the default parameters applied to this
        /// instance.
        /// </summary>
        public JObject DefaultProvisionParameters { get; set; }
    }
}
