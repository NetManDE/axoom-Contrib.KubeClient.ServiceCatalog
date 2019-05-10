using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ServiceBindingConditionType represents a ServiceBindingCondition value.
    /// Ready represents a ServiceBindingCondition is in ready state.
    /// Failed represents a ServiceBindingCondition that has failed
    /// completely and should not be retried.
    /// </summary>
    [PublicAPI]
    public enum ServiceBindingConditionType
    {
        [EnumMember(Value = "")] None,
        [EnumMember(Value = "ready")] Ready,
        [EnumMember(Value = "failed")] Failed
    }
}
