using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// RenameKeyTransform specifies that one of the credentials keys returned
    /// from the broker should be renamed
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class RenameKeyTransform
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}