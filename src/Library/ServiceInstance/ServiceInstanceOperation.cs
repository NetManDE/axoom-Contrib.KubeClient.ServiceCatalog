using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
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
        Provision,
        Update,
        Deprovision
    }
}