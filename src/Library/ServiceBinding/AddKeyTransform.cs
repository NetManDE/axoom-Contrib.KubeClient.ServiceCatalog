using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// AddKeyTransform specifies that Service Catalog should add an
    /// additional entry to the Secret associated with the ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class AddKeyTransform
    {
        public string Key { get; set; }
        public byte[] Value { get; set; }
        public string StringValue { get; set; }
        public string JSONPathExpression { get; set; }
    }
}