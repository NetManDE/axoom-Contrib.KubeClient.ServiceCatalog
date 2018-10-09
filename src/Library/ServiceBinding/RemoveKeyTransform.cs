using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// RemoveKeyTransform specifies that one of the credentials keys returned
    /// from the broker should not be included in the credentials Secret.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class RemoveKeyTransform
    {
        public string Key { get; set; }
    }
}