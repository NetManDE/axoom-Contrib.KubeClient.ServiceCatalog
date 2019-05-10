using System;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
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
}