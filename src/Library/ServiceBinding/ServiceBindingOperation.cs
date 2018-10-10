using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// // ServiceBindingOperation represents a type of operation
    /// the controller can be performing for a binding in the OSB API.
    /// Bind indicates that the
    /// ServiceBinding is being bound.
    /// Unbind indicates that the
    /// ServiceBinding is being unbound.
    /// </summary>
    [PublicAPI]
    public enum ServiceBindingOperation
    {
        Bind,
        Unbind
    }
}