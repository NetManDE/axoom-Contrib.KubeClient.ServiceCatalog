using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
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
        Ready,
        Failed
    }
}