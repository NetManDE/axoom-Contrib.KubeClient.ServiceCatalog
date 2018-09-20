using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
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
        public DateTime OperationStartTime { get; set; }

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

    /// <summary>
    /// ServiceInstanceCondition contains condition information about an Instance.
    /// </summary>
    [PublicAPI]
    public class ServiceInstanceCondition
    {
        /// <summary>
        /// Type of the condition, currently ('Ready').
        /// </summary>
        public ServiceInstanceConditionType Type { get; set; }

        /// <summary>
        /// Status of the condition, one of ('True', 'False', 'Unknown').
        /// </summary>
        public ConditionStatus Status { get; set; }

        /// <summary>
        /// LastTransitionTime is the timestamp corresponding to the last status
        /// change of this condition.
        /// </summary>
        public DateTime LastTransitionTime { get; set; }

        /// <summary>
        /// Reason is a brief machine readable explanation for the condition's last
        /// transition.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Message is a human readable description of the details of the last
        /// transition, complementing reason.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// ServiceInstancePropertiesState is the state of a ServiceInstance that
    /// the ServiceBroker knows about.
    /// </summary>
    [PublicAPI]
    public class ServiceInstancePropertiesState
    {
        /// <summary>
        /// ClusterServicePlanExternalName is the name of the plan that the broker knows this
        /// ServiceInstance to be on. This is the human readable plan name from the
        /// OSB API.
        /// </summary>
        public string ClusterServicePlanExternalName { get; set; }

        /// <summary>
        /// ClusterServicePlanExternalID is the external ID of the plan that the
        /// broker knows this ServiceInstance to be on.
        /// </summary>
        public string ClusterServicePlanExternalID { get; set; }

        /// <summary>
        /// ServicePlanExternalName is the name of the plan that the broker knows this
        /// ServiceInstance to be on. This is the human readable plan name from the
        /// OSB API.
        /// </summary>
        public string ServicePlanExternalName { get; set; }

        /// <summary>
        /// ServicePlanExternalID is the external ID of the plan that the
        /// broker knows this ServiceInstance to be on.
        /// </summary>
        public string ServicePlanExternalID { get; set; }

        /// <summary>
        /// Parameters is a blob of the parameters and their values that the broker
        /// knows about for this ServiceInstance.  If a parameter was sourced from
        /// a secret, its value will be "redacted" in this blob.
        /// </summary>
        public JObject Parameters { get; set; }

        /// <summary>
        /// ParametersChecksum is the checksum of the parameters that were sent.
        /// </summary>
        public string ParametersChecksum { get; set; }

        /// <summary>
        /// UserInfo is information about the user that made the request.
        /// </summary>
        UserInfo UserInfo { get; set; }
    }

    /// <summary>
    /// ServiceInstanceDeprovisionStatus is the status of deprovisioning a
    /// ServiceInstance
    /// NotRequired indicates that a provision
    /// request has not been sent for the ServiceInstance, so no deprovision
    /// request needs to be made.
    /// Required indicates that a provision
    /// request has been sent for the ServiceInstance. A deprovision request
    /// must be made before deleting the ServiceInstance.
    /// Succeeded indicates that a deprovision
    /// request has been sent for the ServiceInstance, and the request was
    /// successful.
    /// Failed indicates that deprovision
    /// requests have been sent for the ServiceInstance but they failed. The
    /// controller has given up on sending more deprovision requests.
    /// </summary>
    [PublicAPI]
	public enum ServiceInstanceDeprovisionStatus
    {
        NotRequired,
        Required,
        Succeeded,
        Failed
    }

    /// <summary>
    /// ServiceInstanceProvisionStatus is the status of provisioning a
    /// ServiceInstance
    /// ServiceInstanceProvisionStatusProvisioned indicates that the instance
    /// was provisioned.
    /// ServiceInstanceProvisionStatusNotProvisioned indicates that the instance
    /// was not ever provisioned or was deprovisioned.
    /// </summary>
    [PublicAPI]
	public enum ServiceInstanceProvisionStatus
    {
        Provisioned,
        NotProvisioned
    }

    /// <summary>
    /// ServiceInstanceConditionType represents a instance condition value.
    /// Ready represents that a given InstanceCondition is in
    /// ready state.
    /// Failed represents information about a final failure
    /// that should not be retried.
    /// OrphanMitigation represents information about an
    /// orphan mitigation that is required after failed provisioning.
    /// </summary>
    [PublicAPI]
	public enum ServiceInstanceConditionType
    {
        Ready,
        Failed,
        OrphanMitigation
    }

    /// <summary>
    /// ServiceInstanceOperation represents a type of operation the controller can
    /// be performing for a service instance in the OSB API.
    /// Provision indicates that the ServiceInstance is
    /// being Provisioned.
    /// Update indicates that the ServiceInstance is
    /// being Updated.
    /// Deprovision indicates that the ServiceInstance is
    /// being Deprovisioned.
    /// </summary>
    [PublicAPI]
	public enum ServiceInstanceOperation
    {
        Provision,
        Update,
        Deprovision
    }
}
