using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// AddKeysFromTransform specifies that Service Catalog should merge
    /// an existing secret into the the Secret associated with the ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class AddKeysFromTransform
    {
        public object SecretRef { get; set; }
    }
}