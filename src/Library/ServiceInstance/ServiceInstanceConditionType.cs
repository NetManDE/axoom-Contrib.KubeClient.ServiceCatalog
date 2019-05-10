using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
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
        [EnumMember(Value = "")] None,
        [EnumMember(Value = "ready")] Ready,
        [EnumMember(Value = "failed")] Failed,
        [EnumMember(Value = "orphanMitigation")] OrphanMitigation
    }
}
