using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// ServiceBrokerRelistBehavior represents a type of broker relist behavior.
    /// Duration indicates that the broker will be
    /// relisted automatically after the specified duration has passed.
    /// Manual indicates that the broker is only
    /// relisted when the spec of the broker changes.
    /// </summary>
    [PublicAPI]
    public enum ServiceBrokerRelistBehavior
    {
        [EnumMember(Value = "")] None,
        [EnumMember(Value = "duration")] Duration,
        [EnumMember(Value = "manual")] Manual
    }
}
