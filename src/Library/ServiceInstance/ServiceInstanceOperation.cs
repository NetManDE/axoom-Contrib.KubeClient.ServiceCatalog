using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
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
        [EnumMember(Value = "")] None,
        [EnumMember(Value = "provision")] Provision,
        [EnumMember(Value = "update")] Update,
        [EnumMember(Value = "deprovision")] Deprovision
    }
}
