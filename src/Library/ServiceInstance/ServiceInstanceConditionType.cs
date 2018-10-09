using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
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
}