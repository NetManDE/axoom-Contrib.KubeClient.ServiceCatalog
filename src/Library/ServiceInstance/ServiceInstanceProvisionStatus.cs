using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
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
        [EnumMember(Value = "")] None,
        [EnumMember(Value = "provisioned")] Provisioned,
        [EnumMember(Value = "notProvisioned")] NotProvisioned
    }
}
