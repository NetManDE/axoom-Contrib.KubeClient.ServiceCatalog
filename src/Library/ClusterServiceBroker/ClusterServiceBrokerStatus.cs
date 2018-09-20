using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBrokerStatus: IEquatable<ClusterServiceBrokerStatus>
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
        public DateTime OperationStartTime { get; set; }

        /// <summary>
        /// LastCatalogRetrievalTime is the time the Catalog was last fetched from
        /// the Service Broker
        /// </summary>
        public DateTime LastCatalogRetrievalTime { get; set; }

        public bool Equals(ClusterServiceBrokerStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Conditions, other.Conditions)
                && ReconciledGeneration == other.ReconciledGeneration
                && OperationStartTime.Equals(other.OperationStartTime)
                && LastCatalogRetrievalTime.Equals(other.LastCatalogRetrievalTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ClusterServiceBrokerStatus) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Conditions != null ? Conditions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ReconciledGeneration.GetHashCode();
                hashCode = (hashCode * 397) ^ OperationStartTime.GetHashCode();
                hashCode = (hashCode * 397) ^ LastCatalogRetrievalTime.GetHashCode();
                return hashCode;
            }
        }
    }

    /// <summary>
    /// ServiceBrokerCondition contains condition information for a Service Broker.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBrokerCondition
    {
        /// <summary>
        /// Type of the condition, currently ('Ready').
        /// </summary>
        public ServiceBrokerConditionType Type { get; set; }

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
    /// ServiceBrokerConditionType represents a broker condition value.
    /// ServiceBrokerConditionReady represents the fact that a given broker condition
    /// is in ready state.
    /// ServiceBrokerConditionFailed represents information about a final failure
    /// that should not be retried.
    /// </summary>
    public enum ServiceBrokerConditionType
    {
        Ready,
        Failed
    }
}
