using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// ServiceBindingStatus represents the current status of a ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingStatus : IEquatable<ServiceBindingStatus>
    {
        public ServiceBindingCondition Conditions { get; set; }

        /// <summary>
        /// CurrentOperation is the operation the Controller is currently performing
        /// on the ServiceBinding.
        /// </summary>
        public ServiceBindingOperation CurrentOperation { get; set; }

        /// <summary>
        /// ReconciledGeneration is the 'Generation' of the
        /// ServiceBindingSpec that was last processed by the controller.
        /// The reconciled generation is updated even if the controller failed to
        /// process the spec.
        /// </summary>
        public long ReconciledGeneration { get; set; }

        /// <summary>
        /// OperationStartTime is the time at which the current operation began.
        /// </summary>
        public DateTime OperationStartTime { get; set; }

        /// <summary>
        /// InProgressProperties is the properties state of the
        /// ServiceBinding when a Bind is in progress. If the current
        /// operation is an Unbind, this will be nil.
        /// </summary>
        public ServiceBindingPropertiesState InProgressProperties { get; set; }

        /// <summary>
        /// ExternalProperties is the properties state of the
        /// ServiceBinding which the broker knows about.
        /// </summary>
        public ServiceBindingPropertiesState ExternalProperties { get; set; }

        /// <summary>
        /// OrphanMitigationInProgress is a flag that represents whether orphan
        /// mitigation is in progress.
        /// </summary>
        public bool OrphanMitigationInProgress { get; set; }

        /// <summary>
        /// UnbindStatus describes what has been done to unbind a ServiceBinding
        /// </summary>
        public string UnbindStatus { get; set; }

        public bool Equals(ServiceBindingStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Conditions, other.Conditions)
                && CurrentOperation == other.CurrentOperation
                && ReconciledGeneration == other.ReconciledGeneration
                && OperationStartTime.Equals(other.OperationStartTime)
                && Equals(InProgressProperties, other.InProgressProperties)
                && Equals(ExternalProperties, other.ExternalProperties)
                && OrphanMitigationInProgress == other.OrphanMitigationInProgress
                && string.Equals(UnbindStatus, other.UnbindStatus);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ServiceBindingStatus)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Conditions != null ? Conditions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)CurrentOperation;
                hashCode = (hashCode * 397) ^ ReconciledGeneration.GetHashCode();
                hashCode = (hashCode * 397) ^ OperationStartTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (InProgressProperties != null ? InProgressProperties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExternalProperties != null ? ExternalProperties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrphanMitigationInProgress.GetHashCode();
                hashCode = (hashCode * 397) ^ (UnbindStatus != null ? UnbindStatus.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    /// <summary>
    /// ServiceBindingPropertiesState is the state of a
    /// ServiceBinding that the ServiceBroker knows about.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingPropertiesState
    {
        /// <summary>
        /// Parameters is a blob of the parameters and their values that the broker
        /// knows about for this ServiceBinding.  If a parameter was
        /// sourced from a secret, its value will be "redacted" in this blob.
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
    /// ServiceBindingCondition condition information for a ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingCondition
    {
        /// <summary>
        /// Type of the condition, currently ('Ready').
        /// </summary>
        public ServiceBindingConditionType Type { get; set; }

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
    /// // ServiceBindingOperation represents a type of operation
    /// the controller can be performing for a binding in the OSB API.
    /// Bind indicates that the
    /// ServiceBinding is being bound.
    /// Unbind indicates that the
    /// ServiceBinding is being unbound.
    /// </summary>
    [PublicAPI]
    public enum ServiceBindingOperation
    {
        Bind,
        Unbind
    }

    /// <summary>
    /// ServiceBindingConditionType represents a ServiceBindingCondition value.
    /// Ready represents a ServiceBindingCondition is in ready state.
    /// Failed represents a ServiceBindingCondition that has failed
    /// completely and should not be retried.
    /// </summary>
    [PublicAPI]
    public enum ServiceBindingConditionType
    {
        Ready,
        Failed
    }
}
